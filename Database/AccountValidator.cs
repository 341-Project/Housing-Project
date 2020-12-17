using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Web;

namespace Housing_Project {
    public class AccountValidator {
        /// <summary>
        /// This method will test if the name the user entered in fits our credentials.
        /// </summary>
        /// <param name="firstName"> first name</param>
        /// <param name="lastName"> last name</param>
        /// <returns> Returns a string saying if the name was valid or not. </returns>
        public string ValidName(string firstName, string lastName) {
            if (firstName.Length > 0 && firstName.Length <= 50) { // Checking length so our database doesn't break.

                if (Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { // checking if only letters 

                    if (lastName.Length > 0 && lastName.Length <= 50) { // checking last name length.

                        if (Regex.IsMatch(lastName, @"^[a-zA-Z]+$")) { // checking if last name only contains letters. 
                            return "valid.";
                        }
                        else {
                            return "Last Name must only contain letters";
                        }
                    }
                    else {
                        return "Last name must be of length 1 to 50.";
                    }
                }
                else {

                    return "First name must only contain letters";
                }
            }
            else {
                return "First name length must be of length 1 to 50.";
            }
        }

        /// <summary>
        /// This method will check if the user entered phone number fits our criteria.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns> A string reporting if it was valid or not </returns>
        public string PhoneValid(string phoneNumber) {
            if (phoneNumber.Length < 12) {

                if (Regex.IsMatch(phoneNumber.ToString(), @"^[0-9]+$")) { // Checkinf if the phone number only contains numbers

                    return "Valid Number.";
                }
                else {
                    return "Number must contain only letters.";
                }
            }
            else {
                return "Phone number must be less than 12 digits.";
            }
        }

        /// <summary>
        /// Checks if the user email fits our criteria
        /// In the future we will also make sure the email has not 
        /// been used already. 
        /// </summary>
        /// <param name="email"> The email to be checked.</param>
        /// <returns>  Return string saying if it was valid or not.  </returns>
        public string ValidEmail(string email) {
            if (email.Contains("@")) { // Checking if email has an @ sign. 
                return "Valid email.";
            }
            else {
                return "Must contain an @ symbol.";
            }
        }

        /// <summary>
        /// This method will check if the username is valid and 
        /// in the future we will have logic implemented to make sure it is not a duplicate username. 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns> Return string saying if it was valid or not. </returns>
        public string ValidUserName(string userName) {
            if (userName.Length < 15) { // Checking if the length is valid
                return "Valid userName";
            }
            else {
                return "User name must be less than 15 characters.";
            }
        }

        /// <summary>
        /// This method will check if the users password is valid
        /// by checking if it contains the first or last name 
        /// and it will also check if the length is correct. 
        /// </summary>
        /// <param name="password"> password being checked. </param>
        /// <param name="firstName"> First name being used. </param>
        /// <param name="lastName"> last name being used. </param>
        /// <returns> Return string saying if it was valid or not. </returns>
        public string ValidPassword(string password, string firstName, string lastName) {
            string tempPass = password.ToLower();
            if (tempPass.Length >= 8 && tempPass.Length <= 30) { // Cbecking if the length is correct. 

                if (!tempPass.Contains(firstName.ToLower())) { // checking if the password contains first or last name. 

                    if (!tempPass.Contains(lastName.ToLower())) {
                        return "Valid Pass.";
                    }
                    else {
                        return "Password cannot contain last name";
                    }
                }
                else {
                    return "Password cannot contain first name.";
                }
            }
            else {
                return "Password length must be between 8 to 30 characters in length";
            }
        }

        /// <summary>
        /// This method will check if the income only contain numbers.
        /// </summary>
        /// <param name="income"> The income to be checked. </param>
        /// <returns> Returns a string saying if valid or not. </returns>
        public string ValidIncome(int income) {
            if (Regex.IsMatch(income.ToString(), @"^[0-9]+$")) { // Checking if income only contains numbers. 
                return "valid income";
            }
            else {
                return "Income must contain only numbers.";
            }
        }

        /// <summary>
        /// This method will check if the entered in house size is valid. 
        /// </summary>
        /// <param name="household"> The household size to be checked. </param>
        /// <returns> Return a string saying if was valid or not. </returns>
        public string ValidHouseSize(int household) {
            if (Regex.IsMatch(household.ToString(), @"^[0-9]+$")) { // Checking if only contains numbers

                if (household <= 9) { // Checking if the size is less than or equal to 9. 
                    return "Valid housing size";
                }
                else {
                    return "Housing size must be less than or equal to size of 9";
                }
            }
            else {
                return "Housing size must contain only numbers from 0 to 9";
            }
        }
    }
}