using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Housing_Project
{
    internal class Controller
    {
        /*
         * Takes input from front end, and passes them IncomeChecker class
         * that returns an array list that corresponds to the county arraylist.
         * That arraylist returned holds the values of what the users qualifactions
         * are for each county selected.
         */

        public static string Search(int household, int income, ArrayList county)
        {
            string results = "";

            List<int> countyQualifications;

            countyQualifications = IncomeChecker.Qualifier(household, income, county);


            return results = PropertyRetriever(countyQualifications, county);
        }

        public static string CreateUser(string firstName, string lastName, string phoneNumber, string email,
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
                    using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
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
                catch (Exception e) {
                    return e.Message;
                    //MessageBox.Show(e.Message);
                    //feedBack = "Error in dataBase access.";
                }
            }
            return "yes";
        }


        public static string PropertyRetriever(List<int> countyQualifications, ArrayList county)
        {
            string codeToDisplay = "";

            codeToDisplay += "<link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css'>";

            codeToDisplay += "<div class='card-columns'>";

            for (int i = 0; i < county.Count; i++)
            {
                List<Properties> properties = new List<Properties>();

                properties = PopulatePropertiesList(properties, county[i].ToString());


                for (int j = 0; j < properties.Count; j++)
                {
                    if (PopulateProgram(properties[j]) > countyQualifications[i]) //needs to be parsed to int  50 >
                    {
                        codeToDisplay += "<div class='card'><img class='card-img' img src='https://images.unsplash.com/photo-1580587771525-78b9dba3b914?ixlib=rb-1.2.1&auto=format&fit=crop&w=1934&q=80'></img>";
                        codeToDisplay += "<div class='card-body'>";
                        codeToDisplay += "<h5 class='card-title'>" + PopulateName(properties[j]) + "</h5></div>";
                        codeToDisplay += "<p class='card-text'>" + PopulateAddress(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>" + PopulateBedrooms(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>" + PopulateImage(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>" + PopulateEmail(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>" + PopulatePhone(properties[j]) + "</p></div>";
                    }
                }
            }

            codeToDisplay += "</div>";
            return codeToDisplay;
        }

        public static List<Properties> PopulatePropertiesList(List<Properties> propertiesList, string currentCounty)
        {
            using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();

                string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                client.AddForwardedPort(portForwarded);
                portForwarded.Start();
                using (MySqlConnection conn = new MySqlConnection(connectDB))
                {
                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Properties` WHERE county = @currentCounty", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@currentCounty", currentCounty);
                        cmd.ExecuteNonQuery();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Properties property = new Properties(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(),
                                                                 reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(),
                                                                 reader.GetValue(8).ToString());
                            propertiesList.Add(property);
                        }
                        //cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                client.Disconnect();
            }

            return propertiesList;
        }

        public static int PopulateProgram(Properties currentProperty)
        {
            int maxProgram = -1;

            maxProgram = int.Parse(currentProperty.GetProgram());

            return maxProgram;
        }

        public static string PopulateImage(Properties currentProperty)
        {
            string image = "";

            image = currentProperty.GetPicture();

            return image;
        }

        public static string PopulateEmail(Properties currentProperty)
        {
            string email = "";

            email = currentProperty.GetEmail();

            return email;
        }

        public static string PopulateAddress(Properties currentProperty)
        {
            string address = "";

            address = currentProperty.GetAddress();

            return address;
        }

        public static string PopulatePhone(Properties currentProperty)
        {
            string phone = "";

            phone = currentProperty.GetPhone();

            return phone;
        }

        public static string PopulateBedrooms(Properties currentProperty)
        {
            string bedrooms = "";

            bedrooms = currentProperty.GetBedrooms().ToString();

            return bedrooms;
        }

        public static string PopulateName(Properties currentProperty)
        {
            string name = "";

            name = currentProperty.GetName();

            return name;
        }
    }
}