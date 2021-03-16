<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="SMSPortal.Users.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix"></div>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        <div class="well col-lg-6 col-md-6 col-sm-6 ">
            <div class="alert alert-info">
                User Registration Form
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
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="DDL_Name" class="control-label labelCss">Search User:</label>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8">
                    <asp:DropDownList ID="DDL_Name" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Label ID="L_Search" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <button runat="server" id="btn_Search" class="btn btn-success" onserverclick="btn_Search_ServerClick"><span class="glyphicon glyphicon-search"></span> Search</button>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />

            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="InputUser" class="control-label labelCss">User Id:</label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10">
                    <input type="text" runat="server" class="form-control" id="InputUser" placeholder="User ID" />
                    <asp:Label ID="ErrorUser" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />

            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="InputPassword" class="control-label labelCss">Password:</label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10">
                    <input type="password" runat="server" class="form-control" id="InputPassword" placeholder="Password" />
                    <asp:Label ID="ErrorPassword" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="DDL_Client" class="control-label labelCss">Client:</label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10">
                    <asp:DropDownList ID="DDL_Client" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Label ID="ErrorClient" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />

            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="DDL_Type" class="control-label labelCss">User Type:</label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10">                    
                    <asp:RadioButton ID="rdoAdmin" runat="server" GroupName="UserType" /> &nbsp; Admin &nbsp;&nbsp;
                    <asp:RadioButton ID="rdoUser" runat="server" GroupName="UserType" Checked="true" /> &nbsp; User
                    
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="DDL_Type" class="control-label labelCss">Status:</label>
                </div>
                <div class="col-lg-10 col-md-10 col-sm-10">
                    <label class="remember labelCss" for="active">
                        <input type="checkbox" runat="server" id="active" checked="checked" />
                        Active</label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-8 col-md-8 col-sm-8">
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <asp:LinkButton id="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <button id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span> Save</button>
                </div>
            </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        </div>
</asp:Content>
