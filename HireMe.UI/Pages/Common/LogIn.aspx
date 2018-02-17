<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="HireMe.UI.Pages.Common.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>


        .xx {
            background-image: url("../../logo/test4.jpg");
        }

  </style>
    <div class="xx" style="width:1155px; height:600px;">
         <div class="col-md-4 text-center" style="margin-top:300px ; margin-left:377px;" > 
    <asp:Button id="singlebutton" runat="server" OnClick="singlebutton_Click" CssClass="btn btn-primary" style="height:50px; width:250px;"  Text="Dont Have  acount ? Register"> </asp:Button> 
</div>
    </div>
        
</asp:Content>
