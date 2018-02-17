<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyFavorite.aspx.cs" Inherits="HireMe.UI.Pages.Company.MyFavorite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script src="../../Scripts/bootstrap-multiselect.js"></script>

    <link rel="stylesheet" href="../../Content/circle.css" type="text/css" />

    <style>
        .lib-panel {
            margin-bottom: 20Px;
        }

            .lib-panel img {
                width: 100%;
                background-color: transparent;
            }

            .lib-panel .row,
            .lib-panel .col-md-6 {
                padding: 0;
                background-color: #FFFFFF;
            }


            .lib-panel .lib-row {
                padding: 0 20px 0 20px;
            }

                .lib-panel .lib-row.lib-header {
                    background-color: #FFFFFF;
                    font-size: 20px;
                    padding: 10px 20px 0 20px;
                }

                    .lib-panel .lib-row.lib-header .lib-header-seperator {
                        height: 2px;
                        width: 26px;
                        background-color: #d9d9d9;
                        margin: 7px 0 7px 0;
                    }

                .lib-panel .lib-row.lib-desc {
                    position: relative;
                    height: 100%;
                    display: block;
                    font-size: 13px;
                }

                    .lib-panel .lib-row.lib-desc a {
                        position: absolute;
                        width: 100%;
                        bottom: 10px;
                        left: 20px;
                    }

        .row-margin-bottom {
            margin-bottom: 20px;
        }

        .box-shadow {
            -webkit-box-shadow: 0 0 10px 0 rgba(0,0,0,.10);
            box-shadow: 0 0 10px 0 rgba(0,0,0,.10);
        }

        .no-padding {
            padding: 0;
        }

        .top-buffer {
            margin-top: 30px;
        }
    </style>
    <script>   
        $(function () {
            SetMultiSelect();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandle);
            function endRequestHandle(sender, Args) {
                SetMultiSelect();
            };
        });

        function SetMultiSelect() {
            $('[id*=lstSkils]').multiselect({
                includeSelectAllOption: true,
                buttonWidth: '525px',
                dropRight: true
            });
        }

    </script>
    <style type="text/css">
        .multiselect-container {
            width: 100% !important;
        }
    </style>
    <div class="row">
        <h4>Search Individual</h4>
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="sel1">field of business:</label>
                            <asp:DropDownList ID="ddlFieldOfBusiness" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlFieldOfBusiness_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="sel1">skiles:</label><br>
                            <asp:ListBox ID="lstSkils" runat="server" SelectionMode="Multiple" Style="width: 100px;" Enabled="false"></asp:ListBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control " placeholder="UserName"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                </div>
                <div class="col-lg-4">
                    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" CssClass="btn  btn-info" />
                </div>
                <div class="row">
                    <button data-toggle="collapse" type="button" data-target="#demo">Advance Search</button>
                </div>
                <div id="demo" class="collapse">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">Years of Experience</label>
                                <asp:DropDownList ID="ddlExperience" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">graduation country</label><br>
                                <asp:DropDownList ID="ddlGraduationCountry" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">Type of Employment</label>
                                <asp:DropDownList ID="ddlTypeOfEmployment" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">Academic Degree</label><br>
                                <asp:DropDownList ID="ddlAcademicDegree" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">Ability To Travel</label>
                                <asp:DropDownList ID="ddlAbilityToTravel" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="sel1">Nationality</label><br>
                                <asp:DropDownList ID="ddlNationality" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label for="sel1">Minimum Salary</label>
                                <asp:TextBox ID="txtMinimumSalary" runat="server" AutoPostBack="true" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row top-buffer">
        <asp:Repeater ID="rptUsers" runat="server" OnItemDataBound="rptUsers_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField runat="server" ID="hfIndividualId" Value=' <%# Eval("Id") %>' />
                <div class="col-lg-12 no-padding lib-item" data-category="ui">
                    <div class="lib-panel">
                        <div class="row box-shadow">
                            <div class="col-md-3">
                                <asp:Image ID="imgProfile" runat="server" Height="200" Width="200" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="img-thumbnail" />
                            </div>
                            <div class="col-md-9">
                                <div class="lib-row lib-header">
                                    <asp:Label ID="lblCustomerId" runat="server" Text='<%# Eval("Name") %>' />
                                    <div class="lib-header-seperator"></div>
                                </div>
                                <div class="lib-row lib-desc">
                                    <%# Eval("CoverLetter") %>
                                </div>
                                <div class="c100 p<%# Eval("Percentage") %> small">
                                    <span>
                                        <asp:Literal Text='<%# Eval("Percentage") %>' runat="server" /></span>
                                    <div class="slice">
                                        <div class="bar"></div>
                                        <div class="fill"></div>
                                    </div>
                                </div>
                                <div class="col-md-12" runat="server" id="divFavorite">
                                    <div class="btn  btn-info">
                                        <asp:LinkButton runat="server" ID="lnkAddToFavorite" CommandArgument=' <%# Eval("Id") %>' OnCommand="lnkAddToFavorite_Command"> Add To Favorite</asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>
</asp:Content>