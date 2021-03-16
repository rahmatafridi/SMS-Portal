using HtmlAgilityPack;
using SMSPortal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;
using WXSecurity;


namespace SMSPortal.SMS
{
    public partial class SMSCampaign : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        DataTable myDataTable = new DataTable();
        int SuccessCount = 0;
        int FailureCount = 0;
        SMSPortalEntity db = new SMSPortalEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("Authentication/Login.aspx", false);
            }
            if (!IsPostBack)
            {
                ResetAll();
                LoadMasking();
                txtMessage.Focus();
                dverror.Visible = false;
                dvsuccess.Visible = false;

                if (!IsPostBack)
                {
                    LoadGroupCombo();
                }
            }
        }
        private void LoadGroupCombo()
        {
            try
            {
                if (LoggedUserDetails.UserTypeId == 1)
                {
                    using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                    {
                        DDGroupname.DataSource = SMSPortalEntity.Groups.Where(x => x.StatusId == true).ToList();
                        DDGroupname.DataTextField = "GroupName";
                        DDGroupname.DataValueField = "GroupId";
                        DDGroupname.DataBind();
                        DDGroupname.Items.Insert(0, new ListItem("--Select Group Name--", ""));
                    }
                }
                else
                {
                    using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                    {
                        // int ClientId = int.Parse(ddlClientName.SelectedValue);
                        DDGroupname.DataSource = SMSPortalEntity.Groups.Where(x => x.StatusId == true && x.ClientId == LoggedUserDetails.ClientId).ToList();
                        DDGroupname.DataTextField = "GroupName";
                        DDGroupname.DataValueField = "GroupId";
                        DDGroupname.DataBind();
                        DDGroupname.Items.Insert(0, new ListItem("--Select Group Name--", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }
        protected void ResetAll()
        {
            try
            {
                txtMasking.Text = "";
                txtMessage.Text = "";
                txtContactList.Text = "";
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        private void LoadMasking()
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2)
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

                        //txtMasking.Text = clnt.Masking.ToString().ToUpper();
                        txtMasking.Text = clnt.Masking.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetAll();
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void MakeDataTable()
        {
            try
            {
                if (myDataTable.Columns.Count > 0)
                {
                    if (myDataTable.Rows.Count > 0)
                    {
                        myDataTable.Rows.Clear();
                    }
                    return;
                }
                DataColumn Number = new DataColumn("Number");
                Number.DataType = typeof(string);
                myDataTable.Columns.Add(Number);

                DataColumn Status = new DataColumn("Status");
                Status.DataType = typeof(int);
                myDataTable.Columns.Add(Status);
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }
        private int GetRemainingSMS()
        {
            int SMSCount = 0;
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2) // Regular User
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

                        AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

                        Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

                        var cpd = smsPortalEntity.SP_RemainingSMS(clnt.Idpk, pkg.Idpk);

                        int? Debit = 0;
                        int? Credit = 0;

                        foreach (SP_RemainingSMS_Result item in cpd)
                        {
                            Debit += item.DebitSMSQty;
                            Credit += item.CreditSMSQty;
                        }

                        SMSCount = int.Parse(Debit.ToString()) - int.Parse(Credit.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return SMSCount;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Checking SMS Package Expiry Date
                if (CheckPackageExpiry())
                {
                    return;
                }
                // Checking Remaining SMS Quantity
                else if (GetRemainingSMS() <= 0)
                {
                    return;
                }
                else
                {
                    string Line = string.Empty;
                    int lblIsFile = int.Parse(isFile.Value.ToString());
                    int lblIsGroup = int.Parse(IsGroup.Value.ToString());
                    Guid guid;
           


                    if (txtMessage.Text.Trim() == "")
                    {
                        ErrorMsg("Please Provide The SMS Which You Want To Send.");
                        return;
                    }
                    if (txtMasking.Text.Trim() == "")
                    {
                        LoadMasking();
                    }

                    if (lblIsFile == 0 && lblIsGroup==0)//Case When File Is Not Present
                    {
                        if (txtContactList.Text.ToString().Trim() == "")
                        {
                            ErrorMsg("Please Provide Valid List of Contacts In Order To Send SMS.");
                            return;
                        }
                        try
                        {
                            List<char> arr = new List<char>();
                            arr.Add('\'');
                            arr.Add('+');
                            arr.Add('/');
                            arr.Add('_');
                            arr.Add('<');
                            arr.Add('>');
                            arr.Add('~');
                            arr.Add('`');
                            arr.Add('^');
                            arr.Add(',');
                            arr.Add('#');

                            for (int k = 0; k < arr.Count; k++)
                            {
                                if (txtMessage.Text.ToString().Contains(arr[k]))
                                {
                                    ErrorMsg("There is " + arr[k].ToString() + " Special Character In Your SMS Please Remove And Proceed.");
                                    return;
                                }
                            }

                            if (SMS_Sending(txtContactList.Text.ToString().Trim(), txtMessage.Text.ToString().Trim()))
                            {

                                SuccessMsg("" + SuccessCount + " : " + "SMS Sent Successfully. SMS Failed To Send " + FailureCount + "");
                                ResetAll();
                                LoadMasking();

                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorMsg("Error Occured , Please Contact support team.");
                            wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
                        }
                    }
                    else if (lblIsFile == 1 && lblIsGroup==0)//Case When File Is Present
                    {
                        if (fulContactFile.PostedFile.FileName == "")
                        {
                            ErrorMsg("Provide List of Numbers On Which You Want To Send SMS.");
                            return;
                        }


                        string fileName = System.IO.Path.GetFileName(fulContactFile.PostedFile.FileName);

                        string fileExt = fileName.Substring(fileName.LastIndexOf("."));

                        if (fileExt != ".txt")
                        {
                            ErrorMsg("Please Provide File With Valid Extension i.e (.txt).");
                            return;
                        }

                        guid = Guid.NewGuid();

                        try
                        {
                            fulContactFile.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + guid + fileName));

                            string Path = Server.MapPath("~/Uploads/" + guid + fileName);

                            System.IO.StreamReader file = new System.IO.StreamReader(Path);


                            MakeDataTable();
                            DataRow drr;
                            while ((Line = file.ReadLine()) != null)
                            {
                                if (Line != "" && Line.Length == 11)
                                {
                                    string PreFix = "92";
                                    Line = GetNumberInProperFormat(Line, PreFix);
                                    drr = myDataTable.NewRow();
                                    drr["Number"] = Line;
                                    drr["Status"] = 0;
                                    myDataTable.Rows.Add(drr);
                                }
                            }
                            int i = 0;
                            int counter = i;
                            StringBuilder st = new StringBuilder();
                            Hashtable ht = new Hashtable();
                            for (i = 0; i < myDataTable.Rows.Count; i++)
                            {
                                if (st.Length == 0)
                                {
                                    st.Append(myDataTable.Rows[i]["Number"].ToString());
                                }
                                else
                                {
                                    st.Append(",");
                                    st.Append(myDataTable.Rows[i]["Number"].ToString());
                                }
                                counter = counter + 1;

                                if (counter == 1000 || i == myDataTable.Rows.Count - 1)
                                {
                                    counter = 0;
                                    ht.Add(i.ToString(), st.ToString());
                                    st = new StringBuilder();
                                }
                            }
                            foreach (object key in ht.Keys)
                            {
                                //sendsms(ht[key].ToString());
                                List<char> arr = new List<char>();
                                arr.Add('\'');
                                arr.Add('+');
                                arr.Add('/');
                                arr.Add('_');
                                arr.Add('<');
                                arr.Add('>');
                                arr.Add('~');
                                arr.Add('`');
                                arr.Add('^');
                                arr.Add(',');
                                arr.Add('#');

                                for (int k = 0; k < arr.Count; k++)
                                {
                                    if (txtMessage.Text.ToString().Contains(arr[k]))
                                    {
                                        ErrorMsg("There is " + arr[k].ToString() + " Special Character In Your SMS Please Remove And Proceed.");
                                        return;
                                    }
                                }

                                if (SMS_Sending(ht[key].ToString(), txtMessage.Text.ToString().Trim()))
                                {

                                    SuccessMsg("" + SuccessCount + " : " + "SMS Sent Successfully. SMS Failed To Send " + FailureCount + "");
                                    ResetAll();
                                    LoadMasking();
                                }
                                else
                                {
                                    ErrorMsg("Some Error Occured While Sending SMS. Please Contact Support Team.");
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            ErrorMsg("Error Occured , Please Contact support team.");
                            wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
                        }
                    }
                    else if(lblIsGroup == 1 && lblIsFile==0)
                    {

                        if (DDGroupname.SelectedIndex == 0)
                        {

                            ErrorMsg("Please Select the Valid Group");

                        }
                        else
                        {


                            int Groupid = Convert.ToInt32(DDGroupname.SelectedValue.ToString());
                            var listcontact = db.Contacts.Where(x => x.GroupId == Groupid).ToList();
                            List<Contact> cont = new List<Contact>();
                            string[] items = new string[] { };


                            try
                            {
                                List<char> arr = new List<char>();
                                arr.Add('\'');
                                arr.Add('+');
                                arr.Add('/');
                                arr.Add('_');
                                arr.Add('<');
                                arr.Add('>');
                                arr.Add('~');
                                arr.Add('`');
                                arr.Add('^');
                                arr.Add(',');
                                arr.Add('#');

                                for (int k = 0; k < arr.Count; k++)
                                {
                                    if (txtMessage.Text.ToString().Contains(arr[k]))
                                    {
                                        ErrorMsg("There is " + arr[k].ToString() + " Special Character In Your SMS Please Remove And Proceed.");
                                        return;
                                    }
                                }
                                var Contactno = "";
                                Contact objcontat = new Contact();
                                List<Contact> objlist = new List<Contact>();
                                string csvString = "";

                                csvString = string.Join(",", listcontact.Select(x => x.ContactNo).ToArray());



                                if (SMS_Sending(csvString.ToString().Trim(), txtMessage.Text.ToString().Trim()))
                                {

                                    SuccessMsg("" + SuccessCount + " : " + "SMS Sent Successfully. SMS Failed To Send " + FailureCount + "");
                                    ResetAll();
                                    LoadMasking();

                                }

                            }
                            catch (Exception ex)
                            {
                                ErrorMsg("Error Occured , Please Contact support team.");
                                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        private string GetNumberInProperFormat(string Number, string PreFix)
        {
            string ProperNumber = "";
            try
            {
                if (Number.Length > 0 && Number.StartsWith("0"))
                {
                    Number = Number.Remove(0, 1);

                    ProperNumber = PreFix + Number;
                }

            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return ProperNumber;
        }

        private bool SMS_Sending(string ToNumber, string msg)
        {
            bool Status = false;
            try
            {
                int RemainingSMS = GetRemainingSMS();

                string host = "";
                string msisdn = "";
                string password = "";
                string masking = "";
                string url = "";
                string smsurl = "";
                string myparams;
                string response = "";

                msisdn = "beautex@bizsms.pk";
                password = "b3a4t3x4t";
                masking = txtMasking.Text.Trim();

                myparams = "username=" + msisdn + "&password=" + password + "&text=" + msg + "&masking=" + masking;

                HttpClient client = new HttpClient();
                HttpClient clientSMS = new HttpClient();
                string contactN0 = ToNumber;
                if (GetRemainingSMS() < TotalSMSCount(ToNumber))
                {
                    ErrorMsg("Insufficient SMS Balance");
                    return false;
                }

                string[] str = ToNumber.Split(',');

                foreach (var number in str)
                {
                    smsurl = "http://mass.bizsms.pk/api-send-branded-sms.aspx?" + "username=" + msisdn + "&pass=" + password + "&text=" + msg + "&masking=" + masking + "&destinationnum=" + number + "&language=English";

                    var postSMS = client.PostAsync(smsurl, new StringContent(myparams)).Result;

                    if (postSMS.StatusCode == HttpStatusCode.OK)
                    {
                        string result = postSMS.Content.ReadAsStringAsync().Result;

                        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                        string htmlString = result;
                        document.LoadHtml(htmlString);
                        HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//span");
                        foreach (HtmlNode node in collection)
                        {
                            response = node.InnerHtml;
                        }
                        if (response.ToUpper() == "SMS SENT SUCCESSFULLY.")
                        {
                            string mySuccessNo = "1";
                            string myFailNo = "0";
                            SuccessCount = SuccessCount + int.Parse(mySuccessNo);
                            FailureCount = FailureCount + int.Parse(myFailNo);

                            int SMSCount = 1;
                            if (msg.Length > 160)
                            {
                                SMSCount = 2;
                            }
                            if (msg.Length > 320)
                            {
                                SMSCount = 3;
                            }
                            if (msg.Length > 480)
                            {
                                SMSCount = 4;
                            }
                            if (msg.Length > 640)
                            {
                                SMSCount = 5;
                            }

                            if (SendSMSLog(SMSCount, number, int.Parse(mySuccessNo), int.Parse(myFailNo)) > 0)
                            {
                                if (InsertSendSMSCampaign(txtMessage.Text, RemainingSMS, SMSCount, number, int.Parse(mySuccessNo), FailureCount) > 0)
                                {
                                    Status = true;
                                }
                            }
                        }
                        else if (response.ToUpper() == "INVALID PARAMETERS")
                        {
                            Status = false;
                        }
                        else
                        {
                            string mySuccessNo = string.Empty;
                            string myFailNo = string.Empty;
                            string[] stringLines = response.Split('.');
                            if (stringLines[0].Length != 0)
                            {
                                mySuccessNo = Regex.Replace(stringLines[0], @"\D", "");
                                SuccessCount = SuccessCount + int.Parse(mySuccessNo);
                            }
                            if (stringLines[1].Length != 0)
                            {
                                myFailNo = Regex.Replace(stringLines[1], @"\D", "");
                                FailureCount = FailureCount + int.Parse(myFailNo);
                            }
                            string[] numCount = ToNumber.Split(',');
                            int ContactsCount = numCount.Length;
                            int SMSCount = 1;
                            if (msg.Length > 160)
                            {
                                SMSCount = 2;
                            }
                            if (msg.Length > 320)
                            {
                                SMSCount = 3;
                            }
                            if (msg.Length > 480)
                            {
                                SMSCount = 4;
                            }
                            if (msg.Length > 640)
                            {
                                SMSCount = 5;
                            }

                            if (SendSMSLog(SMSCount, ToNumber, SuccessCount, FailureCount) > 0)
                            {
                                if (InsertSendSMSCampaign(txtMessage.Text, RemainingSMS, SMSCount, ToNumber, SuccessCount, FailureCount) > 0)
                                {
                                    Status = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return Status;
        }

        private int SendSMSLog(int SMSLength, string NoOfSMS, int TotalSentSMS, int TotalFailedSMS)
        {
            int status = 0;

            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2) // Regular / Client User
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

                        AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

                        Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

                        ClientPackageDetail cpd = new ClientPackageDetail();

                        //string[] str = NoOfSMS.Split(',');
                        SMSLength = SMSLength * 1;
                       
                        cpd.ContactNo = NoOfSMS.ToString();
                        cpd.Idpk = 0;
                        cpd.ClientId = clnt.Idpk;
                        cpd.PackageId = pkg.Idpk;
                        cpd.DebitSMSQty = 0;
                        cpd.CreditSMSQty = TotalSentSMS;
                        cpd.StatusId = 1;
                        cpd.CreatedBy = LoggedUserDetails.Idpk;
                        cpd.CreatedOn = DateTime.Now;
                        cpd.UpdatedBy = LoggedUserDetails.Idpk;
                        cpd.UpdatedOn = DateTime.Now;
                        cpd.TotalScheduledSMS = SMSLength;
                        cpd.TotalSentSMS = TotalSentSMS;
                        cpd.TotalFailedSMS = TotalFailedSMS;
                        smsPortalEntity.ClientPackageDetails.Add(cpd);
                        status = smsPortalEntity.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return status;
        }

        private int InsertSendSMSCampaign(string SMSText, int SMSCountBefore, int SMSLength, string NoOfSMS, int TotalSentSMS, int TotalFailedSMS)
        {
            int status = 0;

            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2) // User / Client User
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

                        AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

                        Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

                        SMSCampain smscampaign = new SMSCampain();

                        //string[] str = NoOfSMS.Split(',');
                        SMSLength = SMSLength * 1;

                        smscampaign.Idpk = 0;
                        smscampaign.ClientId = clnt.Idpk;
                        smscampaign.SMSText = SMSText;
                        smscampaign.CharacterCount = SMSText.Length;
                        smscampaign.Success = TotalSentSMS;
                        smscampaign.Failure = TotalFailedSMS;
                        smscampaign.SMSCountBefore = SMSCountBefore;
                        smscampaign.StatusId = 1;
                        smscampaign.CreatedBy = LoggedUserDetails.Idpk;
                        smscampaign.UpdatedBy = LoggedUserDetails.Idpk;
                        smscampaign.CreatedOn = DateTime.Now;
                        smscampaign.UpdatedOn = DateTime.Now;
                        smscampaign.ContactNo = NoOfSMS;
                        smsPortalEntity.SMSCampains.Add(smscampaign);
                        status = smsPortalEntity.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return status;
        }

        private void ErrorMsg(string msg)
        {
            dvsuccess.Visible = false;

            dverror.Visible = true;
            lblerror.Text = msg.ToString();
        }

        private void SuccessMsg(string msg)
        {
            dverror.Visible = false;

            dvsuccess.Visible = true;
            lblsuccess.Text = msg.ToString();
        }

        private bool CheckPackageExpiry()
        {
            bool IsExpired = false;
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2)
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

                        AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

                        Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

                        var cpd = smsPortalEntity.SP_RemainingSMS(clnt.Idpk, pkg.Idpk);

                        if (DateTime.Now.Date >= DateTime.Parse(apkg.EndDate.ToString()).Date)
                        {
                            IsExpired = true;
                            ErrorMsg("Your SMS Package Has Been Expired.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return IsExpired;
        }

        //private int GetRemainingSMS()
        //{
        //    int SMSCount = 0;
        //    try
        //    {
        //        using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
        //        {
        //            User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

        //            if (usr.UserTypeId == 2)
        //            {
        //                Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

        //                AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

        //                Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

        //                var cpd = smsPortalEntity.SP_RemainingSMS(clnt.Idpk, pkg.Idpk);

        //                int? Debit = 0;
        //                int? Credit = 0;

        //                foreach (SP_RemainingSMS_Result item in cpd)
        //                {
        //                    Debit += item.DebitSMSQty;
        //                    Credit += item.CreditSMSQty;
        //                }

        //                SMSCount = int.Parse(Debit.ToString()) - int.Parse(Credit.ToString());
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMsg("Error Occured , Please Contact support team.");
        //        wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
        //    }
        //    return SMSCount;
        //}

        private int TotalSMSCount(string Numbers)
        {
            int Count = 0;
            try
            {
                int smschars = 160;
                if (txtMessage.Text.Length > 0 && txtMessage.Text.Length <= (1 * smschars))
                {
                    Count = 1;
                }
                else if (txtMessage.Text.Length > (1 * smschars) && txtMessage.Text.Length <= (2 * smschars))
                {
                    Count = 2;
                }
                else if (txtMessage.Text.Length > (2 * smschars) && txtMessage.Text.Length <= (3 * smschars))
                {
                    Count = 3;
                }
                else if (txtMessage.Text.Length > (3 * smschars) && txtMessage.Text.Length <= (4 * smschars))
                {
                    Count = 4;
                }
                else if (txtMessage.Text.Length > (4 * smschars) && txtMessage.Text.Length <= (5 * smschars))
                {
                    Count = 5;
                }
                else if (txtMessage.Text.Length > (5 * smschars) && txtMessage.Text.Length <= (6 * smschars))
                {
                    Count = 6;
                }
                else if (txtMessage.Text.Length > (6 * smschars) && txtMessage.Text.Length <= (7 * smschars))
                {
                    Count = 7;
                }

                string[] str = Numbers.Split(',');

                Count = Count * str.Count();




            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return Count;
        }

        public void UploadFtpFile()
        {

            FtpWebRequest request;
            try
            {
                string Domain = "webixoft.net";
                string SubDomain = "sms.webixoft.net";
                string Folder = "Uploads";
                string FileName = Server.MapPath(fulContactFile.FileName);
                string absoluteFileName = Path.GetFileName(FileName);

                string User = "webixoft";
                string Password = "Fl@tr0Ne2240";

                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", Domain, SubDomain, Folder, absoluteFileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(User, Password);
                request.ConnectionGroupName = "group";

                using (FileStream fs = File.OpenRead(FileName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }


    }
}