using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Housing_Project {
    public class Controller : IController {
    
        public static ICreateUserForDatabase creator = new CreateUserForDatabase(); // Create an instance of the create user datebase. 
        public static IPropertyListGenerator propGen = new PropertyListGenerator();
        public static IIncomeChecker check = new IncomeChecker();

        /// <summary>
        /// Takes input from front end, and passes them IncomeChecker class
        /// that returns an array list that corresponds to the county arraylist.
        /// That arraylist returned holds the values of what the users qualifactions
        /// are for each county selected.
        /// </summary>
        /// <param name="household">Household size.</param>
        /// <param name="income">User's income.</param>
        /// <param name="county">Users counties they want to search in.</param>
        /// <returns></returns>
        public string Search(int household, int income, ArrayList county) {
            List<int> countyQualifications;
            countyQualifications = check.Qualifier(household, income, county);

            return propGen.PropertyRetriever(countyQualifications, county);
        }
        
        /// <summary>
        /// This method will pass all the users info to the create user method. 
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
            return creator.CreateUser(firstName, lastName, phoneNumber, email, userName, password, income, typeOfUser, householdSize, county);  
        } 

        /// <summary>
        /// This method will pass the users info to the login method to log in a user. 
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">user password</param>
        /// <returns>Returns a number if the login was valid or not.</returns>
        public int LoginUser(String userName, string password){
            return creator.LoginUser(userName, password);
        }

        /// <summary>
        /// This method will get the user's info grabbing all the users credentials. 
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <returns>Return an array of user credentials as strings.</returns>
        public string[] UserInfo(string user) {
            return creator.UserInfo(user);
        }

        /// <summary>
        /// Update user will allow the user to update their, first name, last name, phone number, income, household size
        /// and the counties they want to search in by passing it to the update user method. 
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
                                        int income, int householdSize, ArrayList county){
            return creator.UpdateUser(firstName, lastName, username, phoneNumber, income, householdSize, county);
        }
    }
}