using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           int result = Controller.LoginUser(username.Text, password.Text);
            if (result == 1)
            {
                Response.Redirect("UserDashboard.aspx");
                TextBox1.Text = result.ToString();
                Session["User"] = "User";
            }
            else
            {
                TextBox1.Text = result.ToString();
            }
        }
    }
}