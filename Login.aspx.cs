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
            /*
            string firstName = fName.Text;
            string lastName = lName.Text;
            
            string emailaddress = email.Text;
            string userAddress = address.Text;
            string username = user.Text;
            string userPass = password.Text;
            string userIncome = income.Text;
            string userHousehold = household.Text;
            */
            int size = int.Parse(household.Text);
            int money = int.Parse(income.Text);
            //int phoneUser = int.Parse(phone.Text);

            while (i < 2) //place holder because there is only 2 in system, should be numCounties
            {
                if (counties.Items[i].Selected)
                {
                    county.Add(counties.Items[i].Text);
                }

                i++;
            }


            county.Add(null);
            county.Add(null);

            results.Text = Controller.CreateUser(fName.Text, lName.Text, phone.Text, email.Text, user.Text, password.Text, money, "Renter", size, county);
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
    }
}