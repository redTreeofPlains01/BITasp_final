<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BITServicesWebAppv1._1.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div>
        <link href="StyleSheet1.css" rel="stylesheet" type="text/css" media="all" />
        <link href="fonts.css" rel="stylesheet" type="text/css" media="all" />
    </div>



    <!--apart from the top bar we want to add some more content-->
    <section>
     <div class="text-center">
        <img src="Images/bar-img.jpg" class="center-block"/>
        </div>
    </section>


    <section>
    <div class="container">
      <div class="row">
        <div class="col-12">
          <center>
            <h2>BIT Services</h2>
            <p><b>Request Service for all Information Technology Technicians</b></p>
          </center>
        </div>
      </div>
      <div class="row">


        <div class="col-md-4">
          <center>
            <img width="120px" src="Images/info.jpg" />
            <h4>About Us</h4>
            <p class="text-justify">
              Find out about our service and what we can help solve. Some of our services
                we provide is settig up worstations,
                networking, programming and general IT support.
            </p>
              
          </center>
        </div>


        <div class="col-md-4">
          <center>
            <img width="140px" src="Images/Book_service.png" />
            <h4>Request Service</h4>
            <p class="text-justify">
              Book a Technician with us for all Information Technology Issues in Hardware,
                Software and Applications for all platforms. 
            </p>
            
          </center>
        </div>


        <div class="col-md-4">
          <center>
            <img width="120px" src="Images/registeruser.jpg" />
            <h4>Register</h4>
            <p class="text-justify">
              Register with us to obtain a login account to make booking easier online. 
                Then initiate job request with your problem and we will arrage a technician.
            </p> 
          </center>
        </div>
       

      </div>
    </div>
    </section>


    <section >
    <div class="container" >
      <div class="row" id="giveSpace">

        <div class="col-md-4">
          <center>
              <a href="AboutUs.aspx" class="button button-alt">More Info</a>
          </center>
        </div>

        <div class="col-md-4">
          <center>
              <a href="Login.aspx" class="button button-alt">Request</a>
          </center>
        </div>

        <div class="col-md-4">
          <center>
              <a href="Registration.aspx" class="button button-alt">Register</a>
          </center>
        </div>

  
      </div>
    </div>
    </section>


</asp:Content>
