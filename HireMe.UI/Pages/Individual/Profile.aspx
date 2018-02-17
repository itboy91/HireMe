<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HireMe.UI.Pages.Individual.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Individual Profile</h2>
        <div class="panel panel-success">
            <div class="panel-heading">Basic Informationt</div>
            <div class="panel-body">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Full Name:</label>
                                <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Email:</label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">Location:</label>
                                <asp:DropDownList ID="ddlLocation" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">phone:</label>
                                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="sel1">Birth Of date:</label>
                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="sel1"></label>
                                <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="sel1"></label>
                                <asp:DropDownList ID="ddlDay" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">gender:</label>
                                <asp:DropDownList ID="ddlGendr" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="sel1">Nationality:</label>
                                <asp:DropDownList ID="ddlNationality" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-warning">
            <div class="panel-heading">Career Information</div>
            <div class="panel-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="sel1">field of business:</label>
                                    <asp:DropDownList ID="ddlFieldOfBusiness" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlFieldOfBusiness_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="sel1">skiles:</label>
                                    <asp:DropDownList ID="ddlSkiles" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="sel1">graduation country:</label>
                                    <asp:DropDownList ID="ddlGraduationCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlGraduationCountry_SelectedIndexChanged" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="sel1">graduation university :</label>
                                    <asp:DropDownList ID="ddlGraduationUniversity" Enabled="false" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label for="sel1">Years of experience:</label>
                            <asp:DropDownList ID="ddlYearsOfExperience" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="sel1">type of employment:</label>
                            <asp:DropDownList ID="ddlTypeOfEmployment" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="sel1">Academic Degree:</label>
                            <asp:DropDownList ID="ddlAcademicDegree" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <asp:Button ID="btnDownload" runat="server" Text="Download File" OnClick="btnDownload_Click" />
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div class="form-group">
                            <label for="inputdefault">Upload Your CV:</label>
                            <asp:FileUpload ID="fuCv" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <asp:Button ID="btnSave" runat="server" Style="width: 150px; margin: -8px;" CssClass="btn btn-primary btn-lg" Text="save" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
