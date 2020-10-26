using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing_Project
{
    public partial class Search : Page
    {
        IncomeChecker IncomeChecker = new IncomeChecker();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //below should be put into a method into qualifer.aspx
            //that way this code is clean. Can also then interface later.
            int i = 0;
            int j = 0;
            int numCounties = 72;
            ArrayList county = new ArrayList();

            int size = int.Parse(household.Text);
            int money = int.Parse(income.Text);


            while (i < 2) //place holder because there is only 2 in system, should be numCounties
            {
                if (counties.Items[i].Selected)
                {
                    county.Add(counties.Items[i].Text);
                    j++;
                }

                i++;
            }

            String  message = IncomeChecker.Qualifier(size, money, county);
            results.Text = message;
        }

        protected void results_TextChanged(object sender, EventArgs e)
        {

        }
    }
}