<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ClientRegistration.aspx.cs" Inherits="SMSPortal.Clients.ClientRegistration" %>

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
                Client Registration
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
                    <label for="DDL_Name" class="control-label labelCss">Client Name:</label>
                </div>
                <div class="col-lg-7 col-md-7 col-sm-7">
                    <asp:DropDownList ID="DDL_Name" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Label ID="L_Search" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <button runat="server" id="btn_Search1" class="btn btn-success" onserverclick="btn_Search_Click"><span class="glyphicon glyphicon-edit"></span>Edit</button>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <label for="InputName" class="control-label labelCss">Client Name:</label>
                </div>
                <div class="col-lg-9 col-md-9 col-sm-9">
                    <input type="text" runat="server" class="form-control" id="InputName" placeholder="Client Name" />
                    <asp:Label ID="ErrorName" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <label for="InputMasking" class="control-label labelCss">Masking Name:</label>
                </div>
                <div class="col-lg-9 col-md-9 col-sm-9">
                    <input type="text" runat="server" class="form-control" id="InputMasking" placeholder="Masking Name" maxlength="11" />
                    <asp:Label ID="ErrorMasking" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-3 col-md-3 col-sm-3">
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
                <div class="col-lg-8 col-md-8 col-sm-8"></div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <asp:LinkButton ID="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <button id="btnSave" runat="server" onserverclick="btnSave_Click" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span>Save</button>
                </div>
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->
</asp:Content>
