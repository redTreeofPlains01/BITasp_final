using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITServicesWebAppv1._1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            //should redirect the page to login.aspx
            //rememeber we are on code-behind page meaning we will nned to write a 
            //line of code that redirects to login.aspx using c# syntax used in asp.net
            //response is an asp.net object used when ever you want asp.net to respond to a request- in 
            Response.Redirect("Login.aspx");
        }

        protected void lbtnNewBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewBooking.aspx");
        }
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            //should redirect the page to login.aspx
            //rememeber we are on code-behind page meaning we will nned to write a 
            //line of code that redirects to login.aspx using c# syntax used in asp.net
            //response is an asp.net object used when ever you want asp.net to respond to a request- in 
            Response.Redirect("HomePage.aspx");
        }
        

    }
}