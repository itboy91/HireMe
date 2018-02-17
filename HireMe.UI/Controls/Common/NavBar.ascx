<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="HireMe.UI.Controls.Common.NavBar" %>
<style>
    .navbar-default .navbar-nav > li > a:hover, .navbar-default .navbar-nav > li > a:focus {
        color: #000; /*Sets the text hover color on navbar*/
    }

    .navbar-default .navbar-nav > .active > a, .navbar-default .navbar-nav > .active > a:hover, .navbar-default .navbar-nav > .active > a:focus {
        color: white; /*BACKGROUND color for active*/
        background-color: #030033;
    }

    .navbar-default {
        background-color: #0f006f;
        border-color: #030033;
    }

    .dropdown-menu > li > a:hover,
    .dropdown-menu > li > a:focus {
        color: #262626;
        text-decoration: none;
        background-color: #66CCFF; /*change color of links in drop down here*/
    }

    .nav > li > a:hover,
    .nav > li > a:focus {
        text-decoration: none;
        background-color: silver; /*Change rollover cell color here*/
    }


    .navbar-default .navbar-nav > li > a {
        color: white; /*Change active text color here*/
    }
</style>

<div runat="server" id="divlogIn" style="display: none">
    <div class="navbar navbar-default navbar-fixed-top ">
        <div class="container">
            <div class="navbar-header">
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Hire Me</a>
            </div>
            <center>
            <div class="navbar-collapse collapse" id="navbar-main">
                
                <div class="navbar-form navbar-right" role="search">
                    <div class="form-group">
                        <asp:textbox runat="server"  placeholder="Username" ID="txtuserName" ></asp:textbox>
                    </div>
                    <div class="form-group">
                     <asp:textbox runat="server"  placeholder="Password" ID="txtpassword" TextMode="Password" ></asp:textbox>
                        <asp:Label runat="server" ID="lblLogInError" style="color:red"></asp:Label>
                    </div>
                    <asp:Button runat="server" class="btn btn-default" ID="btnLogIn" Text="Log In" OnClick="btnLogIn_Click"/>
                </div>
            </div>
        </center>
        </div>
    </div>
</div>

<div runat="server" id="Divinv">
    <div class="navbar navbar-default navbar-fixed-top ">
        <div class="container">
            <div class="navbar-header">
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Hire Me</a>
            </div>
            <ul class="nav navbar-nav navbar-right">
                <li class="dropdown">

                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <asp:Literal runat="server" ID="litrINdivName"></asp:Literal>
                        <b class="caret"></b></a>

                    <ul class="dropdown-menu">

                        <li><a href="../../Pages/Common/ChangePassword.aspx">Change Password</a>

                        </li>

                        <li class="divider"></li>

                        <li>
                            <asp:LinkButton runat="server" OnClick="logOut_Click" ID="logOut"><span class="glyphicon glyphicon-log-out"></span> Log out</asp:LinkButton></li>

                    </ul>

                </li>

            </ul>
            <ul class="nav navbar-nav">

                <li><a href="../../Pages/Individual/IndividualProfile.aspx">My Profile</a>

                </li>
            </ul>
        </div>
    </div>
</div>

<div runat="server" id="divCompany">
    <div class="navbar navbar-default navbar-fixed-top ">
        <div class="container">
            <div class="navbar-header">
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Hire Me</a>
            </div>
            <ul class="nav navbar-nav navbar-right">
                <li class="dropdown">

                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <asp:Literal runat="server" ID="ltrUserName"></asp:Literal>
                        <b class="caret"></b></a>

                    <ul class="dropdown-menu">

                        <li><a href="../../Pages/Common/ChangePassword.aspx">Change Password</a>

                        </li>

                        <li class="divider"></li>

                        <li>
                            <asp:LinkButton runat="server" OnClick="logOut_Click" ID="LinkButton1"><span class="glyphicon glyphicon-log-out"></span> Log out</asp:LinkButton></li>

                    </ul>

                </li>

            </ul>
            <ul class="nav navbar-nav">

                <li><a href="../../Pages/Company/CompanyProfile.aspx">My Profile</a>
                <li><a href="../../Pages/Company/MyFavorite">My Favorite</a>
                <li><a href="../../Pages/Company/IndividualList.aspx">Search Users </a>
                    <li><a href="../../Pages/Company/RequestedProfiles.aspx">Requested Profiles </a>

                    </li>
            </ul>
        </div>
    </div>
</div>

<div runat="server" id="divAdmin">
    <div class="navbar navbar-default navbar-fixed-top ">
        <div class="container">
            <div class="navbar-header">
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">Hire Me</a>
            </div>
            <ul class="nav navbar-nav navbar-right">
                <li class="dropdown">

                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <asp:Literal runat="server" ID="litrAdminName"></asp:Literal>
                        <b class="caret"></b></a>

                    <ul class="dropdown-menu">

                        <li><a href="../../Pages/Common/ChangePassword.aspx">Change Password</a>

                        </li>

                        <li class="divider"></li>

                        <li>
                            <asp:LinkButton runat="server" OnClick="logOut_Click" ID="LinkButton2"><span class="glyphicon glyphicon-log-out"></span> Log out</asp:LinkButton></li>

                    </ul>

                </li>

            </ul>
            <ul class="nav navbar-nav">

                <li><a href="../../Pages/Admin/IndividualList.aspx">Manage individuals </a>
                    <li><a href="../../Pages/Admin/CompanyList.aspx">Manage Company</a>                    </li>
                <li><a href="../../Pages/Admin/RequestedProfiles.aspx">Requested Profiles</a>                    </li>
            </ul>
        </div>
    </div>
</div>

