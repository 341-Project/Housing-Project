using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing_Project
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            string[] UserInfo = (string[])Session["User"];
            TextBox1.Text = UserInfo[1];


        }

        protected void Update_Click(object sender, EventArgs e)
        {


            int i = 0;

            ArrayList county = new ArrayList();
            int size = int.Parse(householdSize.Text);
            int money = int.Parse(income.Text);

            county.Add(County1.SelectedValue);

            if (County2.SelectedValue != "null")
            {
                county.Add(County2.SelectedValue);
            }
            if (County3.SelectedValue != "null")
            {
                county.Add(County3.SelectedValue);
            }
            string[] sessionName = (string[])Session["User"];
            results.Text = Controller.UpdateUser(firstName.Text, lastName.Text, sessionName[0], phoneNumber.Text, int.Parse(income.Text), int.Parse(householdSize.Text), county);

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void County1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void County2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void County3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void firstName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lastName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void phoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void income_TextChanged(object sender, EventArgs e)
        {

        }

        protected void householdSize_TextChanged(object sender, EventArgs e)
        {

        }
    }
}