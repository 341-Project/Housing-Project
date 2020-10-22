using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing_Project
{
    class IncomeChecker
    {
        public string Qualifier(int household, int income)
        {
            string pass = "pass";
            string fail = "fail";

            if (household == 1)
            {
                if (income <= 45000)
                {
                    return pass;
                }
                else
                {
                    return fail;
                }
            }
            else
            {
                return fail;
            }
        }
    }
}