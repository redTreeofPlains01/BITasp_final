<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="allbookedjobs.aspx.cs" Inherits="BITServicesWebAppv1._1.allbookedjobs" %>

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
                                    <h4> All Job Bookings </h4>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class ="col-12" style="width:90%;overflow:auto">
                                 <asp:GridView ID="gvAllJobBookings"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" style="width:100%;overflow:auto"/>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> All Completed Job-Bookings </h4>
                                </div>
                            </div>
                        </div>
                         <div class="row" >
                            <div class ="col-12"  style="width:90%;overflow:auto">
                                 <asp:GridView ID="gvCompletedJobBookings"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand ="gvCompletedJobBookings_RowCommand" 
                                     style="width:100%;overflow:auto">
                                       <Columns>
                                         <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnConfirm" runat="server" CommandName="Verify"
                                                     Height="40px" Text="Verify" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> All Rejected Job-Bookings </h4>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class ="col-12" style="width:90%;overflow:auto">
                                 <asp:GridView ID="gvRejectedJobBookings"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand ="gvRejectedJobBookings_RowCommand" 
                                     style="width:100%;overflow:auto" >
                                       <Columns>
                                         <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnReBook" runat="server" CommandName="ReBook"
                                                     Height="40px" Text="Re-Book" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>
                            </div>
                        </div>
                         <div class="row">
                            <div class ="col-12">
                                <div style="text-align:center">
                                    <h4> Available Sessions </h4>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col-12" style="width:90%;overflow:auto">
                                 <asp:GridView ID="gvAvailableSessions"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvAvailableSessions_RowCommand" style="width:100%;overflow:auto" >
                                     <Columns>
                                         <asp:TemplateField HeaderText="Action">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnConfirm" runat="server" CommandName="Select"
                                                     Height="40px" Text="Confirm" Width="80px"
                                                     CommandArgument="<%#Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>

                                 </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
