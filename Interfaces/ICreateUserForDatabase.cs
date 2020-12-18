using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_Project {
    public interface ICreateUserForDatabase {
        string CreateUser(string firstName, string lastName, string phoneNumber, string email,
                                        string userName, string password, int income, string typeOfUser, int householdSize, ArrayList county);

        int LoginUser(string username, string password);

        string[] UserInfo(string username);

        string UpdateUser(string firstName, string lastName, string username, string phoneNumber,
                                        int income, int householdSize, ArrayList county);

        

    }
}
