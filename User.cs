using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_5 {
    public class User {
        string firstName;
        string lastName;
        int phoneNumber;
        string email;
        string userName;
        string password;
        int income;
        string typeOfUser;
        int householdSize;
        //string address;

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
           //this.address = address;
        }


    }
}