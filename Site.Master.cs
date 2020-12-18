using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Housing_Project {
    public partial class SiteMaster : MasterPage {

        public void Page_Load(object sender, EventArgs e) {
            HtmlGenericControl login = new HtmlGenericControl("displayLogin");
            HtmlGenericControl create = new HtmlGenericControl("displayCreate");
            HtmlGenericControl dashboard = new HtmlGenericControl("displayDashboard");
            HtmlGenericControl logout = new HtmlGenericControl("logout");

            if (Session["User"] != null) {
                login.Attributes["class"] = "dontDisplay";
                create.Attributes["class"] = "dontDisplay";
                dashboard.Attributes["class"] = "display";
            }
            else {
                login.Attributes["class"] = "display";
                create.Attributes["class"] = "display";
                dashboard.Attributes["class"] = "dontDisplay";

            }

        }

        public void EndSession() {
            Session["User"] = null;
        }
    }
}