<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HireMe.UI.Pages.Common.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="alert alert-danger" runat="server" id="divAlert">
                       You Entered a Wrong password !!
                    </div>
                    <div class="alert alert-success" runat="server" id="divSuccess">
                        You Changed Your PassWord successfully  :) thank you !
                    </div>
    <div class="panel panel-success">
        <div class="modal-header">
            <h3>Change Password <span class="extra-title muted"></span></h3>
        </div>
        <div class="modal-body form-horizontal">
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label for="inputdefault">Old Password:</label>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtOldPassword" CssClass="form-control"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtOldPassword" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" ></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="col-lg-4"></div>

            </div>
            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label for="inputdefault">New PAssword:</label>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtNewPassword" CssClass="form-control"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNewPassword" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-lg-4"></div>

            </div>

            <div class="row">
                <div class="col-lg-4"></div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label for="inputdefault">Confirm Password:</label>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtConfirmPassword" CssClass="form-control"></asp:TextBox>
                        <asp:CompareValidator ID="ss" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword" ForeColor="Red" runat="server" ErrorMessage="PassWord Not Matching " ></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtConfirmPassword" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!" ></asp:RequiredFieldValidator>
                    </div>
                </div>
                
               

            </div>
         
        </div>

        
    </div>
       <div class="row">
                     <div class="col-lg-4"></div>
                     <div class="col-lg-4">
        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-lg" Text="save" OnClick="btnSave_Click" /></div>
                      <div class="col-lg-4"></div>
                </div>
     
</asp:Content>
