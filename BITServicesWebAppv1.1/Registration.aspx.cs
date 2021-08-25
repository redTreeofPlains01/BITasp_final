using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BITServicesWebAppv1._1;
/*Date 2/09/2020: UC103: Extend the Add Customer to DB to check if the email address used for Registration is registered with Fast Drivers*/

namespace BITServicesWebAppv1._1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //this is where we will take the data from the ASP.Net/HTML Form
            //and add that data as a new client to our database
            //In syntax of C#
            //Client class having a addnewClient() method that then
            //connects to sqlhelper class and adds a new record to the database
            //DateTime dob = DateTime.ParseExact(txtDOB.Text.Trim(), "yyyy-MM-dd", null);
            Client newClient = new Client()
            {
                FirstName = txtFName.Text,
                LastName = txtLName.Text,
                DOB = Convert.ToDateTime(txtDOB.Text),
                Phone = txtContact.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text,
                Suburb = txtSuburb.Text,
                PostCode = txtPostCode.Text,
                State = ddlState.SelectedValue,
            };
            int returnValue = newClient.InsertClient();
            if (returnValue >= 1)
            {
                Response.Write("Client  inserted to DB!");
            }
            else
            {
                Response.Write("Could not Sign up the Client !!!");
            }


        }
    }
}