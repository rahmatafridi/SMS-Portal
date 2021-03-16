<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SMSPortal.Authentication.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content">
        <!-- Info boxes -->
        <div class="clearfix"></div>
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="ion ion-ios-gear-outline"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Masking Name</span>
                        <span id="lblmaskingname" runat="server" class="info-box-number"></span>
                        <span id="lblClientName" runat="server" class="info-box-number" style="font-size: small"></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="ion ion-ios-analytics"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Package Name</span>
                        <span id="lblpackagename" runat="server" class="info-box-number"></span>
                        <span id="lblTotalSMS" runat="server" class="info-box-number" style="font-size:small;"></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>

            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-green"><i class="ion ion-ios-cart-outline"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Remaining SMS</span>
                        <span id="lblremsms" runat="server" class="info-box-number" ></span>
                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="ion ion-ios-people-outline"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Package Expiry</span>
                        <span id="lblpkgexpiry" runat="server" class="info-box-number"></span>
                        <span id="lblduration" runat="server" class="info-box-number" style="font-size: small;"></span>

                    </div>
                    <!-- /.info-box-content -->
                </div>
                <!-- /.info-box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </section>

</asp:Content>
