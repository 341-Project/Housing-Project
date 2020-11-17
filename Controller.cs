using MySql.Data.MySqlClient;
using Renci.SshNet;
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

        public static string PropertyRetriever(List<int> countyQualifications, ArrayList county)
        {
            string codeToDisplay = "";

            for (int i = 0; i < county.Count; i++)
            {
                List<Properties> properties = new List<Properties>();

                properties = PopulatePropertiesList(properties, county[i].ToString());

                codeToDisplay += countyQualifications[i];
                codeToDisplay += county[i];

                for (int j = 0; j < properties.Count; j++)
                {


                    if (PopulateProgram(properties[j]) > countyQualifications[i]) //needs to be parsed to int  50 >
                    {
                        codeToDisplay += "<div>";
                        codeToDisplay += PopulateAddress(properties[j]); //getters for the sql database method params might be wrong
                        codeToDisplay += PopulateBedrooms(properties[j]);
                        codeToDisplay += PopulateImage(properties[j]);
                        codeToDisplay += PopulateEmail(properties[j]);
                        codeToDisplay += PopulatePhone(properties[j]);
                        codeToDisplay += PopulateName(properties[j]);
                        codeToDisplay += "</div>";
                    }
                }
            }

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