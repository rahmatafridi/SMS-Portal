<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddPackage.aspx.cs" Inherits="SMSPortal.Pakckages.AddPackage" %>

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
        <div class="well col-lg-6 col-md-6 col-sm-6">
            <div class="alert alert-info">
                Add New Package
            </div>
            <div class="alert alert-danger" runat="server" id="dverror" visible="false">
                <strong>ERROR !</strong>
                <asp:Label ID="lblerror" runat="server" ClientIDMode="Static"></asp:Label>
            </div>

            <div class="alert alert-success" runat="server" id="dvsuccess" visible="false">
                <strong>SUCCESS !</strong>
                <asp:Label ID="lblsuccess" runat="server" ClientIDMode="Static"></asp:Label>
            </div>

            <fieldset>
                <div class="form-group">
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <label for="DDL_Name" class="control-label labelCss">Package Name:</label>
                    </div>
                    <div class="col-lg-7 col-md-7 col-sm-7">
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
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <label for="InputName" class="control-label labelCss">Package Name:</label>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9">
                        <input type="text" runat="server" class="form-control" id="InputName" placeholder="Package Name" />
                        <asp:Label ID="ErrorName" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <label for="InputSMS" class="control-label labelCss">No Of SMS:</label>
                        <input type="text" runat="server" class="form-control" id="InputSMS" placeholder="SMS Qty" />
                        <asp:Label ID="ErrorSMS" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <label for="InputDuration" class="control-label labelCss">Duration:</label>
                        <asp:Label ID="ReqDuration" runat="server" Style="color: red">*In Month</asp:Label>
                        <input type="text" runat="server" class="form-control" id="InputDuration" placeholder="Month Duration" />
                        <asp:Label ID="ErrorDuration" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <label for="InputRate" class="control-label labelCss">Rate:</label>
                        <asp:Label ID="Label1" runat="server" Style="color: red">* Per SMS</asp:Label>
                        <input type="text" runat="server" class="form-control" id="InputRate" placeholder="SMS Rate" />
                        <asp:Label ID="ErrorRates" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <div class="col-lg-1 col-md-1 col-sm-1">
                        <label for="InputMasking" class="control-label labelCss">Status</label>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9">
                        <label class="remember labelCss" for="active">
                            <input type="checkbox" runat="server" id="active" checked="checked" />
                            Active</label>
                    </div>
                </div>
                <div class="clearfix"></div>

                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4"></div>
                    <div class="col-sm-2">
                        <asp:LinkButton id="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>
                    </div>

                    <div class="col-sm-2">
                        <button id="btnSave" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span> Save</button>
                    </div>
                </div>
            </fieldset>

        </div>
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
    </div>    
</asp:Content>
