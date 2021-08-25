<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBooking.aspx.cs" Inherits="BITServicesWebAppv1._1.NewBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class ="card-body">
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <img width="100px" src="Images/Book_service.png" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> New Job Booking </h4>
                                </div>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <hr />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                 <label> Job Start Time </label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlJobStartTime" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="9:00AM" Value="9:00" />
                                        <asp:ListItem Text="10:00AM" Value="10:00" />
                                        <asp:ListItem Text="11:00AM" Value="11:00" />
                                        <asp:ListItem Text="12:00PM" Value="12:00" />
                                        <asp:ListItem Text="01:00PM" Value="13:00" />
                                        <asp:ListItem Text="02:00PM" Value="14:00" />
                                        <asp:ListItem Text="03:00PM" Value="15:00" />
                                        <asp:ListItem Text="04:00PM" Value="16:00" />                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                 <label> Job End Time </label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlJobEndTime" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="9:00AM" Value="9:00" />
                                        <asp:ListItem Text="10:00AM" Value="10:00" />
                                        <asp:ListItem Text="11:00AM" Value="11:00" />
                                        <asp:ListItem Text="12:00PM" Value="12:00" />
                                        <asp:ListItem Text="01:00PM" Value="13:00" />
                                        <asp:ListItem Text="02:00PM" Value="14:00" />
                                        <asp:ListItem Text="03:00PM" Value="15:00" />
                                        <asp:ListItem Text="04:00PM" Value="16:00" />                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <!-- this is where we will add one more new control to select date -->
                                <label> Booking Date </label>
                                <div class="form-group">




                             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                             <ContentTemplate>
                                    <asp:Calendar  ID="calBookDate" runat="server">
                                        </asp:Calendar>
                             </ContentTemplate>
                             </asp:UpdatePanel>




                                </div>
                            </div>



                             <div class="col-md-6">
                                <label> Skill Required </label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlSkill" 
                                        runat="server">
                                                                            
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        
                        <div class ="row">
                         <div class="col-md-12">
                                <label>Job Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtJobDescription" 
                                        runat="server" placeholder="Fill in description of job required"></asp:TextBox>
                                </div>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Address Line (Example: 3, George Street)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" 
                                        runat="server" placeholder="Job Address"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label> State </label>
                                <div class="form-group">
                                    
                                    <asp:DropDownList CssClass="form-control" ID="ddlState" runat="server">
                                        <asp:ListItem Text="NSW" Value="NSW" />
                                        <asp:ListItem Text="ACT" Value="ACT" />
                                        <asp:ListItem Text="WA" Value="WA" />
                                        <asp:ListItem Text="QLD" Value="QLD" />
                                        <asp:ListItem Text="TAS" Value="TAS" />
                                        <asp:ListItem Text="NT" Value="NT" />
                                        <asp:ListItem Text="VIC" Value="VIC" />
                                        <asp:ListItem Text="SA" Value="SA" />
                                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label> Suburb</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSuburb"
                                        runat="server" placeholder="suburb"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-3">
                                <label> Postcode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPostCode"
                                        runat="server" placeholder="Post Code"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        

                        <div class ="row">
                        <div class="col-12 mx-auto"> <!--col-12 inicates span the whole screen mx-auto automatically reduces size for mobile device-->
                            <div class="form-group">
                                <!--<div style="text-align:center>-->
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnFindSessions" runat="server" Text="Find a session" OnClick="btnFindSessions_Click"/>
                                    <!--green button-->
                                 <!--<</div>-->
                            </div>
                        </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <div style ="text-align:center">
                                    <h4>Available Sessions</h4>
                                </div>
                            </div>
                        <div class="row">
                            <div class="col-12">
                                <!--grid for all avail sessions, autogenerateslectbutton( a property of Gridview(of many suto properties)-is set to true so that every row will have a column added to the grid that has an instance of button when we do the code behind we code for thsi bitoon to get the reference of which button got clicked and once we have the reference we can finalise the booking for the customer with the driver detail-->
                                <!--OnRowCommand is like click event method for confirm buttom -->
                                <asp:GridView ID="gvAvailableSessions" CssClass="table table-striped table-ordered" runat="server" OnRowCommand="gvAvailableSessions_RowCommand" >
                                    
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnConfirm" runat="server"               
                                                     CommandName ="Select"                
                                                     Height="40px" Text="Confirm" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                                <!--Container.DataItemIndex(= asp.net code) is the columnindex for confirm buttom -->
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                                 <!--From Datables/css&js-->
                            </div>
                         </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
