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
            if (!IsPostBack)//!Ispostback is  a condition that you instrucitng  your page to loaded 
                            //with the same data if a button on the page is clicked. ?Usually a button redirects
                            //to another page after connecting to server
            {
                if (Session["Type"] == null || Session["Type"].ToString() != "Client")
                {
                    // Response.Write("<script> alert('you are on the wrong page, will redirect to login') </script>");
                    Response.Redirect("Login.aspx");
                }
                else
                {

                    //this page is loaded when a customer logs intot he system using the coorect username and paassword 
                    //then we may want the sign up and user login button to be invisible and instead we will show new booking, logout and welcome link

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