using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITServicesWebAppv1._1
{//Staff Landing page
    public partial class allbookedjobs : System.Web.UI.Page
    {
        DataTable availableSessions;
        int jobbookingid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//!IsPostBack is a condition that you instructing your page to be loaded with the same
                            //data if a button on the page is clicked
            {
                if (Session["Type"] == null || Session["Type"].ToString() != "Staff"
                    || Session["StaffID"].ToString() == null)
                {
                    // Response.Write("<script> alert('you are on the wrong page, will redirect to login') </script>");
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LinkButton lnkUserLogin = (LinkButton)Master.FindControl("lbtnLogin");
                    lnkUserLogin.Visible = false;
                    LinkButton lnkSignUp = (LinkButton)Master.FindControl("lbtnSignUp");
                    lnkSignUp.Visible = false;
                    LinkButton lnkWelcome = (LinkButton)Master.FindControl("lbtnWelcome");
                    lnkWelcome.Visible = true;
                    LinkButton lnkLogout = (LinkButton)Master.FindControl("lbtnLogout");
                    lnkLogout.Visible = true;

                    LoadAllJobBookings();
                    LoadCompletedJobBookings();
                    LoadRejectedJobBookings();
                }
            }
        }
        private void LoadAllJobBookings()
        {
            string sqlStr = "select jb.jobbookingid, jb.jobbookingDate, jb.jobstarttime, jb.jobendtime, " +
                "cl.firstname as ClientFirstName, cl.lastname as ClientLastName, co.firstname" +
                " as ContractorFName, co.lastname as ContractorLName, " +
                "l.address, l.suburb, l.postcode, l.state, jb.status, jb.skillname " +
                "from Location l, contractor co, jobbooking jb, Client cl " +
                "where l.locationid = jb.locationid " +
                "and co.contractorid = jb.contractorid " +
                "and cl.clientid = jb.clientid ";
            SQLHelper objhelper = new SQLHelper();
            gvAllJobBookings.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvAllJobBookings.DataBind();
        }
        private void LoadCompletedJobBookings()
        {
            string sqlCompleted = "select jb.jobbookingid, jb.jobbookingDate, jb.jobstarttime, jb.jobendtime, " +
                "cl.firstname as ClientFirstName, cl.lastname as ClientLastName, co.firstname" +
                " as ContractorFName, co.lastname as ContractorLName, " +
                "l.address, l.suburb, l.postcode, l.state, jb.status, jb.skillname " +
                "from Location l, contractor co, jobbooking jb, Client cl " +
                "where l.locationid = jb.locationid " +
                "and co.contractorid = jb.contractorid " +
                "and cl.clientid = jb.clientid " +
                "and jb.status='Completed'";
            SQLHelper objhelper = new SQLHelper();
            gvCompletedJobBookings.DataSource = objhelper.ExecuteSQL(sqlCompleted);
            gvCompletedJobBookings.DataBind();

        }
        private void LoadRejectedJobBookings()
        {
            string sqlRejected = "select jb.jobbookingid, jb.jobbookingDate, jb.jobstarttime, jb.jobendtime, " +
                "cl.firstname as ClientFirstName, cl.lastname as ClientLastName, co.firstname" +
                " as ContractorFName, co.lastname as ContractorLName, " +
                "l.address, l.suburb, l.postcode, l.state, jb.status, jb.skillname " +
                "from Location l, contractor co, jobbooking jb, Client cl " +
                "where l.locationid = jb.locationid " +
                "and co.contractorid = jb.contractorid " +
                "and cl.clientid = jb.clientid " +
                "and jb.status='Rejected'";


            SQLHelper objhelper = new SQLHelper();
            gvRejectedJobBookings.DataSource = objhelper.ExecuteSQL(sqlRejected);
            gvRejectedJobBookings.DataBind();

        }
        protected void gvCompletedJobBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //update the Bookings table for that bookingid to change the status
            //to "Verified"
            if (e.CommandName == "Verify")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCompletedJobBookings.Rows[rowIndex];
                string updatesql = "update jobbooking set status = 'Verified' " +
                    " where jobbookingid = " + Convert.ToInt32(row.Cells[1].Text);
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql);
                LoadCompletedJobBookings();
            }
        }
        protected void gvRejectedJobBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //on the click of any button on this grid will redirect the 
            //a new page that will list all the available sessions for 
            //available date, starttime and pick up address
            if (e.CommandName == "ReBook")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvRejectedJobBookings.Rows[rowIndex];
                jobbookingid = Convert.ToInt32(row.Cells[1].Text); 
                availableSessions =
                        AvailableSessions.GetAllAvailableSessions
                        (Convert.ToDateTime(row.Cells[2].Text), row.Cells[3].Text,
                        row.Cells[4].Text, row.Cells[14].Text);
                gvAvailableSessions.DataSource = availableSessions;
                gvAvailableSessions.DataBind();
            }
        }
        protected void gvAvailableSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //exactly like in newBooking.cs 
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvailableSessions.Rows[rowIndex];
                string updatesql = "update JobBooking set contractorid = " + Convert.ToInt32(row.Cells[1].Text)
                    + ", status = 'TBC' where jobbookingid = " + jobbookingid;
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql);
                //string updatesql1 = "update Availability set status = 'NA' where availabilityid = "
                //    + Convert.ToInt32(row.Cells[3].Text);
                //helper.ExecuteNonQuery(updatesql1);
                LoadAllJobBookings();
                LoadRejectedJobBookings();
                LoadCompletedJobBookings();
            }

        }











        /*protected void Page_Load(object sender, EventArgs e)
        {
            string sqlStr = "select jb.jobbookingDate, jb.jobstarttime, jb.jobendtime, " +
                "cl.firstname as ClientFirstName, cl.lastname as ClientLastName, co.firstname" +
                " as ContractorFName, co.lastname as ContractorLName, " +
                "l.address, l.suburb, l.postcode, l.state, jb.status, jb.skillname " +
                "from Location l, contractor co, jobbooking jb, Client cl " +
                "where l.locationid = jb.locationid " +
                "and co.contractorid = jb.contractorid " +
                "and cl.clientid = jb.clientid ";*/

        /*string sqlStr = "select a.availableDate, t.starttime, cl.firstname as ClientFirstName, cl.lastname as ClientLastName, c.firstname, c.lastname, " +
            " jb.jobaddress, jb.jobsuburb, jb.jobpostcode, jb.state, jb.status from availability a, " +
            " timeslot t, contractor c, jobbooking jb, Client cl where a.availabilityid = jb.availabilityid " +
            " and t.timeslotid = a.timeslotid and c.contractorid = a.contractorid" + " and cl.clientid = jb.clientid";*/

        /*SQLHelper objhelper = new SQLHelper();
            gvAllBookings.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvAllBookings.DataBind();
        }*/
    }
}