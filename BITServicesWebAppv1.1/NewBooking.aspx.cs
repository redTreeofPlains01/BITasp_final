using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITServicesWebAppv1._1
{
    public partial class NewBooking : System.Web.UI.Page
    {
        DataTable availableSessions;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calBookDate.SelectedDate = DateTime.Now.Date;

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
                    lnkWelcome.Visible = false;
                    LinkButton lnkLogout = (LinkButton)Master.FindControl
                        ("lbtnLogout");
                    lnkLogout.Visible = true;
                }
            }
            SQLHelper helper = new SQLHelper();
            string sql = "select skillname from Skills";
            ddlSkill.DataSource = helper.ExecuteSQL(sql);
            ddlSkill.DataBind();
            ddlSkill.DataTextField = "skillname"; //$$_what the user sees e.g skill name
            //you normally want your users to see the skill name and your program to consider their respective skill id that is why DataTextField should be skill name 
            //Datavalue field should be skillid so when you use selected value property of the dropdownlist you get the skillid no the skillname
            ddlSkill.DataValueField = "skillname";  //skillid 
            ddlSkill.DataBind();


            /*   <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="NSW" Value="NSW" />
                                        <asp:ListItem Text="ACT" Value="ACT" />
                                        <asp:ListItem Text="WA" Value="WA" />
                                        <asp:ListItem Text="QLD" Value="QLD" />
                                        <asp:ListItem Text="TAS" Value="TAS" />
                                        <asp:ListItem Text="NT" Value="NT" />
                                        <asp:ListItem Text="VIC" Value="VIC" />
                                        <asp:ListItem Text="SA" Value="SA" /> */


            /*< asp:DropDownList CssClass = "form-control" ID = "ddlState"
                                        runat = "server" >


                                    </ asp:DropDownList >*/
        }
        /*(userStory)US: As a client I should be able to key in my requirements for booking a 
         * new lesson and be able to search for all sessions available and be able to work out a way 
         * to select one of them so that I can book a lesson online rather than calling or going to 
         * the office physically*/
        protected void btnFindSessions_Click(object sender, EventArgs e)
        {

            //this is where we need to retirvce the data from the dartabase for all the available 
            //sessions based on starttime, data and suburb
            //1.StartTime is in Timeslot, date is in availability and suburb is in preferred suburb
            if(calBookDate.SelectedDate == null || ddlJobStartTime.SelectedValue == ""
                || ddlJobEndTime.SelectedValue == ""
                || txtSuburb.Text == "")
            {
                Response.Write("<script> alert('Select date, time and pickup address') </script>");
            }
            else
            {
                //First we tested all our code as code behind and then
                //we used Extract Class Refactoring strategy to encapsulate the query to a separate class

                //??DataTable -yes declared up top
                //$$$New  Booking and re-booking------FOR BIT----Here it will be start time, end time skills parameters
                availableSessions = AvailableSessions.GetAllAvailableSessions
                    (calBookDate.SelectedDate, ddlJobStartTime.SelectedValue, 
                    ddlJobEndTime.SelectedValue, ddlSkill.SelectedValue);
                gvAvailableSessions.DataSource = availableSessions;
                //$_gvAvailableSessions id ID for GridView in NewBooking.aspx
                gvAvailableSessions.DataBind();
            }
        }

        private void RefreshAllAvailableSessionsDataGrid(DateTime date, string jobstarttime,
            string jobendtime, string skillname)
        {
            /*string sqlStr = "SELECT co.contractorid, co.firstname, co.lastname, a.weekdayname, " +
                "a.starttime, " +
            "cs.skillname " +
            "FROM Availability a, Contractor co, ContractorSkills cs " +
            "WHERE a.contractorid = co.contractorid " +
            "AND  co.contractorid = cs.contractorid " +
            "AND a.weekdayname = DATENAME(DW, " +
            date.ToString("yyyy-MM-dd") +
            ") AND a.starttime >=" + jobstarttime +
            "AND a.finishtime <=" + jobendtime +
             " AND cs.skillname =" + skillname;*/


            /*string sqlStr = "SELECT t.timeslotid, t.starttime, a.availabilityid, " +
                "c.contractorid, a.availableDate, c.firstname, c.lastname "

                         + "FROM TimeSlot t, Availability a, Contractor c, PreferredSuburbs ps "

                         + "WHERE t.timeslotid = a.timeslotid AND c.contractorid = a.contractorid "

                         + "AND ps.contractorid = c.contractorid AND a.availableDate = '"

                         + date.ToString("yyyy-MM-dd") + "' AND t.starttime = '"

                         + time + "' AND ps.suburb = '" + suburb + "' and a.status = 'Available'";*/

            SQLHelper objhelper = new SQLHelper();
            availableSessions = AvailableSessions.GetAllAvailableSessions
                   (calBookDate.SelectedDate, ddlJobStartTime.SelectedValue,
                    ddlJobEndTime.SelectedValue, ddlSkill.SelectedValue);
            gvAvailableSessions.DataSource = availableSessions;
            //$_gvAvailableSessions id ID for GridView in NewBooking.aspx
            gvAvailableSessions.DataBind();

        }

        protected void gvAvailableSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                //then this row should be confirmed as a booked session for the client
                //whose ID is stored in Session Variable Session["ClientID"]
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvailableSessions.Rows[rowIndex];

                //co.contractorid, co.firstname, co.lastname, a.weekdayname, " +"a.starttime, a.finishtime "
                //"cs.skillname

                /*string sql = "insert into JobBooking(contractorid, jobbookingdate, jobstarttime, " +
                    "jobendtime, clientid, jobdescription, " +
                    "status, kilometers, skillname) values('" + Convert.ToInt32(row.Cells[1].Text) + "', '" +
                    (calBookDate.SelectedDate).ToString("yyyy-MM-dd") + "' , '" 
                    + ddlJobStartTime.SelectedValue + "' , '" +
                    ddlJobEndTime.SelectedValue + "' , '" +
                    Convert.ToInt32(Session["ClientID"]) + "' , '"
                    + txtJobDescription.Text + "' ," +
                    "'TBC', 0, '" +  ddlSkill.SelectedValue +   "')";*/


                /*string sql = "insert into Booking(availabilityid, clientid, address, suburb, postcode, state, " +
                    "status,kilometers) values(" + Convert.ToInt32(row.Cells[3].Text) + ", " +
                    Convert.ToInt32(Session["ClientID"]) + " , '" + txtAddress.Text + "' , '" + txtSuburb.Text
                    + "' , '" + txtPostCode.Text + "' , '" + ddlState.SelectedValue.ToString() + "' , 'booked', 0)";*/


                /*SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(sql); //this is adding a new booking row to the booking table


                string sqlStr2 = "insert into Location(clientid, address, " +
                "suburb, postcode," +
                 " state, phone_no) values('" + Convert.ToInt32(Session["ClientID"]) + "', '" +
                 txtAddress.Text + "', '"
                 + txtSuburb.Text + "', '" + txtPostCode.Text + "', '" +
                 ddlState.SelectedValue + "', 'TBC') ";

                helper.ExecuteNonQuery(sqlStr2);*/

                SQLHelper objHelper = new SQLHelper();
                SqlParameter[] objParams = new SqlParameter[11];
                objParams[0] = new SqlParameter("@clientid", DbType.Int32);
                objParams[0].Value = Convert.ToInt32(Session["ClientID"]);
                objParams[1] = new SqlParameter("@address", DbType.String);
                objParams[1].Value = txtAddress.Text;
                objParams[2] = new SqlParameter("@suburb", DbType.String);
                objParams[2].Value = txtSuburb.Text;
                objParams[3] = new SqlParameter("@postcode", DbType.String);
                objParams[3].Value = txtPostCode.Text;
                objParams[4] = new SqlParameter("@state", DbType.String);
                objParams[4].Value = ddlState.SelectedValue;
                objParams[5] = new SqlParameter("@contractorid", DbType.Int32);
                objParams[5].Value = Convert.ToInt32(row.Cells[1].Text);
                objParams[6] = new SqlParameter("@jobbookingdate", DbType.DateTime);
                objParams[6].Value = (calBookDate.SelectedDate).ToString("yyyy-MM-dd");
                objParams[7] = new SqlParameter("@jobstarttime", DbType.Time);
                objParams[7].Value = ddlJobStartTime.SelectedValue;
                objParams[8] = new SqlParameter("@jobendtime ", DbType.Time);
                objParams[8].Value = ddlJobEndTime.SelectedValue;
                objParams[9] = new SqlParameter("@jobdescription", DbType.String);
                objParams[9].Value = txtJobDescription.Text;
                objParams[10] = new SqlParameter("@skillname", DbType.String);
                objParams[10].Value = ddlSkill.SelectedValue;

                objHelper.ExecuteSQL("AddNewLocAndBooking", objParams, true);


                //this query will make the driver unavailable for another session

                /*string sqlStr3 = "SELECT Max(locationid) FROM Location";
                DataTable maxlocationIDNew = new DataTable();
                maxlocationIDNew = helper.ExecuteSQL(sqlStr3);
                int id1=0;

                foreach (DataRow dr in maxlocationIDNew.Rows)
                {
                    id1 = Convert.ToInt32(dr[0]);
                }

                string sqlStr4 = "SELECT Max(jobbookingid) FROM JobBooking";
                DataTable maxJobBookingIDNew = new DataTable();
                maxJobBookingIDNew = helper.ExecuteSQL(sqlStr4);
                int id2= 0;

                foreach (DataRow dr in maxJobBookingIDNew.Rows)
                {
                    id2 = Convert.ToInt32(dr[0]);
                }
                    //int id2 = Convert.ToInt32(maxJobBookingIDNew.Rows[0][0]);

                string sqlStr5 = "insert into JobBooking(locationid) values(" + id1 + ") " +
                    "where jobbookingid = "  + id2;
                helper.ExecuteNonQuery(sqlStr4);*/

                //$$$oriogional code
                //RefreshAllAvailableSessionsDataGrid(calBookDate.SelectedDate, ddlJobStartTime.SelectedValue,
                //ddlJobEndTime.SelectedValue, ddlSkill.SelectedValue);

                Response.Redirect("currentbookings.aspx");

            }
        }
            //only date and string require single quotations in sql
    }
}