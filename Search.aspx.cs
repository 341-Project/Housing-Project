using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing_Project
{
    public partial class Search : Page
    {
        private IncomeChecker IncomeChecker = new IncomeChecker();

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
            //int numCounties = 72;

            ArrayList county = new ArrayList();

            int size = int.Parse(household.Text);
            int money = int.Parse(income.Text);

            while (i < 2) //place holder because there is only 2 in system, should be numCounties
            {
                if (counties.Items[i].Selected)
                {
                    county.Add(counties.Items[i].Text);
                }

                i++;
            }

            DIV1.InnerHtml = Controller.Search(size, money, county);

        }

        protected void results_TextChanged(object sender, EventArgs e)
        {
        }
    }
}