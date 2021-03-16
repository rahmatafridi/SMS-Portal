using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;

namespace SMSPortal.Pakckages
{
    public partial class PackageAssigning : App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    DDL_Client.DataSource = SMSPortalEntity.Clients.ToList();
                    DDL_Client.DataTextField = "Name";
                    DDL_Client.DataValueField = "Idpk";
                    DDL_Client.DataBind();
                    DDL_Client.Items.Insert(0, new ListItem("--Select Client Name--", ""));

                    DDL_Package.DataSource = SMSPortalEntity.Packages.ToList();
                    DDL_Package.DataTextField = "PackageName";
                    DDL_Package.DataValueField = "Idpk";
                    DDL_Package.DataBind();
                    DDL_Package.Items.Insert(0, new ListItem("--Select Package Name--", ""));
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }
        private bool CheckPackageExpiry()
        {
            bool IsExpired = false;
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();
                    var ClientId = Convert.ToInt32(DDL_Client.SelectedValue.ToString());
                    //if (usr.UserTypeId == 2)
                    //{
                    Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == ClientId).FirstOrDefault();

                        AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

                        Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

                        var cpd = smsPortalEntity.SP_RemainingSMS(clnt.Idpk, pkg.Idpk);

                        if (DateTime.Now.Date >= DateTime.Parse(apkg.EndDate.ToString()).Date)
                        {
                            IsExpired = true;
                         //   ErrorMsg("Your SMS Package Has Been Expired.");
                        }
                    //}
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return IsExpired;
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            string error = "Please Select";
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    if (DDL_Client.SelectedIndex == 0)
                    {
                        error = error + " Client Name";
                        if (DDL_Package.SelectedIndex == 0)
                        {
                            error = error + "& Package Name";
                        }
                        ErrorMsg(error);
                    }
                    else
                    {
                        if (DDL_Package.SelectedIndex == 0)
                        {
                            error = error + "Package Name";
                            ErrorMsg(error);
                        }
                        else
                        {
                            AssignPackage assignPackage = new AssignPackage();
                            assignPackage.Invoice = InputDis.Value.Trim();
                            assignPackage.ClientId = Convert.ToInt32(DDL_Client.SelectedValue.ToString());
                            assignPackage.PackageId = Convert.ToInt32(DDL_Package.SelectedValue.ToString());

                            UpdatePreviousRecord(Convert.ToInt32(DDL_Client.SelectedValue.ToString()));

                            Package pkg = smsPortalEntity.Packages.ToList().Where(x => x.Idpk == assignPackage.PackageId).FirstOrDefault();

                            assignPackage.StartDate = DateTime.Now;
                            assignPackage.EndDate = DateTime.Now.AddMonths(pkg.Duration);

                            if (active.Checked)
                            {
                                assignPackage.StatusId = 1;
                            }
                            else
                            {
                                assignPackage.StatusId = 0;
                            }
                            assignPackage.CreatedOn = DateTime.Now;
                            assignPackage.CreatedBy = LoggedUserDetails.Idpk;
                            assignPackage.UpdatedOn = DateTime.Now;
                            assignPackage.UpdatedBy = LoggedUserDetails.Idpk;

                            smsPortalEntity.AssignPackages.Add(assignPackage);
                            smsPortalEntity.SaveChanges();
                            InsertClientPackageDetail();
                            SuccessMsg("Record Updated Successfully");
                            Reset();
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

        protected void DDL_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    Client client = smsPortalEntity.Clients.ToList().Where(X => X.Idpk == int.Parse(DDL_Client.SelectedValue.ToString())).FirstOrDefault();
                    L_Name.Text = client.Name;

                    AutoGenerateInvoiceNo(smsPortalEntity, client);

                    AssignPackage assign = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == int.Parse(DDL_Client.SelectedValue.ToString()) && X.StatusId == 1).FirstOrDefault();
                    if (assign != null)
                    {
                        

                        L_Date.Text = DateTime.Parse(assign.EndDate.ToString()).Date.ToString("dd MMM yyyy");
                        Package package = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == assign.PackageId).FirstOrDefault();
                        L_Package.Text = package.PackageName.ToString();

                        var cpd = smsPortalEntity.SP_RemainingSMS(assign.ClientId, assign.PackageId);

                        int? Debit = 0;
                        int? Credit = 0;

                        foreach (SP_RemainingSMS_Result item in cpd)
                        {
                            Debit += item.DebitSMSQty;
                            Credit += item.CreditSMSQty;
                        }

                        L_Sms.Text = (Debit - Credit).ToString();
                    }
                    else
                    {
                        L_Package.Text = "No Package";
                        L_Sms.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

        private void AutoGenerateInvoiceNo(SMSPortalEntity smsPortalEntity, Client client)
        {
            ClientPackageDetail cc = smsPortalEntity.ClientPackageDetails.ToList().LastOrDefault();

            int Id = 0;

            if (cc != null)
            {
                Id = int.Parse(cc.Idpk.ToString());
            }
            else
            {
                Id = 0;
            }

            string Invoice = client.Name.Substring(0, 2).ToUpper();
            Invoice = Invoice + DateTime.Now.ToString("ddMMyyyy");
            Invoice = Invoice + (Id + 1).ToString().PadLeft(6, '0');

            InputDis.Value = Invoice;
        }


        private void Reset()
        {
            DDL_Client.SelectedIndex = 0;
            DDL_Package.SelectedIndex = 0;
            active.Checked = true;
            L_Date.Text = "";
            L_Name.Text = "";
            L_Sms.Text = "";
            L_Package.Text = "";
            InputDis.Value = "";

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

        private void UpdatePreviousRecord(int Id)
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    AssignPackage assign = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == Id && X.StatusId == 1).FirstOrDefault();
                    if (assign != null)
                    {
                        assign.ClientId = Id;
                        assign.StatusId = 0;
                        assign.UpdatedOn = DateTime.Now;
                        assign.UpdatedBy = LoggedUserDetails.Idpk;
                        smsPortalEntity.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg("Error Occured! Please Contact Support Team.");
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


                     var ClientId = Convert.ToInt32(DDL_Client.SelectedValue.ToString());
                    Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == ClientId).FirstOrDefault();

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
            catch (Exception ex)
            {
                ErrorMsg("Error Occured , Please Contact support team.");
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return SMSCount;
        }

        private void InsertClientPackageDetail()
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    ClientPackageDetail cpd = new ClientPackageDetail();
                    cpd.ClientId = Convert.ToInt32(DDL_Client.SelectedValue.ToString());
                    cpd.PackageId = Convert.ToInt32(DDL_Package.SelectedValue.ToString());

                    Package package = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == cpd.PackageId).FirstOrDefault();
                    int RemainingSMS = GetRemainingSMS();
                    cpd.DebitSMSQty = package.SMSnum;
                    if (CheckPackageExpiry())
                    {
                        cpd.CreditSMSQty = RemainingSMS;
                    }

                    cpd.CreditSMSQty = 0;

                    if (active.Checked)
                    {
                        cpd.StatusId = 1;
                    }
                    else
                    {
                        cpd.StatusId = 0;
                    }
                    cpd.CreatedBy = 1;
                    cpd.CreatedOn = DateTime.Now;
                    cpd.UpdatedBy = 1;
                    cpd.UpdatedOn = DateTime.Now;

                    smsPortalEntity.ClientPackageDetails.Add(cpd);
                    smsPortalEntity.SaveChanges();
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