using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// User Creator.
/// Created by Ryan, Hunter, and Matt. 
/// </summary>

namespace Housing_Project {
    public class User {

        string firstName; // Instance variables for the user class. 
        string lastName;
        int phoneNumber;
        string email;
        string userName;
        string password;
        int income;
        string typeOfUser;
        int householdSize;

        /// <summary>
        /// This constructor will allow us to create user objects. 
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
        User(string firstName, string lastName, int phoneNumber, string email, string userName, string password, int income, string typeOfUser, int householdSize) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.userName = userName;
            this.password = password;
            this.income = income;
            this.typeOfUser = typeOfUser;
            this.householdSize = householdSize;
        }


    }
}