<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="bookedjobs.aspx.cs" Inherits="BITServicesWebAppv1._1.bookedjobs" %>
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
                                    <h4> Booked Sessions </h4>
                                </div>
                            </div>
                        </div>
                            <div class="row">
                            <div class ="col-12" style="width:90%;overflow:auto">
                                 <asp:GridView ID="gvBookedSessions"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvBookedSessions_RowCommand" 
                                     style="width:100%;overflow:auto">
                                     <Columns>

                                         <asp:TemplateField HeaderText="Accept Session">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnAccept"  runat="server" 
                                                     CommandName="Accept"
                                                   Height="40px" Text="Accept" Width="80px" 
                                                     CommandArgument="<% #Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                                 </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Reject Session"> <ItemTemplate>
                                                 <asp:Button ID="btnReject"  runat="server" 
                                                     CommandName="Reject"
                                            Height="40px" Text="Reject"   Width="80px"
                                          CommandArgument="<% #Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>

                                 </asp:GridView>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <div style="text-align:center">
                                    <h4> Accepted Sessions </h4>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class ="col-12" style="width:90%;overflow:auto">
                                 <asp:GridView ID="gvAcceptedSessions"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvAcceptedSessions_RowCommand" 
                                     style="width:100%;overflow:auto">
                                     <Columns>

                                         <asp:TemplateField HeaderText="Complete Session">
                                             <ItemTemplate>
                                                 <asp:Button ID="btnComplete"   runat="server" 
                                                     CommandName="Complete"
                                            Height="40px" Text="Complete"  Width="80px"
                                          CommandArgument="<%     #Container.DataItemIndex %>"/>
                                             </ItemTemplate>
                                         </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Kilometers Travelled">
                                             <ItemTemplate>

                                                 <asp:TextBox ID="txtKilometers"    runat="server" 
                                                     CommandName="Reject"
                                            Height="40px" Text="0"   Width="80px" />

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
</asp:Content>
