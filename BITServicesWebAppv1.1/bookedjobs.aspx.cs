using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITServicesWebAppv1._1
{
    public partial class bookedjobs : System.Web.UI.Page
    {
        ////Contractor Landing Page
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Type"] == null || Session["Type"].ToString() != "Contractor")
                {
                   
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

                    int contractorId = Convert.ToInt32(Session["ContractorID"].ToString());
                    string sqlStr = "select jb.jobbookingid, jb.jobBookingDate, jb.jobstarttime, " +
                        "jb.jobendtime, l.address, l.suburb, l.postcode, l.state, jb.status, " +
                        "jb.skillname from location l, JobBooking jb " +
                        "where jb.locationid = l.locationid and jb.contractorid = " + contractorId;

                    SQLHelper objhelper = new SQLHelper();
                    gvBookedSessions.DataSource = objhelper.ExecuteSQL(sqlStr);
                    gvBookedSessions.DataBind();
                    RefreshBookedDataGrid();
                    RefreshAcceptedDataGrid(); ;
                }
            }
        }


        private void RefreshBookedDataGrid()
        {
            int contractorId = Convert.ToInt32(Session["ContractorID"].ToString());

            string sqlStr = "select jb.jobbookingid, jb.jobBookingDate, jb.jobstarttime, " +
                        "jb.jobendtime, l.address, l.suburb, l.postcode, l.state, jb.status, " +
                        "jb.skillname from location l, JobBooking jb " +
                        "where jb.locationid = l.locationid and jb.contractorid = " + contractorId
                        + " and jb.status = 'TBC'";
            /*string sqlStr = "select jb.jobbookingid, a.availableDate, t.starttime,  " +
                " jb.jobaddress, jb.jobsuburb, jb.jobpostcode, jb.state, jb.status from availability a, " +
                " timeslot t, contractor c, jobbooking jb  where a.availabilityid = jb.availabilityid " +
                " and t.timeslotid = a.timeslotid and c.contractorid = a.contractorid and " +
                "c.contractorid  = " + contractorId + " and jb.status = 'booked'";*/

            SQLHelper objhelper = new SQLHelper();
            gvBookedSessions.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvBookedSessions.DataBind();
        }

        private void RefreshAcceptedDataGrid()
        {
            int contractorId = Convert.ToInt32(Session["ContractorID"].ToString());
            string sqlStr = "select jb.jobbookingid, jb.jobBookingDate, jb.jobstarttime, " +
                        "jb.jobendtime, l.address, l.suburb, l.postcode, l.state, jb.status, " +
                        "jb.skillname from location l, JobBooking jb " +
                        "where jb.locationid = l.locationid and jb.contractorid = " + contractorId
                        + " and jb.status = 'Confirmed'";

            /*string sqlStr = "select jb.jobbookingid, a.availableDate, t.starttime,  " +
               " jb.jobaddress, jb.jobsuburb, jb.jobpostcode, jb.state, jb.status from availability a, " +
               " timeslot t, contractor c, jobbooking jb  where a.availabilityid = jb.availabilityid " +
               " and t.timeslotid = a.timeslotid and c.contractorid = a.contractorid and " +
               "c.contractorid  = " + contractorId + " and jb.status = 'Accepted'";*/

            SQLHelper objhelper = new SQLHelper();
            gvAcceptedSessions.DataSource = objhelper.ExecuteSQL(sqlStr);
            gvAcceptedSessions.DataBind();
        }

        protected void gvAcceptedSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if e.CommandName is Complete then...update the status of that booking id to "Completetd" and update the number of kilometers to what ahas been typed in that textbox

            if (e.CommandName == "Complete")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAcceptedSessions.Rows[rowIndex];

                int kilometers = Convert.ToInt32(((TextBox)row.FindControl("txtKilometers")).Text.Trim());

                string updatesql = "update JobBooking set status = 'Completed', kilometers = " + kilometers +

                    " where jobbookingid = "
                    + Convert.ToInt32(row.Cells[2].Text);


                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(updatesql); //this query will make the driver unavailable for another 
                                                   //session
                RefreshAcceptedDataGrid();
            }
        }


        protected void gvBookedSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.CommandName == "Accept")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvBookedSessions.Rows[rowIndex];

                    string updatesql = "update JobBooking set status = 'Confirmed' where jobbookingid = "
                        + Convert.ToInt32(row.Cells[2].Text);
                    SQLHelper helper = new SQLHelper();
                    helper.ExecuteNonQuery(updatesql); //this query will make the driver unavailable for another session
                    RefreshBookedDataGrid();
                    RefreshAcceptedDataGrid();
                }
                else if (e.CommandName == "Reject")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = gvBookedSessions.Rows[rowIndex];

                    string updatesql = "update JobBooking set status = 'Rejected' where jobbookingid = "
                        + Convert.ToInt32(row.Cells[2].Text);
                    SQLHelper helper = new SQLHelper();
                    helper.ExecuteNonQuery(updatesql); //this query will make the driver unavailable for another 
                                                       //session
                    RefreshBookedDataGrid();
                    int contractorId = Convert.ToInt32(Session["ContractorID"].ToString());
                    string insertsql = "insert into RejectedBooking values( " + contractorId + " , " 
                        + Convert.ToInt32(row.Cells[2].Text) + ", 'Rejected', '" 
                        + DateTime.Today.ToString("yyyy-MM-dd") + "')";
                    helper.ExecuteNonQuery(insertsql);

                    RefreshBookedDataGrid();
                    
                    //My assumptionUS : As a staff I should be able to see all the rejected session that I can rebook them again with other driver making sure that the drivers that come up with my search do not include the drivers who has rejected that session earlier so that I can provide better booking management
                }
            }
        }
    }
}