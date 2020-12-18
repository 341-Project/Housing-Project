using System;
using System.Collections;
using System.Web.UI;

namespace Housing_Project {
    /// <summary>
    /// Create account page.
    /// Created by Matt, Hunter, and Ryan
    /// </summary>
    public partial class About : Page {

        IController testing = new Controller();

        protected void Page_Load(object sender, EventArgs e) {
        }

        /// <summary>
        /// Create a user account
        /// </summary>
        /// <param name="sender">user</param>
        /// <param name="e">on click</param>
        protected void Button1_Click(object sender, EventArgs e) {
            int i = 0;

            ArrayList county = new ArrayList();
            int size = int.Parse(household.Text);
            int money = int.Parse(income.Text);

            county.Add(County1.SelectedValue);
                county.Add(County2.SelectedValue);
                county.Add(County3.SelectedValue);
    
            results.Text = testing.CreateUser(fName.Text, lName.Text, phone.Text, email.Text, user.Text, password.Text, money, "Renter", size, county);
            string[] userInfo = testing.UserInfo(user.Text);
            Session["User"] = userInfo;
            //Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e) {

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e) {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e) {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e) {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e) {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e) {

        }

        protected void County1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void County2_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void County3_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}