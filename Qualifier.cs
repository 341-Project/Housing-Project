using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Housing_Project
{
    class IncomeChecker
    {
        //pass in list of counties, runs a while loop that is size of list
        //if it finds a county you qualify for something happens, does it have another array,
        //that is populated by list of properties you qualify for by each county? So if you
        //qualify for the first county it populates the new array with that counties array?
        //if you don't qualify for the next county, it skips and doesn't add the final array
        //once all counties are gone through it returns a list of the array, which ideally could
        //be objects? Issue is that there is multiple programs. Start at the bottom, if you qualify for a 30 you qualify
        //for a 50, and a 60. If you don't qualify for a 30 it checks a 50, and so on and so on. 

        //SQL code, we could take an input that checks the table for a county name, county name then go to the # of members in a household spot of 
        //members in the household and then for the first one it pulls the 30% data, 2nd one pulls 50% data, and 3rd and 4th
        //one pulls 60% data.
        public string Qualifier(int household, int income, ArrayList county)
        {
            int i = 0;
            string id = "";
            string resultsShown = "";

            string connectDB = ConfigurationManager.ConnectionStrings["MySQLDB"].ConnectionString;
            MySqlConnection connect = new MySqlConnection(connectDB);

            while (i < county.Count)
            {
                id = county[i].ToString(); //SQL database uses that ID to find the right table

                if (household == 1)
                {
                    connect.Open();

                    MySqlCommand county30 = new MySqlCommand("SELECT `1` FROM `County 30%` WHERE County = @id", connect);

                    county30.Parameters.AddWithValue("@id", id);
                    county30.ExecuteNonQuery();

                    MySqlDataReader reader = county30.ExecuteReader();

                    reader.Read();
                    int incomeLimit = (int)reader.GetValue(0); //query?
                    connect.Close();

                    resultsShown += incomeLimit;

                    if (income <= incomeLimit) //calls sql table for county 30%
                    {
                        resultsShown += "30% Qualification";
                        resultsShown += " ";
                        resultsShown += id;
                        resultsShown += "\n";
                        return "30% Qualification"; 
                    }

                    connect.Open();

                    MySqlCommand county40 = new MySqlCommand("SELECT `1` FROM `County 40%` WHERE County = @id", connect);

                    county30.Parameters.AddWithValue("@id", id);
                    county30.ExecuteNonQuery();

                    reader = county40.ExecuteReader();

                    reader.Read();
                    incomeLimit = (int)reader.GetValue(0); //query?
                    connect.Close();

                    if (income <= incomeLimit) //variable == squl query 40%
                    {
                        return "40% Qualification";
                    }

                    connect.Open();

                    MySqlCommand county50 = new MySqlCommand("SELECT `1` FROM `County 50%` WHERE County = @id", connect);

                    county30.Parameters.AddWithValue("@id", id);
                    county30.ExecuteNonQuery();

                    reader = county40.ExecuteReader();

                    reader.Read();
                    incomeLimit = (int)reader.GetValue(0); //query?
                    connect.Close();

                    if (income <= 60000) //variable == squl query 50%
                    {
                        return "50% Qualification";
                    }

                    connect.Open();

                    MySqlCommand county60 = new MySqlCommand("SELECT `1` FROM `County 60%` WHERE County = @id", connect);

                    county30.Parameters.AddWithValue("@id", id);
                    county30.ExecuteNonQuery();

                    reader = county40.ExecuteReader();

                    reader.Read();
                    incomeLimit = (int)reader.GetValue(0); //query?
                    connect.Close();

                    if (income < 65000) //variable == squl query 60%
                    {
                        return "60% Qualification";
                    }

                    return "Market Rate Qualification";
                }

                if (household == 2)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 3)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 4)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }
                if (household == 5)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 6)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 7)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 8)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 9)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                if (household == 10)
                {
                    if (income <= 35000) //45000 is a hardcoded variable that will change based on sql.
                    {
                        return "30% Qualification";
                    }
                    else if (income <= 45000)
                    {
                        return "50% Qualification";
                    }
                    else if (income <= 60000)
                    {
                        return "60% Qualification";
                    }
                    else if (income > 60000)
                    {
                        return "Market Rate Qualification";
                    }
                }

                i++;
            }


            return resultsShown;

        }
    }
}