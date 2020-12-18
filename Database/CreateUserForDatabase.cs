using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections;
using System.Security.Cryptography;

/// <summary>
/// Create User in the Database from Create Account page
/// Created by Ryan, Hunter, and Matt
/// </summary>
namespace Housing_Project {
    public class CreateUserForDatabase : ICreateUserForDatabase {
        /// <summary>
        /// This method will create a user and store it in our database as long as they enter in valid inputs. 
        /// </summary>
        /// <param name="firstName">First name of user</param>
        /// <param name="lastName">Last name of user</param>
        /// <param name="phoneNumber">user phone number</param>
        /// <param name="email">user email </param>
        /// <param name="userName">Users username </param>
        /// <param name="password">user password</param>
        /// <param name="income">users income</param>
        /// <param name="typeOfUser">Type of user</param>
        /// <param name="householdSize">People living in house</param>
        /// <param name="county">The counties the user selected.</param>
        /// <returns>Returns a message saying if the creation was successful or not.</returns>
        public string CreateUser(string firstName, string lastName, string phoneNumber, string email,
                                        string userName, string password, int income, string typeOfUser, int householdSize, ArrayList county) {
            AccountValidator checkInput = new AccountValidator();

            if (checkInput.ValidName(firstName, lastName) != "valid.") { // check if all user inputs are valid. 
                return checkInput.ValidName(firstName, lastName);
            }
            else if (checkInput.PhoneValid(phoneNumber) != "Valid Number.") {
                return checkInput.PhoneValid(phoneNumber);
            }
            else if (checkInput.ValidEmail(email) != "Valid email.") {
                return checkInput.ValidEmail(email);
            }
            else if (checkInput.ValidUserName(userName) != "Valid userName") {
                return checkInput.ValidUserName(userName);
            }
            else if (checkInput.ValidPassword(password, firstName, lastName) != "Valid Pass.") {
                return checkInput.ValidPassword(firstName, lastName, password);
            }
            else if (checkInput.ValidIncome(income) != "valid income") {
                return checkInput.ValidIncome(income);
            }
            else if (checkInput.ValidHouseSize(householdSize) != "Valid housing size") {
                return checkInput.ValidHouseSize(householdSize);
            }
            else {
                try {
                    using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) { // establishing ssh connection to server where MySql is hosted
                        client.Connect();

                        string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                        var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        client.AddForwardedPort(portForwarded);
                        portForwarded.Start();
                        using (MySqlConnection conn = new MySqlConnection(connectDB)) {
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Renters(Username, Password, PasswordSalt, Email, Phone, FirstName, LastName, Income, Household, County1, County2, County3) VALUES(@Username, @Password, @PasswordSalt,  @Email, @Phone, @FirstName, @LastName, @Income, @Household, @County1, @County2, @County3)", conn)) {
                                string salt = CreateSalt();
                                
                                string finalPass = CreateHash(password, salt);  //Convert to a base 64 string.

                                conn.Open();
                                cmd.Parameters.AddWithValue("@Username", userName); //Insert all parameters.
                                cmd.Parameters.AddWithValue("@Password", finalPass);
                                cmd.Parameters.AddWithValue("@PasswordSalt", salt);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                                cmd.Parameters.AddWithValue("@FirstName", firstName);
                                cmd.Parameters.AddWithValue("@LastName", lastName);
                                cmd.Parameters.AddWithValue("@Income", income);
                                cmd.Parameters.AddWithValue("@HouseHold", householdSize);
                                cmd.Parameters.AddWithValue("@County1", county[0] != "null" ? county[0] : "empty");
                                cmd.Parameters.AddWithValue("@County2", county[1] != "null" ? county[1] : "empty");
                                cmd.Parameters.AddWithValue("@County3", county[2] != "null" ? county[2] : "empty");
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        client.Disconnect();
                    }
                }
                catch (Exception error) {
                    return error.Message;
                }
            }
            return "Success";
        }

        /// <summary>
        /// This method will create a salt for the user password.
        /// </summary>
        /// <returns>Return a string thats the salt.</returns>
        private string CreateSalt() {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); 
            byte[] buff = new byte[8];
            rng.GetBytes(buff); // Generate a randomy crypto number and fill a byte array. 
    
            return Convert.ToBase64String(buff); // return a base 64 string. 
        }

        /// <summary>
        /// This method will combine the userpassword and the salt to 
        /// then hash the password.
        /// </summary>
        /// <param name="password"> The password to be hashed.</param>
        /// <param name="salt">The salt that will be added.</param>
        /// <returns>Return the hashed password.</returns>
        private string CreateHash(string password, string salt) {
            
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider(); // Create a new instance of the hash service provider.
            
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(password + salt); // Convert the data to hash to an array of Bytes.
            
            byte[] bytHash = hashAlg.ComputeHash(bytValue); // Compute the Hash and store in byte array.
            string finalPass = Convert.ToBase64String(bytHash);
            return finalPass;

        }

