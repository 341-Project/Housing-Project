using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Housing_Project
{
    internal class IncomeChecker
    {
        /*
         * Passes in ArrayList of counties chosen by the user, as well as the
         * users household size and their income
         *
         */

        public static List<int> Qualifier(int household, int income, ArrayList county)
        {
            List<int> countyQual = new List<int>();

            /*

            using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();

                string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                client.AddForwardedPort(portForwarded);
                portForwarded.Start();
                using (MySqlConnection conn = new MySqlConnection(connectDB))
                {
                    using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Renters(Username, Password, Email, Phone, FirstName, County1) VALUES(@Username, @Password, @Email, @Phone, @FirstName, @County1)", conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                client.Disconnect();
            }
            */

            countyQual = CheckIncome(household, income, county);

            return countyQual;
        }

        /*
         * Calls methods for each income bracket iterively through each
         * county the user chose. If the user qualifies for said county
         * a string is appended stating as such.
         *
         * This might need to return an arraylist that returns, pending.
         *
         */

        public static List<int> CheckIncome(int household, int income, ArrayList county)
        {
            int incomeLimit;
            List<int> countyQual = new List<int>();
            string id = "";

            for (int i = 0; i < county.Count; i++)
            {
                id = county[i].ToString(); //SQL database uses that ID to find the right table

                incomeLimit = County30Check(household, id);

                if (incomeLimit > income)
                {
                    countyQual.Add(30);
                    continue;
                }

                /*
                incomeLimit = County40Check(household, id);

                if (incomeLimit > income)
                {
                    countyQual.Add(40);
                    continue;
                }

                incomeLimit = County50Check(household, id);

                if (incomeLimit > income)
                {
                    countyQual.Add(50);
                    continue;
                }

                incomeLimit = County60Check(household, id);

                if (incomeLimit > income)
                {
                    countyQual.Add(60);
                    continue;
                }
                */
                else
                {
                    countyQual.Add(incomeLimit);
                }
                
            }

            return countyQual;
        }

        /*
         * Calls SQL command to return the income for a certain county and household size.
         * Specifically the 30% Bracket.
         */

        public static int County30Check(int hhSize, string id)
        {
            string household = hhSize.ToString();
            int incomeLimit = 0;

            using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();

                string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                client.AddForwardedPort(portForwarded);
                portForwarded.Start();
                using (MySqlConnection conn = new MySqlConnection(connectDB))
                {
                    string sql = "SELECT @household FROM `County_30` WHERE Counties = @id";

                    using (MySqlCommand county30 = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        county30.Parameters.AddWithValue("@household", household);
                        county30.Parameters.AddWithValue("@id", id);
                        county30.ExecuteNonQuery();
                        MySqlDataReader reader = county30.ExecuteReader();
                        reader.Read();

                        incomeLimit = int.Parse(reader.GetValue(0).ToString());
                        //Console.WriteLine(test);
                        //incomeLimit = 5000;
                        //string test1 = incomeLimit + "30";

                        conn.Close();
                    }
                }
                client.Disconnect();
            }

            return incomeLimit;
        }

        /*
         * Calls SQL command to return the income for a certain county and household size.
         * Specifically the 40% Bracket.
         */

        public static int County40Check(int hhSize, string id)
        {
            string household = hhSize.ToString();
            int incomeLimit = 0;

            using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();

                string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                client.AddForwardedPort(portForwarded);
                portForwarded.Start();
                using (MySqlConnection conn = new MySqlConnection(connectDB))
                {
                    using (MySqlCommand county40 = new MySqlCommand("SELECT " + hhSize + " FROM `County_40` WHERE Counties = @id", conn))
                    {
                        conn.Open();
                        //county40.Parameters.AddWithValue("@household", household);
                        county40.Parameters.AddWithValue("@id", id);
                        //county40.ExecuteNonQuery();
                        MySqlDataReader reader = county40.ExecuteReader();
                        reader.Read();
                        incomeLimit = int.Parse(reader.GetString(0));
                        conn.Close();
                    }
                }
                client.Disconnect();
            }

            return incomeLimit;
        }

        /*
         * Calls SQL command to return the income for a certain county and household size.
         * Specifically the 50% Bracket.
         */

        public static int County50Check(int hhSize, string id)
        {
            string household = hhSize.ToString();
            int incomeLimit = 0;

            using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();

                string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                client.AddForwardedPort(portForwarded);
                portForwarded.Start();
                using (MySqlConnection conn = new MySqlConnection(connectDB))
                {
                    using (MySqlCommand county50 = new MySqlCommand("SELECT " + hhSize + " FROM `County_50` WHERE Counties = @id", conn))
                    {
                        conn.Open();
                        //county50.Parameters.AddWithValue("@household", household);
                        county50.Parameters.AddWithValue("@id", id);
                        //county50.ExecuteNonQuery();
                        MySqlDataReader reader = county50.ExecuteReader();
                        reader.Read();
                        incomeLimit = int.Parse(reader.GetString(0));
                        conn.Close();
                    }
                }
                client.Disconnect();
            }

            return incomeLimit;
        }

        /*
         * Calls SQL command to return the income for a certain county and household size.
         * Specifically the 60% Bracket.
         */

        public static int County60Check(int hhSize, string id)
        {
            string household = hhSize.ToString();
            int incomeLimit = 0;

            using (var client = new SshClient("softeng.cs.uwosh.edu", 1022, "heidem57", "cs341SoftEngg@486257")) // establishing ssh connection to server where MySql is hosted
            {
                client.Connect();

                string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                client.AddForwardedPort(portForwarded);
                portForwarded.Start();
                using (MySqlConnection conn = new MySqlConnection(connectDB))
                {
                    using (MySqlCommand county60 = new MySqlCommand("SELECT " + hhSize + " FROM `County_60` WHERE Counties = @id", conn))
                    {
                        conn.Open();
                        //county60.Parameters.AddWithValue("@household", household);
                        county60.Parameters.AddWithValue("@id", id);
                        //county60.ExecuteNonQuery();
                        MySqlDataReader reader = county60.ExecuteReader();
                        reader.Read();
                        incomeLimit = int.Parse(reader.GetString(0));
                        conn.Close();
                    }
                }
                client.Disconnect();
            }

            return incomeLimit;
        }
    }
}