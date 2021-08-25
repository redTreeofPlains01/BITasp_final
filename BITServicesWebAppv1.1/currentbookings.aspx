<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="currentbookings.aspx.cs" Inherits="BITServicesWebAppv1._1.currentbookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" container- fluid">
        <div class="row">
            <div class ="col-12">
                <div class="card">
                    <div class ="card-body">
                        <div class="row">
                            <div class="col">
                                <div style =" text-align:center">
                                    <h4>Current Job-Bookings</h4>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12" style="width:90%;overflow:auto">
                                <asp:GridView ID ="gvCurrentBookings"       
                                CssClass="table table-striped table-bordered"   
                                runat="server" style="width:100%;overflow:auto" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
</asp:Content>
