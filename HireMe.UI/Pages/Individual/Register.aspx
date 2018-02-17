<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HireMe.UI.Pages.Individual.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../../Content/bootstrap.css">
    <link rel="stylesheet" href="../../Content/font-awesome.min.css">

    <title></title>
    <style>
        body, html {
            height: 100%;
            background-repeat: no-repeat;
            background-color: #d3d3d3;
            font-family: 'Oxygen', sans-serif;
            background-image: url("../../logo/imageedit_2_7972179509.jpg");
            background-size:cover;
      
        }

        .main {
            margin-top: 70px;
        }

        h1.title {
            font-size: 50px;
            font-family: 'Passion One', cursive;
            font-weight: 400;
        }

        hr {
            width: 10%;
            color: #fff;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            margin-bottom: 15px;
        }

        input,
        input::-webkit-input-placeholder {
            font-size: 11px;
            padding-top: 3px;
        }

        .main-login {
            background-color: #fff;
/* shadows and rounded borders */
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
               
        }

        .main-center {
            margin-top: 30px;
            margin: 0 auto;
            max-width: 600px;
            padding: 40px 40px;
        }

        .login-button {
            margin-top: 5px;
        }

        .login-register {
            font-size: 11px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form runat="server">

        <div class="container">
            <div class="row main">
                <div class="panel-heading">
                    <div class="panel-title text-center">
                        <h1 class="title">Sign Up</h1>
                        <hr />
                    </div>
                </div>
                <div class="main-login main-center">
                    <div class="alert alert-danger" runat="server" id="divAlert">
                        username already exist !!
                    </div>
                    <div class="alert alert-success" runat="server" id="divSuccess">
                        you registered successfully :) thank you !
                    </div>


                    
                    
                    <div class="form-group">
                        <label for="email" class="cols-sm-2 control-label">Your Email</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-envelope" aria-hidden="true"></i></span>
                                <asp:TextBox runat="server"  ID="txtEmail" placeholder="Enter your Email" CssClass="form-control"></asp:TextBox>
                                
                            </div>
                            <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail" ForeColor="Red" runat="server" ErrorMessage="This Field Is Require"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="username" class="cols-sm-2 control-label">UserName</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                                <asp:TextBox runat="server" ID="txtUsername" placeholder="Enter your Username" CssClass="form-control"></asp:TextBox>
                            </div>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" ForeColor="Red" runat="server" ErrorMessage="This Field Is Require"></asp:RequiredFieldValidator>

                        </div>
                    </div>

                    <div class="form-group">
                        <label for="password" class="cols-sm-4 control-label">Password</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Enter your Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvtxtPassword" ControlToValidate="txtPassword" ForeColor="Red" runat="server" ErrorMessage="This Field Is Required!"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="confirm" class="cols-sm-4 control-label">Confirm Password</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" placeholder="Confirm Password" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="rfvtxtConfirmPassword" ControlToValidate="txtConfirmPassword" runat="server" ForeColor="Red" ErrorMessage="This Field Is Required"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cfvPassword" runat="server" ErrorMessage="password not matching" ControlToCompare="txtPassword" ForeColor="Red" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                        </div>
                    </div>

                    <div class="form-group ">
                        <asp:Button ID="btnregister" runat="server" Text="continue as individual" OnClick="btnregister_Click" class="btn btn-primary btn-lg btn-block login-button" />
                        <asp:Button ID="btnRegisterCompany" runat="server" Text="continue as company" OnClick="btnRegisterCompany_Click" class="btn btn-primary btn-lg btn-block login-button" />

                    </div>
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>

