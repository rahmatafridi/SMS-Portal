<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ScheduleList.aspx.cs" Inherits="SMSPortal.ScheduleSMS.ScheduleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Content/scripts/jquery.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .mydatagrid {
            width: 100%;
            /*border: solid 1px black;*/
            min-width: 100%;
            /*border: 1px solid #000000;*/
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 12px;
            color: #000;
            /*min-height: 25px;*/
            text-align: left;
            /*border: 1px solid;*/
        }

        th, td {
            padding: 5px 5px 5px 5px !important;
        }

        .header {
            background-color: #2c3675;
            color: White;
            font-family: Arial;
            font-size: 13px;
        }
    </style>


    <div class="dashboard-wrapper">
        <div class="row">
            <div class="col-lg-offset-1 col-lg-10 col-md-offset-1 col-md-10 col-sm-offset-1 col-sm-10 col-xs-12">
                <div class="panel panel-blue" style="margin-top: 15px;">
                    <div class="panel-body">
                        <div class="container-fluid">
                            <div class="top-bar clearfix">
                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="page-title">
                                            <h1 class="text-uppercase text-center">Campaign Schedule List</h1>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive" style="overflow-x: hidden !important;">
                            <br />
                            <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid table-align-center" PagerStyle-CssClass="paging" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                DataKeyNames="UID" ShowFooter="false" PageSize="100" AllowPaging="true" OnPageIndexChanging="grdProducts_PageIndexChanging" GridLines="Both" OnRowCommand="grdProducts_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="UID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUID" runat="server" Text='<%# Bind("UID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Message" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBCodeUID" runat="server" Text='<%# Bind("TextSms") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Schedule Date & Time" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProdPropUID" runat="server" Text='<%# Bind("DateTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString() == "1" ? "Scheduled" : "Sent" %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Actions">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="DataCommand" OnClientClick="return confirm('Do you really want to delete?');" CausesValidation="false" ClientIDMode="Static" CommandArgument='<%# Eval("UID" )%>' CssClass="btn btn-info btn-xs btn-left-margin float-right" ID="btnEditProduct" runat="server"><i class="icon-edit"></i>Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>  
</asp:Content>
