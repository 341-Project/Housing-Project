using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections;

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
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Renters(Username, Password, Email, Phone, FirstName, LastName, Income, Household, County1, County2, County3) VALUES(@Username, @Password, @Email, @Phone, @FirstName, @LastName, @Income, @Household, @County1, @County2, @County3)", conn))
                            {
                                conn.Open();
                                cmd.Parameters.AddWithValue("@Username", userName);//Insert all parameters.
                                cmd.Parameters.AddWithValue("@Password", password);
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
                        using (MySqlCommand cmd = new MySqlCommand("SELECT Password FROM `Renters` WHERE Username = @Username", conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@Username", username);//Insert all parameters.
                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            //result
                            string sqlPass = reader.GetValue(0).ToString();
                            if(sqlPass == password)
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

    }
}

