<%@ Page Language="C#" MasterPageFile="~/Empty.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMSPortal.Authentication.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-block .centered {
            display: inline-block;
            /*vertical-align: middle;*/
            /*max-width: 560px;
            min-width: 560px;*/
            background-color: rgba(72,72,72,0.1);
            border-radius: 10px;
            -o-border-radius: 10px;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border: #ccc 1px solid;
            padding: 20px 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row" style="background-color:rgba(72,72,72,0.1);">

            <center>
            <a href="http://sms.webixoft.net">
            <img src="../Images/WXLogo.png" alt="WebiXoft Solutions" height="80px"  />
                
        </a>
        </center>
    </div>
    <div class="clearfix"></div>
    <br /><br />
    <br />
    <%--<div class="row">
        <center>
            <h1 style="color: #ffffff; font-size:30px; font-weight: bold;">Corporate SMS Solution</h1>
        </center>
    </div>--%>
    <div class="clearfix"></div>
    <br />

    <div class="row">
        <div class="col-lg-4 col-md-4 col-sm-4"></div>
        <div class="login-block">
            <div class="centered col-lg-4 col-md-4 col-sm-4">
                <div class="alert alert-info">
                    Please login with your Username and Password.           
                </div>
                <div class="alert alert-danger" runat="server" id="dverror" visible="false">
                    <strong>ERROR !</strong>
                    <asp:Label ID="lblerror" runat="server" ClientIDMode="Static"></asp:Label>
                </div>
                <div class="alert alert-success" runat="server" id="dvsuccess" visible="false">
                    <strong>SUCCESS !</strong>
                    <asp:Label ID="lblsuccess" runat="server" ClientIDMode="Static"></asp:Label>
                </div>

                <div class="form-group">
                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user red"></i></span>
                        <input type="text" id="InputName" class="form-control" runat="server" placeholder="Username" />
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <div class="input-group input-group-lg">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                        <input type="password" id="InputPassword" class="form-control" runat="server" placeholder="Password" />
                        <asp:Label ID="ErrorPassword" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />

                <div class="col-lg-10 col-md-10 col-sm-10"></div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <asp:LinkButton ID="btnSignIn" runat="server" OnClick="btnSignIn_Click" CssClass="btn btn-primary">Login</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-4 col-sm-4"></div>
    </div>

</asp:Content>


