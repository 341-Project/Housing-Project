using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Housing_Project
{
    public class PropertyListGenerator
    {
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
                    if (PopulateProgram(properties[j]) > countyQualifications[i])
                    {
                        codeToDisplay += "<div class='card'><img class='card-img' img src='" + PopulateImage(properties[j]) + "' width='300' height='200'></img>";
                        codeToDisplay += "<div class='card-body'>";
                        codeToDisplay += "<h5 class='card-title'>" + PopulateName(properties[j]) + "</h5>";
                        codeToDisplay += "<p class='card-text'>Address:" + PopulateAddress(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>City:" + PopulateCity(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>Bedrooms:" + PopulateBedrooms(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>Email:" + PopulateEmail(properties[j]) + "</p>";
                        codeToDisplay += "<p class='card-text'>Phone:" + PopulatePhone(properties[j]) + "</p></div></div>";
                    }
                }
            }

            codeToDisplay += "</div>";
            return codeToDisplay;
        }




        //everything after this is should be in its own class.
        public static List<Properties> PopulatePropertiesList(List<Properties> propertiesList, string currentCounty)
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
                                                                 reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString());
                            propertiesList.Add(property);
                        }
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

        public static string PopulateCity(Properties currentProperty)
        {
            string city = "";

            city = currentProperty.GetCity();

            return city;
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

        public static string PopulateOwnerId(Properties currentProperty)
        {
            string ownerId = "";

            ownerId = currentProperty.GetCity();

            return ownerId;
        }
    }
}