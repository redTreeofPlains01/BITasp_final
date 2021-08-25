<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BITServicesWebAppv1._1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="Images/member.jpg"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Member Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Member ID</label>
                        <div class="form-group">
                           <!--asp: Textbox  is a server control that is equivalent to             input type text in HTML-->
                           <asp:TextBox CssClass="form-control" ID="txtUsername"
                              runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                         </div>
                  </div>

                   <div class="row">
                     <div class="col">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtPassword"
                              runat="server" placeholder="password"                                TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                    </div>

                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <!--from bootsrap-->
                           <asp:Button Cssclass="btn btn-success btn-block btn-             lg"
                              ID="btnLogin" runat="server" Text="Login"         
                                OnClick="btnLogin_Click"/>
                        </div>

                     </div>
                  </div>

                  <div class="row">
                     <div class="col">
                        <!--from bootsrap-->
                        <div class="form-group">
                           <a href="registration.aspx">
                               <input type="button"class="btn btninfo btn-block               btn-lg" id="Button2" value="Sign Up" />
                           </a><!--normal shortcut link to page-->
                        </div>
                     </div>
                  </div>

               </div>
            </div>
         </div>
      </div>
   </div>
  
      <a href="homepage.aspx"><< Back to Home</a><br><br>







</asp:Content>
