<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyRegister.aspx.cs" Inherits="HireMe.UI.Pages.Company.CompanyRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                   <div class="alert alert-success" runat="server" id="divSuccess">
                      Well Send Eamil
                    </div>
    <div class="container">
        <h2>Company Profile</h2>
        <div class="panel-heading">Basic Informationt</div>
        <div class="panel-body">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="inputdefault">Company Name:</label>
                            <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="sel1">Industry:</label>
                            <asp:DropDownList ID="ddlIndustry" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="inputdefault">Phone Number:</label>
                            <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="inputdefault">Company E-mail:</label>
                            <asp:TextBox runat="server" ID="txtCompanyEmail" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="sel1">Country:</label>
                                    <asp:DropDownList ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="sel1">City:</label>
                                    <asp:DropDownList ID="ddlCity" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label for="inputdefault">WebSite:</label>
                             <asp:TextBox runat="server" ID="txtWebSite" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class=" row">
                    <div class="col-lg-12">
                                <asp:Button ID="btnSave" runat="server" style="width: 150px; margin:-8px;" CssClass="btn btn-primary btn-lg" Text="save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
