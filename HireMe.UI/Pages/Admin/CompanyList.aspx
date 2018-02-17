<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="HireMe.UI.Pages.Admin.CompanyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .top-buffer {
            margin-top: 30px;
        }
    </style>

    <div class="row">
        <h4>Search Companies</h4>

        <div class="col-lg-4">
            <div class="form-group">
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control " placeholder="Comany Name"></asp:TextBox>
            </div>    
        </div>
        <div class="col-lg-4">
            <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" Text="Search"  CssClass="btn  btn-info"/>
         </div>
        <div class="col-lg-4">
        </div>
    </div>

    <div class="row top-buffer">

        <div class="table table-hover table-striped MOI-table">
            <asp:GridView ID="grdCompany" AutoGenerateColumns="false" runat="server" EmptyDataText="NoRecords" OnRowDataBound="grdCompany_RowDataBound"
                BorderWidth="0" AllowPaging="true" AllowCustomPaging="true" OnPageIndexChanging="grdCompany_PageIndexChanging" CssClass="table table-hover table-striped MOI-table">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="grdlblName" runat="server" Text='<%# Eval("UserName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="grdlblEmail" runat="server" Text='<%# Eval("Email") %>'>
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
                            <asp:LinkButton ID="Edit" CssClass="btn btn-link btn-no-padding" runat="server" Text="View" CommandArgument='<%# Eval("Id")%>' OnCommand="Edit_Command"></asp:LinkButton>
                            | 
                                    <asp:LinkButton ID="Deactivate" CssClass="btn btn-link btn-no-padding" runat="server" Text="Deactivate" CommandArgument='<%# Eval("Id")%>' OnCommand="Deactivate_Command"></asp:LinkButton>
                            <asp:LinkButton ID="Actevaite" CssClass="btn btn-link btn-no-padding" runat="server" Text="Actevaite" CommandArgument='<%# Eval("Id")%>' OnCommand="Actevaite_Command"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                <PagerStyle CssClass="pagination-ys" />

            </asp:GridView>

        </div>

    </div>
</asp:Content>
