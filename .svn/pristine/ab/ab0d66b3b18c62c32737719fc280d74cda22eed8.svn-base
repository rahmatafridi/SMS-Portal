using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;

namespace SMSPortal.Pakckages
{
    public partial class AddPackage : SMSPortal.App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadPackageCombo();
            }
        }

        private void LoadPackageCombo()
        {
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    DDL_Name.DataSource = SMSPortalEntity.Packages.ToList();
                    DDL_Name.DataTextField = "PackageName";
                    DDL_Name.DataValueField = "Idpk";
                    DDL_Name.DataBind();
                    DDL_Name.Items.Insert(0, new ListItem("--Select Package Name--", "")); 
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
                    Package package = SMSPortalEntity.Packages.ToList().Where(X => X.Idpk == int.Parse(DDL_Name.SelectedValue.ToString())).FirstOrDefault();
                    InputName.Value = package.PackageName;
                    InputSMS.Value = package.SMSnum.ToString();
                    InputDuration.Value = package.Duration.ToString();
                    InputRate.Value = package.Rate.ToString();
                    if (package.StatusId == 1)
                    {
                        active.Checked = true;
                    }
                    else
                    {
                        active.Checked = false;
                    }
                    ViewState["mode"] = "edit";

                    DDL_Name.Enabled = false;
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
            
            //Response.Redirect("AddPackage.aspx");
        }

        protected void SavePackage()
        {
            string error = "Please Enter";
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(InputName.Value))
                    {
                        error = error + " Client Name";
                        if (string.IsNullOrEmpty(InputSMS.Value))
                        {
                            error = error + ", SMS Qty";
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + ", Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + ", Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            else
                            {
                                error = error + "";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                        }
                        ErrorMsg(error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(InputSMS.Value))
                        {
                            error = error + " SMS Qty";
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + ", Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            ErrorMsg(error);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + " Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                                ErrorMsg(error);
                            }
                            else
                            {
                                error = error + "";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + " Rate";
                                    ErrorMsg(error);
                                }
                                else
                                {
                         
                                    Package package = new Package();
                                    package.PackageName = InputName.Value;
                                    package.SMSnum = Convert.ToInt32(InputSMS.Value);
                                    package.Duration = Convert.ToInt32(InputDuration.Value);
                                    package.Rate = Convert.ToDouble(InputRate.Value);

                                    if (active.Checked)
                                    {
                                        package.StatusId = 1;
                                    }
                                    else
                                    {
                                        package.StatusId = 0;
                                    }
                                    package.CreatedOn = DateTime.Now;
                                    package.CreatedBy = 1;
                                    package.UpdatedOn = DateTime.Now;
                                    package.UpdatedBy = 1;

                                    SMSPortalEntity.Packages.Add(package);
                                    SMSPortalEntity.SaveChanges();
                                    SuccessMsg("Record Inserted Successfully");
                                    ViewState["mode"] = null;
                                    LoadPackageCombo();
                                    Reset();
                                }
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

        protected void UpdatePackage()
        {
            string error = "Please Enter";
            try
            {
                using (SMSPortalEntity SMSPortalEntity = new SMSPortalEntity())
                {
                    if (string.IsNullOrEmpty(InputName.Value))
                    {
                        error = error + " Client Name!";
                        if (string.IsNullOrEmpty(InputSMS.Value))
                        {
                            error = error + ", SMS Qty";
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + ", Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + ", Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            else
                            {
                                error = error + "";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                        }
                        ErrorMsg(error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(InputSMS.Value))
                        {
                            error = error + " SMS Qty";
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + ", Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                            }
                            ErrorMsg(error);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(InputDuration.Value))
                            {
                                error = error + " Duration";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + ", Rate";
                                }
                                ErrorMsg(error);
                            }
                            else
                            {
                                error = error + "";
                                if (string.IsNullOrEmpty(InputRate.Value))
                                {
                                    error = error + " Rate";
                                    ErrorMsg(error);
                                }
                                else
                                {
                                    Package package = SMSPortalEntity.Packages.ToList().Where(X => X.Idpk == int.Parse(DDL_Name.SelectedValue.ToString())).FirstOrDefault();
                                    package.PackageName = InputName.Value;
                                    package.SMSnum = Convert.ToInt32(InputSMS.Value);
                                    package.Duration = Convert.ToInt32(InputDuration.Value);
                                    package.Rate = Convert.ToDouble(InputRate.Value);

                                    if (active.Checked)
                                    {
                                        package.StatusId = 1;
                                    }
                                    else
                                    {
                                        package.StatusId = 0;
                                    }
                                    package.UpdatedOn = DateTime.Now;
                                    package.UpdatedBy = LoggedUserDetails.Idpk;

                                    SMSPortalEntity.SaveChanges();
                                    SuccessMsg("Record Updated Successfully");
                                    ViewState["mode"] = null;
                                    LoadPackageCombo();
                                    Reset();
                                }
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
            InputName.Value = "";
            InputDuration.Value = "";
            InputRate.Value = "";
            InputSMS.Value = "";
            active.Checked = true;
            DDL_Name.Enabled = true;

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