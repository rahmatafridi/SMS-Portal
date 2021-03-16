<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.Master" CodeBehind="ContactList.aspx.cs" Inherits="SMSPortal.ContactForm.ContactList" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>--%>
    <script src="../Content/scripts/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
   <%-- <form id="form1" runat="server">--%>
        <div class="clearfix"></div>
      <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        <div class="well col-lg-6 col-md-6 col-sm-6 " style="margin-top:10px;">

             <div class="alert alert-danger" runat="server" id="dverror" visible="false">
                <strong>ERROR !</strong>
                <asp:Label ID="lblerror" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
               <div class="clearfix"></div>
         
                <div id="tbl" runat="server" class="col-lg-12 col-md-12 col-sm-12">                             
               </div>
        </div>
      </div>
    <div>
   
    </div>
    <%--</form>--%>
</body>
</html>
    </asp:Content>
