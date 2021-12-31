using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITServicesWebAppv1._1
{
    //Client Landing Page
    public partial class currentbookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Type"] == null || Session["Type"].ToString() != "Client")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LinkButton lnkBooking = (LinkButton)Master.FindControl("lbtnNewBooking");
                    lnkBooking.Visible = true;
                    LinkButton lnkUserLogin = (LinkButton)Master.FindControl("lbtnLogin");
                    lnkUserLogin.Visible = false;
                    LinkButton lnkSignUp = (LinkButton)Master.FindControl
                        ("lbtnSignUp");
                    lnkSignUp.Visible = false;
                    LinkButton lnkWelcome = (LinkButton)Master.FindControl("lbtnWelcome");
                    lnkWelcome.Visible = true;
                    LinkButton lnkLogout = (LinkButton)Master.FindControl
                        ("lbtnLogout");
                    lnkLogout.Visible = true;

                    int clientId = Convert.ToInt32(Session["ClientID"].ToString());
                    
                    string sqlStr = "select jb.jobbookingdate,  jb.jobstarttime, " +
                        "jb.jobendtime, l.Address, l.suburb, co.firstname , co.lastname, " +
                        "jb.status, jb.skillname from location l, contractor co, jobbooking jb " +
                        "where l.locationid = jb.locationid " +
                        "and jb.contractorid = co.contractorid and jb.clientid = " +
                        clientId;
                    
                    /*string sqlStr = "select a.availableDate, t.starttime, c.firstname, c.lastname, " 
                        + "b.jobaddress, b.jobsuburb, b.jobpostcode, b.state, b.status " +
                        "from availability a, " + " timeslot t, contractor c, jobbooking b " +
                        "where a.availabilityid = b.availabilityid " + 
                        " and t.timeslotid = a.timeslotid " +
                        "and c.contractorid = a.contractorid " +
                        "and " + "b.clientid = " + clientId;*/

                    SQLHelper objHelper = new SQLHelper();
                    gvCurrentBookings.DataSource = objHelper.ExecuteSQL(sqlStr);
                    gvCurrentBookings.DataBind();
                    
                }
            }
        }
    }
}