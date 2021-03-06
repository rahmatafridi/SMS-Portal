using HtmlAgilityPack;
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

namespace SMSPortal.ContactForm
{
    public partial class AddContact : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();
        DataTable myDataTable = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGroupCombo();
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
                        DDGroupname.DataSource = SMSPortalEntity.Groups.Where(x => x.StatusId == true && x.ClientId==LoggedUserDetails.ClientId).ToList();
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string error = "Please Enter ";
            try
            {
                // Checking SMS Package Expiry Date
                //if (CheckPackageExpiry())
                //{
                //    return;
                //}
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    string Line = string.Empty;
                    int lblIsFile = int.Parse(isFile.Value.ToString());
                    Guid guid;

                    if (lblIsFile == 0)
                    {

                        if (DDGroupname.SelectedIndex == 0)
                        {
                            error = error + "Group Name";
                            ErrorMsg(error);

                        }
                        else if (txtContactList.Text.ToString().Trim() == "")
                        {
                            ErrorMsg("Please Provide Valid List of Contacts In Order To Send SMS.");
                            return;
                        }
                        else
                        {

                            Group objgroup = new Group();
                            var numbers = txtContactList.Text;
                            var numspl = numbers.Split(',');


                            foreach (var item in numspl)
                            {
                                Contact objcontact = new Contact();

                                objcontact.GroupId = Convert.ToInt32(DDGroupname.SelectedValue.ToString());
                                objcontact.ContactNo = item.ToString();
                                //objcontact.GroupId = int.Parse(GroupName.SelectedValue.ToString());
                                objcontact.CreatedBy = 1;
                                objcontact.CreatedOn = DateTime.Now;
                                objcontact.UID = Guid.NewGuid();
                                smsPortalEntity.Contacts.Add(objcontact);

                            }

                            smsPortalEntity.SaveChanges();
                            SuccessMsg("Record Inserted Successfully");
                            ViewState["mode"] = null;
                            ResetAll();


                        }
                    }
                    else if(lblIsFile==1)
                    {
                        Contact objcontact = new Contact();
                        List<Contact> objContactList = new List<Contact>();
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
                                    //var numbers = txtContactList.Text;
                                    //var numspl = numbers.Split(',');
                                    string PreFix = "92";
                                    Line = GetNumberInProperFormat(Line, PreFix);
                                    drr = myDataTable.NewRow();
                                    drr["Number"] = Line;
                                    drr["Status"] = 0;
                                    myDataTable.Rows.Add(drr);
                               

                                }

                                objcontact = new Contact();

                                //Line = objcontact.ContactNo;
                                objcontact.ContactNo = Line;
                                objcontact.GroupId = Convert.ToInt32(DDGroupname.SelectedValue.ToString());
                                objcontact.CreatedBy = 1;
                                objcontact.CreatedOn = DateTime.Now;
                                objcontact.UID = guid;
                                objContactList.Add(objcontact);
                            }

                            smsPortalEntity.Contacts.AddRange(objContactList);
                            smsPortalEntity.SaveChanges();
                            SuccessMsg("Record Inserted Successfully");
                            ViewState["mode"] = null;
                            ResetAll();



                        }
                        catch (Exception ex)
                        {
                            ErrorMsg("Error Occured , Please Contact support team.");
                            wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
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
        protected void ResetAll()
        {
            try
            {
                
                txtContactList.Text = "";
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

    }
}