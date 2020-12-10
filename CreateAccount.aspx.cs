using System;
using System.Collections;
using System.Web.UI;

namespace Housing_Project
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            ArrayList county = new ArrayList();
            int size = int.Parse(household.Text);
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

            results.Text = Controller.CreateUser(fName.Text, lName.Text, phone.Text, email.Text, user.Text, password.Text, money, "Renter", size, county);
            string[] userInfo = Controller.UserInfo(user.Text);
            Session["User"] = userInfo;
            Response.Redirect("Search.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

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
    }
}