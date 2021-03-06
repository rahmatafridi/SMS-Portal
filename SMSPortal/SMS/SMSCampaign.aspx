<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SMSCampaign.aspx.cs" Inherits="SMSPortal.SMS.SMSCampaign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>--%>
    <script src="../Content/scripts/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="clearfix"></div>
    <br />
    <br />
    <input id="isFile" runat="server" type="hidden" />
    <input id="IsGroup" runat="server" type="hidden" />
    <div class="row">
        <div class="col-lg-2 col-md-2 col-sm-2"></div>
        <div class="well col-lg-8 col-md-8 col-sm-8 ">
            <div class="alert alert-info">
                SMS Campaigning
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
            <div class="form-group">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="lblMasking" class="control-label labelCss">Select Option:</label>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <%--<asp:RadioButton ID="rdoList" runat="server" GroupName="SmsOption" Checked="true" ClientIDMode="Static" OnCheckedChanged AutoPostBack="true" />--%>
                    <input type="radio" class="radio-inline" name="contactType" value="0" id="RadioGroup1_0" checked="checked" onchange="setContacts(0)" />
                    &nbsp; Contacts List  &nbsp;&nbsp;
                    <%--<asp:RadioButton ID="rdoFile" runat="server" GroupName="SmsOption" ClientIDMode="Static" OnCheckedChanged="rdoFile_CheckedChanged" AutoPostBack="true" />--%>
                    <input type="radio" class="radio-inline" name="contactType" value="1" id="RadioGroup1_1"  onchange="setContacts(1)" />
                    &nbsp; Upload File &nbsp;&nbsp;
                     <input type="radio" class="radio-inline" name="contactType" value="2" id="RadioGroup1_2"  onchange="setContacts(2)" />
                     Group &nbsp;&nbsp;
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group" id="dvcontactlist" runat="server">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="lblforContactList" class="control-label labelCss">
                        Contacts:
                        <br />
                        (Comma Separated)</label>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <asp:TextBox ID="txtContactList" runat="server" class="form-control" TextMode="MultiLine" Rows="5" Style="resize: none;"></asp:TextBox>
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group" id="dvcontactfile" runat="server" >
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="lblforContactFile" class="control-label labelCss">
                        Contacts File:
                        <br />
                        (Text File Only)</label>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <asp:FileUpload ID="fulContactFile" runat="server" />
                </div>
            </div>
             <div class="clearfix"></div>
            <br /> 
               <div class="form-group" id="dropGroup" runat="server">
                <div class="col-lg-2 col-md-2 col-sm-2">
                    <label for="DDGroupname" class="control-label labelCss">Group Name:</label>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <asp:DropDownList ID="DDGroupname" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                
            </div>
            <div class="clearfix"></div>
    
            <br />
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4"></div>

                <div class="col-lg-5 col-md-5 col-sm-5" style="margin-left:117px;">
                    <asp:LinkButton ID="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                </div>
            </div>

        </div>


    </div>
    <div class="col-lg-2 col-md-2 col-sm-2"></div>

    <script type="text/javascript">
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

        function setContacts(id) {
            if (id == 1) {                                
                $("#ContentPlaceHolder1_dvcontactfile").show();
                $("#ContentPlaceHolder1_dvcontactlist").hide();
                $("#ContentPlaceHolder1_dropGroup").hide();
                
                $("#ContentPlaceHolder1_isFile").val("1");
                $("#ContentPlaceHolder1_IsGroup").val("0");
            }
            else if(id==0) {                
                $("#ContentPlaceHolder1_dvcontactlist").show();
                $("#ContentPlaceHolder1_dvcontactfile").hide();
                $("#ContentPlaceHolder1_dropGroup").hide();
                $("#ContentPlaceHolder1_isFile").val("0");
                $("#ContentPlaceHolder1_IsGroup").val("0");

            }
            else {
                $("#ContentPlaceHolder1_dvcontactlist").hide();
                $("#ContentPlaceHolder1_dvcontactfile").hide();
                $("#ContentPlaceHolder1_dropGroup").show();
                $("#ContentPlaceHolder1_isFile").val("0");
                $("#ContentPlaceHolder1_IsGroup").val("1");
            }
        };
            window.onload = setContacts(0);

    </script>

</asp:Content>
