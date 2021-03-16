<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="SMSPortal.Authentication.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Content/scripts/jquery.min.js"></script>
    <script src="../Content/plugins/chartjs/Chart.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix"></div>
    <br />
    <br />
    <div class="login-box col-lg-4 col-md-4 col-sm-4">
        <canvas id="pieChart" style="height: 300px; width: 530px;" width="530" height="265"></canvas>
    </div>
    <div id="tbl" runat="server" class="col-lg-8 col-md-8 col-sm-8">                             
    </div>
    <div class="clearfix"></div>
    <br />
    <br />

    <script>
        //-------------
        //- PIE CHART -
        //-------------
        // Get context with jQuery - using jQuery's .get() method.
        var pieChartCanvas = $("#pieChart").get(0).getContext("2d");
        var pieChart = new Chart(pieChartCanvas);
        var PieData = [
          {
              value: 30,
              color: "#f56954",
              highlight: "#f56954",
              label: "Beautex"
          }
          ,
          {
              value: 500,
              color: "#00a65a",
              highlight: "#00a65a",
              label: "IE"
          },
          {
              value: 400,
              color: "#f39c12",
              highlight: "#f39c12",
              label: "FireFox"
          },
          {
              value: 600,
              color: "#00c0ef",
              highlight: "#00c0ef",
              label: "Safari"
          },
          {
              value: 300,
              color: "#3c8dbc",
              highlight: "#3c8dbc",
              label: "Opera"
          },
          {
              value: 100,
              color: "#d2d6de",
              highlight: "#d2d6de",
              label: "Navigator"
          }
        ];
        var pieOptions = {
            //Boolean - Whether we should show a stroke on each segment
            segmentShowStroke: true,
            //String - The colour of each segment stroke
            segmentStrokeColor: "#fff",
            //Number - The width of each segment stroke
            segmentStrokeWidth: 2,
            //Number - The percentage of the chart that we cut out of the middle
            percentageInnerCutout: 50, // This is 0 for Pie charts
            //Number - Amount of animation steps
            animationSteps: 200,
            //String - Animation easing effect
            animationEasing: "easeOutBounce",
            //Boolean - Whether we animate the rotation of the Doughnut
            animateRotate: true,
            //Boolean - Whether we animate scaling the Doughnut from the centre
            animateScale: false,
            //Boolean - whether to make the chart responsive to window resizing
            responsive: true,
            // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
            maintainAspectRatio: true,
            //String - A legend template            
        };
        //Create pie or douhnut chart
        // You can switch between pie and douhnut using the method below.
        pieChart.Doughnut(PieData, pieOptions);

    </script>

</asp:Content>
