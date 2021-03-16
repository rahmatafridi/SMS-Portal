using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;

namespace SMSPortal.Clients
{
    public partial class ClientRegistration : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {

            //string parameter = Request["__EVENTARGUMENT"];
            //if (parameter == "param1")
            //    btnSave_Click(sender, e);

            if (!IsPostBack)
            {
                LoadClientCombo();
            }
        }

        private void LoadClientCombo()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    DDL_Name.DataSource = SMSPortalEntity.Clients.ToList();
                    DDL_Name.DataTextField = "Name";
                    DDL_Name.DataValueField = "Idpk";
                    DDL_Name.DataBind();
                    DDL_Name.Items.Insert(0, new ListItem("--Select Client Name--", ""));
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
            try
            {
                if (ViewState["mode"] == null)
                {
                    SaveNewRecord();
                }
                else if (ViewState["mode"].ToString().ToUpper() == "EDIT")
                {
                    UpdateRecord();
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    Client client = SMSPortalEntity.Clients.ToList().Where(X => X.Idpk == int.Parse(DDL_Name.SelectedValue.ToString())).FirstOrDefault();
                    InputName.Value = client.Name;
                    InputMasking.Value = client.Masking;
                    if (client.StatusId == 1)
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

        protected void SaveNewRecord()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(InputName.Value))
                    {
                        ErrorName.Text = "Please Enter The Client Name!";
                        if (string.IsNullOrEmpty(InputMasking.Value))
                        {
                            ErrorMasking.Text = "Please Enter The Masking Name!";
                        }
                        else
                        {
                            if (InputMasking.Value.Length > 11)
                            {
                                ErrorMasking.Text = "Please Enter the 11 character Masking Name!";
                            }
                        }
                    }
                    else
                    {
                        ErrorName.Text = "";
                        if (string.IsNullOrEmpty(InputMasking.Value))
                        {
                            ErrorMasking.Text = "Please Enter The Masking Name!";
                        }
                        else
                        {
                            if (InputMasking.Value.Length > 11)
                            {
                                ErrorMasking.Text = "Please Enter the 11 character Masking Name!";
                            }
                            else
                            {
                                ErrorMasking.Text = "";
                                Client client = new Client();
                                client.Name = InputName.Value;
                                client.Masking = InputMasking.Value;

                                if (active.Checked)
                                {
                                    client.StatusId = 1;
                                }
                                else
                                {
                                    client.StatusId = 0;
                                }
                                client.CreatedOn = DateTime.Now;
                                client.CreatedBy = LoggedUserDetails.Idpk;
                                client.UpdatedOn = DateTime.Now;
                                client.UpdatedBy = LoggedUserDetails.Idpk;

                                SMSPortalEntity.Clients.Add(client);
                                SMSPortalEntity.SaveChanges();

                                SuccessMsg("Record Inserted Successfully");
                                LoadClientCombo();
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

        protected void UpdateRecord()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(InputName.Value))
                    {
                        ErrorName.Text = "Please Enter The Client Name!";
                        if (string.IsNullOrEmpty(InputMasking.Value))
                        {
                            ErrorMasking.Text = "Please Enter The Masking Name!";
                        }
                        else
                        {
                            if (InputMasking.Value.Length > 11)
                            {
                                ErrorMasking.Text = "Please Enter the 11 character Masking Name!";
                            }
                        }
                    }
                    else
                    {
                        ErrorName.Text = "";
                        if (string.IsNullOrEmpty(InputMasking.Value))
                        {
                            ErrorMasking.Text = "Please Enter The Masking Name!";
                        }
                        else
                        {
                            if (InputMasking.Value.Length > 11)
                            {
                                ErrorMasking.Text = "Please Enter the 11 character Masking Name!";
                            }
                            else
                            {
                                ErrorMasking.Text = "";
                                Client client = SMSPortalEntity.Clients.ToList().Where(X => X.Idpk == int.Parse(DDL_Name.SelectedValue.ToString())).FirstOrDefault();
                                client.Name = InputName.Value;
                                client.Masking = InputMasking.Value;

                                if (active.Checked)
                                {
                                    client.StatusId = 1;
                                }
                                else
                                {
                                    client.StatusId = 0;
                                }
                                client.UpdatedOn = DateTime.Now;
                                client.UpdatedBy = 2;

                                SMSPortalEntity.SaveChanges();

                                SuccessMsg("Record Updated Successfully");
                                ViewState["mode"] = null;
                                LoadClientCombo();
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
            InputName.Value = "";
            InputMasking.Value = "";
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