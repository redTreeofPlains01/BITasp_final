using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
/*This is login page for Fastdrivers is the entry point for the stakeholders and Customer, satff, instructors/drivers
--To begin with bgin thsi logon page to work only with customer
Assume: username is email and passwords are stored in the same table for customer
Please do not use ID's as a username(not safe)
*/


namespace BITServicesWebAppv1._1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /*Client c = new Client();
            c.Email = txtUsername.Text;
            c.Password = txtPassword.Text;
            CustomError.ReadAllCustomers(c.Email, c.Password);*/
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //controllled redundancy -De-normalaisation : one of the biggest de normalisation process in development is getting rid of the 1:1 relatiosnship
            //Assumption: yes a Customer can be an instructor but when they are instructors they have comapines email used as a username//if they are customers they use their personal emails to log in -that means at a time only one table will have the data
            /*string sql = "select clientid, email from Client where email = '" + c.Email + "' and " + "password = '" + c.Password +"'";*/
            string sqlClient = "select clientid, email from Client where email = '" + username + "' and " + "password = '" + password + "'";
            SQLHelper helper = new SQLHelper();
            DataTable clientRecordsRead = helper.ExecuteSQL(sqlClient);
            //int id = Convert.ToInt32(recordsRead.Rows[0]);- for FD_User get this id and compare in subtables and then redirect to appropraite pafe depesning on user type 2.28.40



            if (clientRecordsRead.Rows.Count >= 1)//means login details are from customer
            { int clientid = Convert.ToInt32(clientRecordsRead.Rows[0][0].ToString());
                //when currentbookings.cs is redirected we are not
                //passing the customerid from here to the next page
                //Web is Stateless, we want to add the state
                //to determine who is logged in
                //QueryString is the easiest way to pass data between
                //two pages : HTML -> ASPX or ASPX -> ASPX because
                //QueryString is an ASP.NET Object
                //like Response, Request
                //pagename.ext?sessionid=ojheroiwerj8343&username=98247kljsdflkjkf
                //no limitations on how much you can pass as a querystring (QueryString
                //in ASP.NET is a collection of (data, value ) pair
                //the only issue is if you are thinking of passing a particular data
                //between multiple pages then you need to keep on passing this value again and again
                //for all other pages

                //Remeber session is acti=uially a Collection at the server level so keep on adding as many sessions as you need it
                //First parameter to Add() is a string and acts as a key//and next parameter is an object a value to that key
                Session.Add("ClientID", clientid);
                Session.Add("Type", "Client");
                //you may have to work out a way to add a row in transaction table with the time they
                //logged in 
                Response.Redirect("currentbookings.aspx");
            }
            else 
            {
                string sqlContractor = "select contractorid, email from Contractor where email = '" + username + "' and " + "password = '" + password + "'";

                DataTable contractorRecordsRead = helper.ExecuteSQL(sqlContractor);



                if (contractorRecordsRead.Rows.Count >= 1)//means login details are from contractor
                {
                    int contractorid = Convert.ToInt32(contractorRecordsRead.Rows[0][0].ToString());
                    Session.Add("ContractorID", contractorid);
                    Session.Add("Type", "Contractor");
                    //Remeber session is acti=uially a Collection at the server level so keep on adding as many sessions as you need it
                    //First parameter to Add() is a string and acts as a key//and next parameter is an object a value tot hat key
                    Response.Redirect("bookedjobs.aspx");
                }else
                    {
                        string sqlStaff = "select staffid, email from Staff where email = '" + username + "' and " + "password = '" + password + "'";

                        DataTable staffRecordsRead = helper.ExecuteSQL(sqlStaff);



                        if (staffRecordsRead.Rows.Count >= 1)//means login details are from contractor
                        {
                            int staffid = Convert.ToInt32(staffRecordsRead.Rows[0][0].ToString());
                            Session.Add("StaffID", staffid);
                            Session.Add("Type", "Staff");
                            //Remeber session is acti=uially a Collection at the server level so keep on adding as many sessions as you need it
                            //First parameter to Add() is a string and acts as a key//and next parameter is an object a value tot hat key
                            Response.Redirect("allbookedjobs.aspx");
                        }
                        else //in future you will also be checking if the staff has logged 
                        {
                            Response.Write("alert(username or password incorrect");
                        }
                    }


            }


                /*
                 * Case if Sqlhelper is not constructed-connect each time
                _conn = ConfigurationManager.ConnectionStrings["BS"].ConnectionString;
                SqlConnection dbConnection = new SqlConnection(_conn);
                DataTable dataTable = new DataTable();  //SqlCommand in SqlClinet language
                string username = txtUsername.Text;
                string password = txtPassword.Text; 
                string sql = "select email from Customer where email = '" + username + "' and " + "password = '" + password +"'";
                //option you can use simple adapter to execute the command:
                    SqlDataAdapter adap = new SqlDataAdapter(dbCommand);

                SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
                dbConnection.Open();
                SqlDataReader drResults = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                dataTabel.Load(drResults);
                 if(recordsRead.Rows.Count >=1)
                {
                    Response.Redirect("currentbookings.aspx");
                }
                */


            
        }

    } 
    
    
}