using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;
using WXSecurity;

namespace SMSPortal.Users
{
    public partial class UserRegistration : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadUserCombo();
            }
        }

        private void LoadUserCombo()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    DDL_Name.DataSource = SMSPortalEntity.Users.ToList();
                    DDL_Name.DataTextField = "UserId";
                    DDL_Name.DataValueField = "Idpk";
                    DDL_Name.DataBind();
                    DDL_Name.Items.Insert(0, new ListItem("--Select User ID--", ""));

                    DDL_Client.DataSource = SMSPortalEntity.Clients.ToList();
                    DDL_Client.DataTextField = "Name";
                    DDL_Client.DataValueField = "Idpk";
                    DDL_Client.DataBind();
                    DDL_Client.Items.Insert(0, new ListItem("--Select Client Name--", ""));


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
            string a, b;
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    User user = SMSPortalEntity.Users.ToList().Where(X => X.Idpk == int.Parse(DDL_Name.SelectedValue.ToString())).FirstOrDefault();
                    InputUser.Value = user.UserId;                    
                    InputPassword.Value = user.Password;
                    Client client = SMSPortalEntity.Clients.ToList().Where(X => X.Idpk == int.Parse(user.ClientId.ToString())).FirstOrDefault();
                    a = Convert.ToString(client.Idpk);
                    b = client.Name;

                    DDL_Client.DataSource = SMSPortalEntity.Clients.ToList();
                    DDL_Client.DataTextField = "Name";
                    DDL_Client.DataValueField = "Idpk";
                    DDL_Client.DataBind();
                    //DDL_Client.Items.Insert(0, new ListItem(b, a));
                    DDL_Client.SelectedValue = a;

                    if (user.UserTypeId == 1)
                    {
                        rdoAdmin.Checked = true;
                    }
                    else
                    {
                        rdoAdmin.Checked = false;
                        if (user.UserTypeId == 2)
                        {
                            rdoUser.Checked = true;
                        }
                        else
                        {
                            rdoUser.Checked = false;
                        }
                    }


                    if (user.StatusId == 1)
                    {
                        active.Checked = true;
                    }
                    else
                    {
                        active.Checked = false;
                    }
                    ViewState["mode"] = "edit";
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
            try
            {
                if (ViewState["mode"] == null)
                {
                    SaveUser();
                }
                else if (ViewState["mode"].ToString().ToUpper() == "EDIT")
                {
                    UpdateUser();
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        private void SaveUser()
        {
            string error ="Please Enter";
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(InputUser.Value))
                    {
                        error = error + " User Name";
                        if (string.IsNullOrEmpty(InputPassword.Value))
                        {
                            error = error + ", Password";
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + ", Client Name";
                            }
                        }
                        else
                        {
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + ", Client Name";
                            }
                        }
                        ErrorMsg(error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(InputPassword.Value))
                        {
                            error = error + " Password";
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + ", Client Name";
                            }
                            ErrorMsg(error);
                        }
                        else
                        {
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + " Client Name";
                                ErrorMsg(error);
                            }
                            else
                            {
                                User user = new User();
                                user.UserId = InputUser.Value;
                                user.Password = EncryptionUtility.Encrypt(InputPassword.Value);
                                user.ClientId = Convert.ToInt32(DDL_Client.SelectedValue);
                                if (rdoAdmin.Checked)
                                {
                                    user.UserTypeId = 1;
                                }
                                else
                                {
                                    if (rdoUser.Checked)
                                    {
                                        user.UserTypeId = 2;
                                    }
                                }

                                if (active.Checked)
                                {
                                    user.StatusId = 1;
                                }
                                else
                                {
                                    user.StatusId = 0;
                                }
                                user.CreatedBy = 1;
                                user.CreatedOn = DateTime.Now;
                                user.UpdatedBy = 1;
                                user.UpdatedOn = DateTime.Now;

                                smsPortalEntity.Users.Add(user);
                                smsPortalEntity.SaveChanges();
                                SuccessMsg("Record Updated Successfully");
                                LoadUserCombo();
                                Reset();
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

        private void UpdateUser()
        {
            string error = "Please Enter";
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(InputUser.Value))
                    {
                        error = error + " User Name";
                        if (string.IsNullOrEmpty(InputPassword.Value))
                        {
                            error = error + ", Password";
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + ", Client Name";
                            }
                        }
                        else
                        {
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + ", Client Name";
                            }
                        }
                        ErrorMsg(error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(InputPassword.Value))
                        {
                            error = error + " Password";
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + ", Client Name";
                            }
                            ErrorMsg(error);
                        }
                        else
                        {
                            if (DDL_Client.SelectedIndex == 0)
                            {
                                error = error + " Client Name";
                                ErrorMsg(error);
                            }
                            else
                            {
                                User user = smsPortalEntity.Users.ToList().Where(X => X.Idpk == int.Parse(DDL_Name.SelectedValue.ToString())).FirstOrDefault();
                                user.UserId = InputUser.Value;
                                user.Password = EncryptionUtility.Encrypt(InputPassword.Value);
                                user.ClientId = Convert.ToInt32(DDL_Client.SelectedValue);
                                if (rdoAdmin.Checked)
                                {
                                    user.UserTypeId = 1;
                                }
                                else
                                {
                                    if (rdoUser.Checked)
                                    {
                                        user.UserTypeId = 2;
                                    }
                                }

                                if (active.Checked)
                                {
                                    user.StatusId = 1;
                                }
                                else
                                {
                                    user.StatusId = 0;
                                }
                                user.UpdatedBy = 2;
                                user.UpdatedOn = DateTime.Now;

                                smsPortalEntity.SaveChanges();
                                SuccessMsg("Record Updated Successfully");
                                ViewState["mode"] = null;
                                LoadUserCombo();
                                Reset();
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


        private void Reset()
        {
            DDL_Name.SelectedIndex = 0;
            InputUser.Value = "";
            InputPassword.Value = "";
            DDL_Client.SelectedIndex = 0;
            rdoUser.Checked = true;
            active.Checked = true;
            ViewState["mode"] = null;

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
    }
}