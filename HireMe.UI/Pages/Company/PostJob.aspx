<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostJob.aspx.cs" Inherits="HireMe.UI.Pages.Company.PostJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/bootstrap-multiselect.js"></script>
    <script>    
        $(function () {
            $('[id*=lstSkils]').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '525px',
                dropRight: true
            });
        });
    </script>
    <style type="text/css">
    .multiselect-container {
        width: 100% !important;
    }
</style>
    <div class="container">
        <h2>Post Job

        </h2>
        <div class="panel panel-success">
            <div></div>
            <div class="panel-body">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Job type:</label>
                                <asp:DropDownList ID="ddlJobType" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Experience level: :</label>
                                <asp:DropDownList ID="ddlExperienceLevel" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">skiles:</label><br>
                                <asp:ListBox ID="lstSkils" runat="server" SelectionMode="Multiple"  style="width:100px;" Enabled="false">
                                   
                                </asp:ListBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">Role:</label>
                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label for="inputdefault">Job description:</label>
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription" Style="min-height: 200px;" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label for="inputdefault">Your responsibilities:</label>
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtResponsibilities" Style="min-height: 200px;" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <%--<div class="col-lg-6">
                            <div class="form-group">
                                <label for="inputdefault">Your responsibilities:</label>
                                <asp:TextBox  TextMode="MultiLine" runat="server" ID="TextBox1" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>--%>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <asp:Button ID="btnSave" runat="server" Style="width: 150px; margin: -8px;" CssClass="btn btn-primary btn-lg" Text="save" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
