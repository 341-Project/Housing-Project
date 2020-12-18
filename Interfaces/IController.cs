using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing_Project {
    public interface IController {
        string Search(int household, int income, ArrayList county);

        string CreateUser(string firstName, string lastName, string phoneNumber, string email,
                                        string userName, string password, int income, string typeOfUser, int householdSize, ArrayList county);

        int LoginUser(String userName, string password);

        string[] UserInfo(string user);

        string UpdateUser(string firstName, string lastName, string username, string phoneNumber,
                                        int income, int householdSize, ArrayList county);
    }
}
