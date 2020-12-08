using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Housing_Project {
    class Controller {
    
        public static CreateUserForDatabase creator = new CreateUserForDatabase();    

        /*
         * -----
         * Takes input from front end, and passes them IncomeChecker class
         * that returns an array list that corresponds to the county arraylist.
         * That arraylist returned holds the values of what the users qualifactions
         * are for each county selected.
         * -----
         */

        public static string Search(int household, int income, ArrayList county) {
            //string results = "";
            List<int> countyQualifications;
            countyQualifications = IncomeChecker.Qualifier(household, income, county);

            return PropertyListGenerator.PropertyRetriever(countyQualifications, county);
        }

        public static string CreateUser(string firstName, string lastName, string phoneNumber, string email,
                                        string userName, string password, int income, string typeOfUser, int householdSize, ArrayList county) {
            return creator.CreateUser(firstName, lastName, phoneNumber, email, userName, password, income, typeOfUser, householdSize, county);  
        } 
        public static int LoginUser(String userName, string password){
            return creator.LoginUser(userName, password);
        }
    }
}