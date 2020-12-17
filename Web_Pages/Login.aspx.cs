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
                
                //TextBox1.Text = result.ToString();
                string[] userInfo = Controller.UserInfo(username.Text);
                Session["User"] = userInfo;
                Response.Redirect("/Web_Pages/UserDashboard.aspx");
            }
        }
    }
}