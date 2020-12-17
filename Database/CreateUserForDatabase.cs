using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections;
using System.Security.Cryptography;

namespace Housing_Project
{
    public class CreateUserForDatabase
    {

        public string CreateUser(string firstName, string lastName, string phoneNumber, string email,
                                        string userName, string password, int income, string typeOfUser, int householdSize, ArrayList county)
        {
            AccountValidator checkInput = new AccountValidator();

            if (checkInput.ValidName(firstName, lastName) != "valid.")
            {
                return checkInput.ValidName(firstName, lastName);
            }
            else if (checkInput.PhoneValid(phoneNumber) != "Valid Number.")
            {
                return checkInput.PhoneValid(phoneNumber);
            }
            else if (checkInput.ValidEmail(email) != "Valid email.")
            {
                return checkInput.ValidEmail(email);
            }
            else if (checkInput.ValidUserName(userName) != "Valid userName")
            {
                return checkInput.ValidUserName(userName);
            }
            else if (checkInput.ValidPassword(password, firstName, lastName) != "Valid Pass.")
            {
                return checkInput.ValidPassword(firstName, lastName, password);
            }
            else if (checkInput.ValidIncome(income) != "valid income")
            {
                return checkInput.ValidIncome(income);
            }
            else if (checkInput.ValidHouseSize(householdSize) != "Valid housing size")
            {
                return checkInput.ValidHouseSize(householdSize);
            }
            else
            {
                try
                {
                    // establishing ssh connection to server where MySql is hosted
                    using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257"))
                    {
                        client.Connect();

                        string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                        var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        client.AddForwardedPort(portForwarded);
                        portForwarded.Start();
                        using (MySqlConnection conn = new MySqlConnection(connectDB))
                        {
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Renters(Username, Password, PasswordSalt, Email, Phone, FirstName, LastName, Income, Household, County1, County2, County3) VALUES(@Username, @Password, @PasswordSalt,  @Email, @Phone, @FirstName, @LastName, @Income, @Household, @County1, @County2, @County3)", conn))
                            {
                                string salt = CreateSalt();
                                
                                string finalPass = CreateHash(password, salt);  //Convert.ToBase64String(bytHash);

                                conn.Open();
                                cmd.Parameters.AddWithValue("@Username", userName);//Insert all parameters.
                                cmd.Parameters.AddWithValue("@Password", finalPass);
                                cmd.Parameters.AddWithValue("@PasswordSalt", salt);
                                cmd.Parameters.AddWithValue("@Email", email);
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
                catch (Exception error)
                {
                    return error.Message;
                }
            }
            return "yes";
        }
        private static string CreateSalt() {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[8];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        private static string CreateHash(string password, string salt) {
            // Create a new instance of the hash crypto service provider.
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            // Convert the data to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(password + salt);
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            string finalPass = Convert.ToBase64String(bytHash);
            return finalPass;

        }
        public int LoginUser(string username, string password)
        {
            int result = 0;
            try
            {
                using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257"))
                {
                    client.Connect();

                    string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection conn = new MySqlConnection(connectDB))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Renters` WHERE Username = @Username", conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@Username", username);//Insert all parameters.
                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            //result
                            string sqlPass = reader.GetValue(1).ToString();
                            string salt = reader.GetValue(2).ToString();
                            string finalPass = CreateHash(password, salt); //Convert.ToBase64String(bytHash);
                            
                            if (sqlPass == finalPass)
                            {
                                result = 1;
                            }
                            conn.Close();
                        }
                        
                        client.Disconnect();
                    }
                }
            }
            catch (Exception error)
            {
                return result;
            }
            return result;
        }
        public string[] UserInfo(string username)
        {
            string[] userInfo = new string[10];
            try
            {
                using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257"))
                {
                    client.Connect();

                    string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                    client.AddForwardedPort(portForwarded);
                    portForwarded.Start();
                    using (MySqlConnection conn = new MySqlConnection(connectDB))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Renters` WHERE Username = @Username", conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@Username", username);//Insert all parameters.
                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            userInfo[0] = reader.GetValue(0).ToString();
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
            catch (Exception error)
            {
                return userInfo;
            }
            return userInfo;
        }
        
        public string UpdateUser(string firstName, string lastName, string username, string phoneNumber,
                                        int income, int householdSize, ArrayList county)
        {
            AccountValidator checkInput = new AccountValidator();

            if (checkInput.ValidName(firstName, lastName) != "valid.")
            {
                return checkInput.ValidName(firstName, lastName);
            }
            else if (checkInput.PhoneValid(phoneNumber) != "Valid Number.")
            {
                return checkInput.PhoneValid(phoneNumber);
            }
            else if (checkInput.ValidIncome(income) != "valid income")
            {
                return checkInput.ValidIncome(income);
            }
            else if (checkInput.ValidHouseSize(householdSize) != "Valid housing size")
            {
                return checkInput.ValidHouseSize(householdSize);
            }
            else
            {
                try
                {
                    // establishing ssh connection to server where MySql is hosted
                    using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257"))
                    {
                        client.Connect();

                        string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                        var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                        client.AddForwardedPort(portForwarded);
                        portForwarded.Start();
                        using (MySqlConnection conn = new MySqlConnection(connectDB))
                        {
                            using (MySqlCommand cmd = new MySqlCommand("UPDATE Renters Set Phone = @Phone, FirstName = @FirstName, LastName = @LastName, Income = @Income, HouseHold = @HouseHold, County1 = @County1, County2 = @County2, County3 = @County3 WHERE Username=@Username", conn))
                            {  

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
                catch (Exception error)
                {
                    return error.Message;
                }
            }
            return "yes";
        }
    }
}

