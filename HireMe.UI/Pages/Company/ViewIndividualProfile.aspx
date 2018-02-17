<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewIndividualProfile.aspx.cs" Inherits="HireMe.UI.Pages.Company.ViewIndividualProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .multiselect-container {
            width: 100% !important;
        }
    </style>

    <div class="container">
        <h1>
            <asp:Literal runat="server" ID="ltrName"></asp:Literal></h1>
        <div class="row">
            <div class="col-md-12">
                <asp:Image ID="imgProfile" runat="server" Style='float: left; width: 200px; height: 200px; margin-right: 10px;' CssClass="img-thumbnail" />
                <p>
                    <asp:Literal runat="server" ID="ltrCover"></asp:Literal>
                </p>
            </div>
        </div>
    </div>

    <div class="panel panel-success" style="margin-top: 15px;">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-6">
                    <span class="label label-default">
                        <label for="inputdefault">Birth Of date:</label></span>
                    <br>
                    <asp:Literal ID="lblBirthOfDate" runat="server"></asp:Literal>
                </div>
                <div class="col-lg-6">
                    <label for="sel1">Location:</label><br />
                    <asp:Literal ID="lblLocation" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label for="sel1">gender:</label><br />
                    <asp:Literal ID="lblGender" runat="server"></asp:Literal>
                </div>
                <div class="col-md-6">
                    <label for="sel1">Nationality:</label><br />
                    <asp:Literal ID="lblNationality" runat="server"></asp:Literal>
                </div>



            </div>
            <div class="row">
                <div class="col-md-6">

                    <label for="sel1">Relationship Status</label><br />
                    <asp:Literal ID="lblRelationshipStatus" runat="server"></asp:Literal>
                </div>
                <div class="col-md-6">
                    <label for="sel1">ability to travel :</label><br />
                    <asp:Literal ID="lblAbilityToTravel" runat="server"></asp:Literal>
                </div>

            </div>
        </div>
    </div>

    <div class="panel panel-warning">
        <div class="panel-heading">Career Information</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-lg-6">
                    <label for="sel1">field of business:</label><br />
                    <asp:Literal ID="lblFieldOfBusiness" runat="server"></asp:Literal>
                </div>
                <div class="col-lg-6">
                    <label for="sel1">skiles:</label><br>
                    <asp:Literal ID="lblSkiles" runat="server"></asp:Literal>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <label for="sel1">graduation country:</label><br />
                    <asp:Literal ID="lblGraduationCountry" runat="server"></asp:Literal>
                </div>
                <div class="col-lg-6">
                    <label for="sel1">graduation university :</label>
                    <asp:Literal ID="lblGraduationUniversity" runat="server"></asp:Literal>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <label for="sel1">Years of experience:</label><br />
                    <asp:Label ID="lblYearsOfExperience" runat="server"></asp:Label>
                </div>
                <div class="col-lg-6">

                    <label for="sel1">type of employment:</label><br />
                    <asp:Literal ID="LblTypeOfEmployment" runat="server"></asp:Literal>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <label for="sel1">Academic Degree:</label><br />
                    <asp:Literal ID="lblAcademicDegree" runat="server"></asp:Literal>
                </div>
                <div class="col-lg-6">
                    <label for="inputdefault">minimum salary:</label><br />
                    <asp:Literal ID="lblMinimumSalary" runat="server"></asp:Literal>
                </div>

            </div>
            <div class="row">
                <div class="col-lg-6">
                    <label for="inputdefault">employment history </label>
                    <br />
                    <asp:Literal ID="lblEmoloymentHistory" runat="server"></asp:Literal>
                </div>

            </div>
        </div>
    </div>
    <div runat="server" id="divUnlockAcount" style="display: block">
        <div class="col-lg-6">
            <asp:Button ID="btnUnlockAcount" runat="server" Style="width: 150px; margin: -8px;" CssClass="btn btn-primary btn-lg" Text="Unlock Acount" OnClick="btnUnlockAcount_Click" />
        </div>


    </div>

    <div class="panel panel-success" style="margin-top: 15px; display: none" runat="server" id="divContactInfo">
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-6">
                    <span class="label label-default">
                        <label for="inputdefault">Emil:</label></span>
                    <br>
                    <asp:Literal ID="lblEmil" runat="server"></asp:Literal>
                </div>
                <div class="col-lg-6">
                    <label for="sel1">Phone:</label><br />
                    <asp:Literal ID="lblPhone" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">

                    <label for="sel1">CV:</label><br />

                    <div class="form-group">
                        <asp:Button ID="btnDownload" runat="server" Text="Download File"
                            OnClick="btnDownload_Click" />
                    </div>
                </div>

            </div>

        </div>
    </div>
   <div class="alert alert-info" runat="server" id="divUnderProcess" style="display:none;">
  <strong>Info!</strong> Reqeuest is under process
</div>

</asp:Content>

