<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.Master" CodeBehind="AddGroups.aspx.cs" Inherits="SMSPortal.Groups.AddGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>--%>
    <script src="../Content/scripts/jquery.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix"></div>
    <br />
    <br />
    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        <div class="well col-lg-6 col-md-6 col-sm-6">

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
                        <label for="GroupNameDD" class="control-label labelCss">Group:</label>
                    </div>
                    <div class="col-lg-7 col-md-7 col-sm-7">
                        <asp:DropDownList ID="GroupNameDD" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:Label ID="L_Search" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <button runat="server" id="btn_Search" class="btn btn-success" onserverclick="btn_Search_ServerClick"><span class="glyphicon glyphicon-search"></span>Search</button>
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <label for="ClientName" class="control-label labelCss">Client:</label>
                    </div>
                    <div class="col-lg-7 col-md-7 col-sm-7">
                        <asp:DropDownList ID="ddlClientName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <div class="col-lg-3 col-md-3 col-sm-3">
                        <label for="Groupname" class="control-label labelCss">Group Name:</label>
                    </div>
                    <div class="col-lg-9 col-md-9 col-sm-9">
                        <input type="text" runat="server" class="form-control" id="GroupName" placeholder="Name" />
                        <asp:Label ID="ErrorUser" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                    </div>
                </div>

                <div class="clearfix"></div>
                <br />

                <div class="clearfix"></div>
                <br />
                <div class="form-group">
                    <div class="col-lg-1 col-md-1 col-sm-1">
                        <label for="lblGroups" class="control-label labelCss">Status:</label>
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
                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>
                    </div>

                    <div class="col-sm-2">
                        <button id="Button1" runat="server" onserverclick="btnSave_ServerClick" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span>Save</button>
                    </div>
                </div>
            </fieldset>
            <div class="clearfix"></div>
            <br />
            <%--  <div id="tbl" runat="server" class="col-lg-12 col-md-12 col-sm-12"> --%>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
    </div>
    <script type="text/javascript">
           
    </script>
</asp:Content>

