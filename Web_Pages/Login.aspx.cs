using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Login page
/// Created by Ryan, Hunter, and Matt
/// </summary>
namespace Housing_Project {
    public partial class WebForm1 : System.Web.UI.Page {

        IController testing = new Controller();

        protected void Page_Load(object sender, EventArgs e) {

        }
        /// <summary>
        /// Checks for user to Login
        /// </summary>
        /// <param name="sender">User</param>
        /// <param name="e">on click</param>
        protected void Button1_Click(object sender, EventArgs e) {
           int result = testing.LoginUser(username.Text, password.Text);
            if (result == 1) {
                
                //TextBox1.Text = result.ToString();
                string[] userInfo = testing.UserInfo(username.Text);
                Session["User"] = userInfo;
                Response.Redirect("/Web_Pages/UserDashboard.aspx");
            }
        }
    }
}