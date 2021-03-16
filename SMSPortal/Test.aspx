<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SMSPortal.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script src="Content/bower_components/jquery/jquery.min.js"></script>--%>
    <script src="Content/bower_components/jquery/jquery.js"></script>
    <script>
        function ValidationField(params) {

            //alert("testing");
            //return false;
            $("#ErrorName").show();
            $("#ErrorMasking").show();
            //$("#ErrorName").text("check");

            var Name = $("#InputName").val();
            var Masking = $("#InputMasking").val();
            var MaskingLength = $("#InputMasking").val().length;

            $("#ErrorName").css('color', 'RED');
            $("#ErrorMasking").css('color', 'RED');

            if (Name == null || Name == "") {
                $("#ErrorName").text("Please Provide Client Name!");

                if (Masking == "" || Masking == null) {
                    $("#ErrorMasking").text("Please Enter the Masking Name!");
                } else {

                    if (MaskingLength != "11") {
                        $("#ErrorMasking").text("Masking Name must be 11 digits!");
                    } else {
                        $("#ErrorMasking").text("");
                    }

                }
                return false;
            } else {
                $("#ErrorName").test("");
                if (Masking == "" || Masking == null) {
                    $("#ErrorMasking").text("Please Enter the Masking Name!");
                    return false;
                } else {

                    if (MaskingLength != 11) {
                        $("#ErrorMasking").text("Masking Name must be 11 digits!");
                        return false;
                    } else {
                        $("#ErrorMasking").text("");
                        return true;
                        <%--var btnID = '<%=btnSave.ClientID %>';
                        __doPostBack(btnID, params);--%>

                    }
                }
            } 
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="row">
        <div class="well col-md-5 center login-box">
            <div class="alert alert-info">
                Client Registration Form
            </div>
            
            <fieldset>
                <div class="form-group">
                    <label for="InputName" class="control-label labelCss">Client Name:</label>
                    <input type="text" runat="server" class="form-control" id="InputName" placeholder="Client Name" />
                    <asp:Label ID="ErrorName" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
                <div class="clearfix"></div>
                <br/>

                <div class="form-group">
                    <label for="InputMasking" class="control-label labelCss">Masking Name:</label>
                    <input type="text" runat="server" class="form-control" id="InputMasking" placeholder="Masking Name" />
                    <asp:Label ID="ErrorMasking" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
                <div class="clearfix"></div>
                <br/>
                                    
                <div class="form-group">
                    <label class="remember labelCss" for="active">
                    <input type="checkbox" runat="server" id="active"/>
                    Active</label>
                </div>
                <div class="clearfix"></div>

                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-3"></div>
				    <div class="col-sm-3">
				        <button type="reset" class="btn btn-info btn-sm"><span class="glyphicon glyphicon-refresh"></span> Reset</button>
				    </div>

				    <div class="col-sm-3">
                        <%--<button id="btnsave1" runat="server" onclick="ValidationField('param1');" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-floppy-disk"></span> Save</button>--%>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="Submit"/>
				        <%--<asp:LinkButton ID="btnSubmet" runat="server" ClientIDMode="Static" OnClientClick="ValidationField('param1');" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>--%>
				    </div>
                </div>
            
                <p class="center col-md-5">
                    <%--<asp:LinkButton id="btnSignIn" runat="server" OnClick="btnSignIn_Click"  CssClass="btn btn-primary">Login</asp:LinkButton>--%>
                </p>
            </fieldset>
                        
        </div>
        <!--/span-->
    </div>
    </div>
    </form>
</body>
</html>
