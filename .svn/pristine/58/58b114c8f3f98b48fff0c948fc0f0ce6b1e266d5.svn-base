<%@ Page Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ScheduleSMS.aspx.cs" Inherits="SMSPortal.ScheduleSMS.ScheduleSMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   
    <script src="../Content/scripts/jquery.min.js"></script>

    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="clearfix"></div>
    <br />

 
    <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-2"></div>
        <div class="well col-lg-8 col-md-8 col-sm-8 ">
            <div class="alert alert-info">
                Schedule SMS
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
                    <label for="lblMasking" class="control-label labelCss">Masking:</label>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <asp:TextBox ID="txtMasking" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
           
            <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="lblDate" class="control-label labelCss">DateTime:</label>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5">
                      <div class='input-group date' id='datetimepicker1'>
                    <asp:TextBox ID="DateAndTime" runat="server" CssClass="form-control date"></asp:TextBox>
                           <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                          </div>
                </div>
            </div>
          
               <div class="clearfix"></div>
            <br />
            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="lblSmsContent" class="control-label labelCss">Your Message:</label>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5">
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" class="form-control" Rows="5" Style="resize: none;" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="lblforSmsCount" class="control-label labelCss">SMS Count:</label><br />
                    <label for="lblforCharCount" class="control-label labelCss">Character Count:</label><br />
                    <label for="lblforLeftCharCount" class="control-label labelCss">Character Left:</label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3">
                    <asp:Label ID="lblMsgCount" runat="server" class="control-label labelCss" ClientIDMode="Static"></asp:Label>
                    <br />
                    <asp:Label ID="lblCount" runat="server" class="control-label labelCss" ClientIDMode="Static"></asp:Label>
                    <br />
                    <asp:Label ID="lblTotalCharcters" runat="server" class="control-label labelCss" ClientIDMode="Static"></asp:Label>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
         
           
        
            <br /> 
               <div class="form-group" id="dropGroup" runat="server">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="DDGroupname" class="control-label labelCss">Group Name:</label>
                </div>
                <div class="col-lg-5 col-md-5 col-sm-5">
                    <asp:DropDownList ID="DDGroupname" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                
            </div>
            <div class="clearfix"></div>
    
            <br />
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4"></div>

                <div class="col-lg-5 col-md-5 col-sm-5" style="margin-left:50px;">
                    <asp:LinkButton ID="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                </div>
            </div>

        </div>


    </div>
    <div class="col-lg-2 col-md-2 col-sm-2"></div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#datetimepicker1').datetimepicker({
                //locale: 'ru'
            });
        })
       
        $('#txtMessage').keyup(

        function () {

            $('#lblCount').text(160 - this.value.length);
            $('#lblTotalCharcters').text(this.value.length);
            $('#lblMsgCount').text("1");



            if (this.value.length == 0) {
                $('#lblCount').text(this.value.length);
                $('#lblTotalCharcters').text(this.value.length);
                $('#lblMsgCount').text("0");
            }


            if (this.value.length > 160) {
                $('#lblCount').text(320 - this.value.length);
                $('#lblMsgCount').text("2");
            }

            if (this.value.length > 320) {
                $('#lblCount').text(480 - this.value.length);
                $('#lblMsgCount').text("3");
            }

            if (this.value.length > 480) {
                $('#lblCount').text(640 - this.value.length);
                $('#lblMsgCount').text("4");
            }

            if (this.value.length > 640) {
                $('#lblCount').text(800 - this.value.length);
                $('#lblMsgCount').text("5");
            }

            if (this.value.length > 800) {
                $('#lblCount').text(960 - this.value.length);
                $('#lblMsgCount').text("6");
            }

            if (this.value.length > 960) {
                $('#lblCount').text(1120 - this.value.length);
                $('#lblMsgCount').text("7");
            }
        }
        );
        
     

    </script>

</asp:Content>