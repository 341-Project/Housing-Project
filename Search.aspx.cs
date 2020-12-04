using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing_Project
{
    public partial class Search : Page
    {

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

            ArrayList county = new ArrayList();

            int size = int.Parse(household.Text);
            int money = int.Parse(income.Text);

            county.Add(County1.SelectedValue);
            county.Add(County2.SelectedValue);
            county.Add(County3.SelectedValue);

            DIV1.InnerHtml = Controller.Search(size, money, county);

        }

        protected void results_TextChanged(object sender, EventArgs e)
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