        /// <summary>
        /// This method will log in the user.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">user password</param>
        /// <returns>Returns a number if the login was valid or not.</returns>
        public int LoginUser(string username, string password) {
            int result = 0;
            try {
                using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) { // create connection
                    client.Connect();

                    string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection conn = new MySqlConnection(connectDB)) {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Renters` WHERE Username = @Username", conn)) { // grab from database.
                            conn.Open();
                            cmd.Parameters.AddWithValue("@Username", username);//Insert all parameters.
                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            string sqlPass = reader.GetValue(1).ToString(); // Get the user password.
                            string salt = reader.GetValue(2).ToString(); // get the users salt. 
                            string finalPass = CreateHash(password, salt); // hash the users entered password with the salt. 
                            
                            if (sqlPass == finalPass) { // compare the passwords. 
                                result = 1;
                            }
                            conn.Close();
                        }
                        
                        client.Disconnect();
                    }
                }
            }
            catch (Exception error) {
                return result;
            }
            return result;
        }

        /// <summary>
        /// This method will get the user's info grabbing all the users credentials. 
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>Return an array of user credentials as strings.</returns>
        public string[] UserInfo(string username) {
            string[] userInfo = new string[10];
            try {
                using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) {
                    client.Connect();

                    string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection conn = new MySqlConnection(connectDB)) {// establish connection to database. 
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Renters` WHERE Username = @Username", conn)) {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@Username", username);//Insert all parameters.
                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            userInfo[0] = reader.GetValue(0).ToString(); // Store all user info in an array. 
                            userInfo[1] = reader.GetValue(3).ToString();
                            userInfo[2] = reader.GetValue(4).ToString();
                            userInfo[3] = reader.GetValue(5).ToString();
                            userInfo[4] = reader.GetValue(6).ToString();
                            userInfo[5] = reader.GetValue(7).ToString();
                            userInfo[6] = reader.GetValue(8).ToString();
                            userInfo[7] = reader.GetValue(9).ToString();
                            userInfo[8] = reader.GetValue(10).ToString();
                            userInfo[9] = reader.GetValue(11).ToString();                                                      
                            conn.Close();
                        }

                        client.Disconnect();
                    }
                }
            }
            catch (Exception error) {
                return userInfo;
            }
            return userInfo;
        }
        
        /// <summary>
        /// Update user will allow the user to update their, first name, last name, phone number, income, household size
        /// and the counties they want to search in. 
        /// </summary>
        /// <param name="firstName">users first name</param>
        /// <param name="lastName">Users last name</param>
        /// <param name="username">Users username</param>
        /// <param name="phoneNumber">Users phone number</param>
        /// <param name="income">The users income</param>
        /// <param name="householdSize">Users household size.</param>
        /// <param name="county">Users counties.</param>
        /// <returns>A string saying if the update was successful.</returns>
        public string UpdateUser(string firstName, string lastName, string username, string phoneNumber,
                                        int income, int householdSize, ArrayList county) {
            AccountValidator checkInput = new AccountValidator();

            if (checkInput.ValidName(firstName, lastName) != "valid.") {// validate user inputs
                return checkInput.ValidName(firstName, lastName);
            }
            else if (checkInput.PhoneValid(phoneNumber) != "Valid Number.") {
                return checkInput.PhoneValid(phoneNumber);
            }
            else if (checkInput.ValidIncome(income) != "valid income") {
                return checkInput.ValidIncome(income);
            }
            else if (checkInput.ValidHouseSize(householdSize) != "Valid housing size") {
                return checkInput.ValidHouseSize(householdSize);
            }
            else {
                try {
                    
                    using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) {// establishing an ssh connection.
                        client.Connect();

                        string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                        var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        client.AddForwardedPort(portForwarded);
                        portForwarded.Start();
                        using (MySqlConnection conn = new MySqlConnection(connectDB)) {
                            using (MySqlCommand cmd = new MySqlCommand("UPDATE Renters Set Phone = @Phone, FirstName = @FirstName, LastName = @LastName, Income = @Income, HouseHold = @HouseHold, County1 = @County1, County2 = @County2, County3 = @County3 WHERE Username=@Username", conn)) {  

                                conn.Open();
                                cmd.Parameters.AddWithValue("@Username", username);//Insert all parameters.
                                cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                                cmd.Parameters.AddWithValue("@FirstName", firstName);
                                cmd.Parameters.AddWithValue("@LastName", lastName);
                                cmd.Parameters.AddWithValue("@Income", income);
                                cmd.Parameters.AddWithValue("@HouseHold", householdSize);
                                cmd.Parameters.AddWithValue("@County1", county[0] != null ? county[0] : "empty");
                                cmd.Parameters.AddWithValue("@County2", county[1] != null ? county[1] : "empty");
                                cmd.Parameters.AddWithValue("@County3", county[2] != null ? county[2] : "empty");
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        client.Disconnect();
                    }
                }
                catch (Exception error) {
                    return error.Message;
                }
            }
            return "Success";
        }
    }
}

