<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BITServicesWebAppv1._1.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Design of Registration page -->
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class ="card-body">
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <img width="100px" src="Images/registeruser.jpg" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> New Client Sign Up</h4>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>First Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtFName" runat="server" 
                                        placeholder="First Name" ></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="col-md-6">
                                <label>Last Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtLName" runat="server" 
                                        placeholder="Last Name" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <!-- this row will be divided into three parts with first two columns with a span of 
                                3 each and last one 6 -->
                            <div class="col-md-3">
                                <label> Date Of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtDOB" runat="server" 
                                        placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label> Contact Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" 
                                        placeholder="Contact Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"
                                        placeholder="Email Address" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Address Line (Example: 3, George Street)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"
                                        placeholder="Address Line"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-2">
                                <label>Suburb</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSuburb" runat="server"
                                        placeholder="Suburb"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                 <label>State</label>
                                 <div class="form-group">
                                     <asp:DropDownList CssClass="form-control" ID="ddlState" runat="server">
                                         <asp:ListItem Text="Select" Value="select" />
                                         <asp:ListItem Text="NSW" Value ="NSW" />
                                         <asp:ListItem Text="ACT" Value ="ACT" />
                                         <asp:ListItem Text="WA"  Value ="WA" />
                                         <asp:ListItem Text="QLD" Value ="QLD" />
                                         <asp:ListItem Text="TAS" Value ="TAS" />
                                         <asp:ListItem Text="NT"  Value ="NT" />
                                         <asp:ListItem Text="VIC" Value ="VIC" />
                                         <asp:ListItem Text="SA"  Value ="SA" />
                                     </asp:DropDownList>
                                 </div>
                            </div>
                             <div class="col-md-2">
                                 <label>PostCode</label>
                                 <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPostCode" runat="server"
                                        placeholder="Post Code"></asp:TextBox>
                                </div>
                            </div>
                        </div>





                       




                             
                        </div>
                        <div class ="row">
                            <div class="col-12 mx-auto">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" runat="server"
                                        ID="btnSignUp" OnClick="btnSignUp_Click" Text="Sign Up" />
                                </div>
                            </div>
                        </div>
                   
                </div>
            </div>
        </div>
    </div>




    <a href="Homepage.aspx"><< Back to Home</a><br><br>
    <a href="Login.aspx"><< Back to Login</a><br><br>

</asp:Content>
