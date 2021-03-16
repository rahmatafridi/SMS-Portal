using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPortal.Authentication
{
    public partial class Dashboard : App_Code.WXBasePage
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2)
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

                        //lblmaskingname.InnerText = clnt.Masking.ToString().ToUpper();
                        lblmaskingname.InnerText = clnt.Masking.ToString();
                        lblClientName.InnerText = clnt.Name.ToString();

                        AssignPackage apkg = smsPortalEntity.AssignPackages.ToList().Where(X => X.ClientId == clnt.Idpk && X.StatusId == 1).FirstOrDefault();

                        Package pkg = smsPortalEntity.Packages.ToList().Where(X => X.Idpk == apkg.PackageId).FirstOrDefault();

                        lblpackagename.InnerText = pkg.PackageName.ToString();
                        lblTotalSMS.InnerText = pkg.SMSnum.ToString() + " SMS";

                        var cpd = smsPortalEntity.SP_RemainingSMS(clnt.Idpk, pkg.Idpk);

                        int? Debit = 0;
                        int? Credit = 0;

                        foreach (SP_RemainingSMS_Result item in cpd)
                        {
                            Debit += item.DebitSMSQty;
                            Credit += item.CreditSMSQty;
                        }

                        lblremsms.InnerText = (Debit - Credit).ToString();

                        lblpkgexpiry.InnerText = DateTime.Parse(apkg.EndDate.ToString()).Date.ToString("dd MMM yyyy");
                        lblduration.InnerText = pkg.Duration.ToString() + " Month Duration";
                    }
                }
            }
            catch (Exception ex)
            {
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
        }

    }
}