<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Default.Master" CodeBehind="AddContact.aspx.cs" Inherits="SMSPortal.ContactForm.AddContact" %>
   <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>--%>
    <script src="../Content/scripts/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clearfix"></div>
    <br />
    <br />
        <input id="isFile" runat="server" type="hidden" />

    <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        <div class="well col-lg-6 col-md-6 col-sm-6 ">
             <div class="alert alert-danger" runat="server" id="dverror" visible="false">
                <strong>ERROR !</strong>
                <asp:Label ID="lblerror" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="alert alert-success" runat="server" id="dvsuccess" visible="false">
                <strong>SUCCESS !</strong>
                <asp:Label ID="lblsuccess" runat="server" ClientIDMode="Static"></asp:Label>
            </div>

            <div class="clearfix"></div>
            <br />
               <%-- <div id="tbl" runat="server" class="col-lg-12 col-md-12 col-sm-12">     --%>     
            <fieldset>                   
            <div class="form-group">
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <label for="DDGroupname" class="control-label labelCss">Group Name:</label>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <asp:DropDownList ID="DDGroupname" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Label ID="lblMasking" runat="server" ClientIDMode="Static" Style="color: red"></asp:Label>
                </div>
                
            </div>
            <div class="clearfix"></div>
                <br />
             <div class="form-group">
                <div class="col-lg-4 col-md-4 col-sm-4">
                    <label for="lblMasking" class="control-label labelCss">Select Option:</label>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6">
                    <%--<asp:RadioButton ID="rdoList" runat="server" GroupName="SmsOption" Checked="true" ClientIDMode="Static" OnCheckedChanged AutoPostBack="true" />--%>
                    <input type="radio" class="radio-inline" name="contactType" value="0" id="RadioGroup1_0" checked="checked" onchange="setContacts(0)" />
                    &nbsp; Contacts List  &nbsp;&nbsp;
                    <%--<asp:RadioButton ID="rdoFile" runat="server" GroupName="SmsOption" ClientIDMode="Static" OnCheckedChanged="rdoFile_CheckedChanged" AutoPostBack="true" />--%>
                    <input type="radio" class="radio-inline" name="contactType" value="1" id="RadioGroup1_1"  onchange="setContacts(1)" />
                    &nbsp;Upload File &nbsp;&nbsp;
                </div>
            </div>
            <div class="clearfix"></div>
            <br />
            <div class="form-group" id="dvcontactlist" runat="server">
                <div class="col-lg-4 col-md-4 col-sm-4">
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
                <div class="col-lg-4 col-md-4 col-sm-4">
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
            <div class="row">
                <div class="col-lg-5 col-md-5 col-sm-5"></div>

                <div class="col-lg-4 col-md-4 col-sm-4">
                    <asp:LinkButton ID="btnReset" runat="server" class="btn btn-info" OnClick="btnReset_Click"><span class="glyphicon glyphicon-refresh"></span> Reset</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-success"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                </div>
            </div>

            </fieldset>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-3"></div>
        </div>

         <script type="text/javascript">
       

        function setContacts(id) {
            if (id == 1) {                                
                $("#ContentPlaceHolder1_dvcontactfile").show();
                $("#ContentPlaceHolder1_dvcontactlist").hide();                
                $("#ContentPlaceHolder1_isFile").val("1");
            }
            else {                
                $("#ContentPlaceHolder1_dvcontactlist").show();
                $("#ContentPlaceHolder1_dvcontactfile").hide();
                $("#ContentPlaceHolder1_isFile").val("0");
            }
        };
            window.onload = setContacts(0);

    </script>
</asp:Content>