<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PackageAssigning.aspx.cs" Inherits="SMSPortal.Pakckages.PackageAssigning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link id="bs_css" href="../Content/css/bootstrap-cerulean.min.css" rel="stylesheet" />
    <link href="../Content/css/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix"></div>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        <div class="well col-lg-6 col-md-6 col-sm-6 ">
            <div class="alert alert-info">
                Package Assigning Form
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
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <label for="" class="control-label labelCss">Invoice #:</label>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <input type="text" runat="server" class="form-control" id="InputDis" disabled="disabled" />
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label class="control-label labelCss">Client:</label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <asp:Label ID="L_Name" runat="server" ClientIDMode="Static" Style="color: forestgreen"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />

            <div class="form-group">
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <label for="DDL_Client" class="control-label labelCss">Client Name:</label>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <asp:DropDownList ID="DDL_Client" runat="server" CssClass="form-control" OnSelectedIndexChanged="DDL_Client_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:Label ID="ErrorName" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>                    
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label class="control-label labelCss">Package:</label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <asp:Label ID="L_Package" runat="server" ClientIDMode="Static" Style="color: forestgreen"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <label for="DDL_Package" class="control-label labelCss">Package Name:</label>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <asp:DropDownList ID="DDL_Package" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Label ID="ErrorMasking" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label class="control-label labelCss">SMS Left:</label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <asp:Label ID="L_Sms" runat="server" ClientIDMode="Static" Style="color: forestgreen"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <label class="control-label labelCss">Status:</label>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <label class="remember labelCss" for="active">
                        <input type="checkbox" runat="server" id="active" checked="checked" />
                        Active</label>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label class="control-label labelCss">Last Date:</label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <asp:Label ID="L_Date" runat="server" ClientIDMode="Static" Style="color: forestgreen"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-8 col-md-8 col-sm-1 8">
                </div>
                <div class="col-lg-2 col-md-2 col-sm-1 2">
                    <asp:LinkButton ID="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-1 2">
                    <button id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span>Save</button>
                </div>
            </div>
        </div>
    </div>
    <div class="col-lg-3 col-md-3 col-sm-3"></div>
</asp:Content>
