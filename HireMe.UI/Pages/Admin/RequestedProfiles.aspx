<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestedProfiles.aspx.cs" Inherits="HireMe.UI.Pages.Admin.RequestedProfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style>
        .top-buffer {
            margin-top: 30px;
        }
    </style>

    <div class="row">
        <h4>Requested Profiles</h4>


    </div>

    <div class="row top-buffer">

        <div class="table table-hover table-striped MOI-table">
            <asp:GridView ID="grdCompany" AutoGenerateColumns="false" runat="server" EmptyDataText="NoRecords" OnRowDataBound="grdCompany_RowDataBound"
                BorderWidth="0" AllowPaging="true" AllowCustomPaging="true"  CssClass="table table-hover table-striped MOI-table">
                <Columns>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblName" runat="server" Text='<%# Eval("CompanyName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Individual Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblEmail" runat="server" Text='<%# Eval("IndividualName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="grdlblStatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Actions">

                        <ItemTemplate>
                           
                                    <asp:LinkButton ID="lnkunlock" CssClass="btn btn-link btn-no-padding" runat="server" Text="unlock" CommandArgument='<%# Eval("Id")%>' OnCommand="lnkunlock_Command"></asp:LinkButton>
                            <asp:LinkButton ID="lnkLock" CssClass="btn btn-link btn-no-padding" runat="server" Text="Lock" CommandArgument='<%# Eval("Id")%>' OnCommand="lnkLock_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                <PagerStyle CssClass="pagination-ys" />

            </asp:GridView>

        </div>

    </div>
</asp:Content>

