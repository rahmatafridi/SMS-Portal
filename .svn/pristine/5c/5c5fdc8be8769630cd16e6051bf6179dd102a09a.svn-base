using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPortal.ScheduleSMS
{
    public partial class ScheduleSMS : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();
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
                        DDGroupname.DataSource = SMSPortalEntity.Groups.Where(x => x.StatusId == true && x.ClientId == LoggedUserDetails.ClientId).ToList();
                        DDGroupname.DataTextField = "GroupName";
                        DDGroupname.DataValueField = "GroupId";
                        DDGroupname.DataBind();
                        DDGroupname.Items.Insert(0, new ListItem("--Select Group Name--", ""));
                        DDGroupname.SelectedIndex = 0;
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
                txtMessage.Text = "";
                DateAndTime.Text = "";
                DDGroupname.SelectedIndex = 0;
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

        private void ErrorMsg(string msg)
        {
            dvsuccess.Visible = false;

            dverror.Visible = true;
            lblerror.Text = msg.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (DDGroupname.SelectedIndex == 0)
                    {

                        ErrorMsg("Please Select Valid Group");

                    }
                    else if (txtMessage.Text.ToString().Trim() == "")
                    {
                        ErrorMsg("Please Provide Text In Order To Send SMS.");
                        return;
                    }
                    else if(DateAndTime.Text.ToString().Trim()=="")
                   {
                    ErrorMsg("Please Prvide Date & Time ");
                    return;
                   }
                    else
                    {

                    SMSSchedule ssms = new SMSSchedule();
                    ssms.TextSms = txtMessage.Text;
                    ssms.UserId = LoggedUserDetails.Idpk;
                    ssms.ClientId = LoggedUserDetails.ClientId;
                    ssms.DateTime = Convert.ToDateTime(DateAndTime.Text.ToString());
                    ssms.CreatedOn = DateTime.Now;
                    ssms.CreatedBy = LoggedUserDetails.Idpk;
                    ssms.GroupId= Convert.ToInt32(DDGroupname.SelectedValue.ToString());
                    ssms.Status = 1;
                    ssms.UID = Guid.NewGuid();
                    db.SMSSchedules.Add(ssms);
                    db.SaveChanges();

                    SuccessMsg("Record Inserted Successfully");
                    ViewState["mode"] = null;
                    ResetAll();


                }

                    
                }
            catch (Exception ex)
            {

                throw;
            }

        }
        private void SuccessMsg(string msg)
        {
            dverror.Visible = false;

            dvsuccess.Visible = true;
            lblsuccess.Text = msg.ToString();
        }
    }
}