using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;
using WXSecurity;

namespace SMSPortal.Groups
{
    public partial class AddGroups : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (LoggedUserDetails.UserTypeId == 1) // Admin
                {
                    LoadGroupCombo();
                    LoadClientCombo();
                }
                else if (LoggedUserDetails.UserTypeId == 2) // Regular User
                {
                    LoadClientCombo();
                    LoadGroupCombo();
                }

            }
        }

        private void LoadGroupCombo()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (LoggedUserDetails.UserTypeId == 1) // Admin
                    {
                        //if (ddlClientName.SelectedIndex == -1)
                        //{
                        //    GroupNameDD.Items.Insert(0, new ListItem("--Select Group Name--", ""));
                        //}
                        //else
                        //{
                          //  int ClientId = int.Parse(ddlClientName.SelectedValue);
                            //GroupNameDD.DataSource = SMSPortalEntity.Groups.ToList();
                            //GroupNameDD.DataTextField = "GroupName";
                            //GroupNameDD.DataValueField = "GroupId";
                            //GroupNameDD.DataBind();
                            //GroupNameDD.Items.Insert(0, new ListItem("--Select Group Name--", ""));

                        GroupNameDD.DataSource = SMSPortalEntity.Groups.ToList();
                        GroupNameDD.DataTextField = "GroupName";
                        GroupNameDD.DataValueField = "GroupId";
                        GroupNameDD.DataBind();
                        GroupNameDD.Items.Insert(0, new ListItem("--Select Group Name--", ""));
                        //}
                    }
                    else if (LoggedUserDetails.UserTypeId == 2) // Regular User
                    {
                        int ClientId = int.Parse(ddlClientName.SelectedValue);
                        GroupNameDD.DataSource = SMSPortalEntity.Groups.Where(x => x.ClientId == ClientId).ToList();
                        GroupNameDD.DataTextField = "GroupName";
                        GroupNameDD.DataValueField = "GroupId";
                        GroupNameDD.DataBind();
                        GroupNameDD.Items.Insert(0, new ListItem("--Select Group Name--", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        private void LoadClientCombo()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (LoggedUserDetails.UserTypeId == 1) // Admin
                    {
                        ddlClientName.DataSource = SMSPortalEntity.Clients.Where(x => x.StatusId == 1).ToList();
                        ddlClientName.DataTextField = "Name";
                        ddlClientName.DataValueField = "Idpk";
                        ddlClientName.DataBind();
                        ddlClientName.Items.Insert(0, new ListItem("--Select Client--", ""));
                    }
                    else if (LoggedUserDetails.UserTypeId == 2) // regular User
                    {
                        ddlClientName.DataSource = SMSPortalEntity.Clients.Where(x => x.StatusId == 1 && x.Idpk == LoggedUserDetails.ClientId).ToList();
                        ddlClientName.DataTextField = "Name";
                        ddlClientName.DataValueField = "Idpk";
                        ddlClientName.DataBind();
                        ddlClientName.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void btn_Search_ServerClick(object sender, EventArgs e)
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    Group package = SMSPortalEntity.Groups.ToList().Where(X => X.GroupId == int.Parse(GroupNameDD.SelectedValue.ToString())).FirstOrDefault();
                    GroupName.Value = package.GroupName;
                    ddlClientName.SelectedValue = package.ClientId.ToString();
                    if (package.StatusId == true)
                    {
                        active.Checked = true;
                    }
                    else
                    {
                        active.Checked = false;
                    }
                    ViewState["mode"] = "edit";

                    GroupNameDD.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (ViewState["mode"] == null)
            {
                SavePackage();
            }
            else if (ViewState["mode"].ToString().ToUpper() == "EDIT")
            {
                UpdatePackage();
            }
        }

        protected void SavePackage()
        {
            string error = string.Empty;
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(GroupName.Value))
                    {
                        error = error + "Please Enter Client Name";
                        ErrorMsg(error);
                        return;
                    }

                    Group objGroup_ = new Group();
                    objGroup_ = SMSPortalEntity.Groups.Where(x => x.GroupName == GroupName.Value).FirstOrDefault();


                    if (objGroup_ != null) // Group Name Already Exist
                    {
                        error = "Group Name Already Exist. Please try some other name.";
                        ErrorMsg(error);
                        return;
                    }
                    else
                    {
                        Group objGroup = new Group();
                        objGroup.GroupName = GroupName.Value;
                        objGroup.UID = Guid.NewGuid();
                        if (active.Checked)
                        {
                            objGroup.StatusId = true;
                        }
                        else
                        {
                            objGroup.StatusId = false;
                        }

                        objGroup.ClientId = int.Parse(ddlClientName.SelectedValue);

                        objGroup.CreatedOn = DateTime.Now;
                        objGroup.CreatedBy = 1;


                        SMSPortalEntity.Groups.Add(objGroup);

                        SMSPortalEntity.SaveChanges();
                        SuccessMsg("Group Added Successfully");
                        ViewState["mode"] = null;                        
                        Reset();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void UpdatePackage()
        {
            string error = string.Empty;
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(GroupName.Value))
                    {
                        error = error + "Please Enter Client Name!";
                        ErrorMsg(error);
                        return;
                    }

                    Group objGroup_ = new Group();
                    int GroupId = int.Parse(GroupNameDD.SelectedValue.ToString());
                    objGroup_ = SMSPortalEntity.Groups.Where(x => x.GroupName == GroupName.Value && x.GroupId != GroupId).FirstOrDefault();

                    if (objGroup_ != null) // Group Name Already Exist
                    {
                        error = "Group Name Already Exist. Please try some other name.";
                        ErrorMsg(error);
                        return;
                    }
                    else
                    {
                        Group package = SMSPortalEntity.Groups.ToList().Where(X => X.GroupId == int.Parse(GroupNameDD.SelectedValue.ToString())).FirstOrDefault();
                        package.GroupName = GroupName.Value;


                        if (active.Checked)
                        {
                            package.StatusId = true;
                        }
                        else
                        {
                            package.StatusId = false;
                        }

                        package.UpdateOn = DateTime.Now;
                        package.UpdateBy = LoggedUserDetails.Idpk;
                        package.ClientId = int.Parse(ddlClientName.SelectedValue);

                        SMSPortalEntity.SaveChanges();
                        SuccessMsg("Record Updated Successfully");
                        ViewState["mode"] = null;                        
                        Reset();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        private void Reset()
        {
            try
            {
                GroupName.Value = "";
                active.Checked = true;
                GroupNameDD.Enabled = true;
                LoadClientCombo();
                LoadGroupCombo();
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
                Reset();
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadGroupCombo();
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }
    }
}