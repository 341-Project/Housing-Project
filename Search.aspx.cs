using System;
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
            int household = 1;
            int income = 5;


            String  message = IncomeChecker.Qualifier(household, income);
            results.Text = message;
        }

        protected void results_TextChanged(object sender, EventArgs e)
        {

        }
    }
}