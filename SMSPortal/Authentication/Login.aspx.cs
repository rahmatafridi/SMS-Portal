using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXLogging;
using WXSecurity;

namespace SMSPortal.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnSignIn.UniqueID;
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User user = smsPortalEntity.Users.ToList().Where(X => X.UserId == InputName.Value.ToString() && X.Password == EncryptionUtility.Encrypt(InputPassword.Value) && X.StatusId == 1).FirstOrDefault();
                    if (user == null)
                    {
                        ErrorMsg("Invalid Credentials!");
                        return;
                    }
                    else
                    {
                        if (user.UserTypeId == 2)
                        {
                            Client clnt = smsPortalEntity.Clients.Where(X => X.Idpk == user.ClientId).FirstOrDefault();
                            if (clnt.StatusId == 0)
                            {
                                ErrorMsg("Your Account Has Been In Active, Please Contact Service Provider.");
                                return;
                            }
                            Session["userid"] = user.Idpk.ToString();
                            Response.Redirect("~/Authentication/Dashboard.aspx", false);
                        }
                        else
                        {
                            Session["userid"] = user.Idpk.ToString();
                            Response.Redirect("~/Authentication/AdminDashboard.aspx", false);
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
    }
}