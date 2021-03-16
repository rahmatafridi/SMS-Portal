using System.Web.Caching;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using WXSecurity;
using System.Collections;

namespace SMSPortal.App_Code
{
    public class WXBasePage : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);            

            string path = HttpContext.Current.Request.Url.AbsolutePath;
            path = Request.Path.Substring(Request.Path.LastIndexOf("/") + 1);

            if (path.ToUpper() == "LOGIN.ASPX" || path.ToUpper() == "NOACCESS.ASPX" || path.ToUpper() == "ADMINDASHBOARD.ASPX")
            {

            }
            else
            {
                bool isfound = false;
                if (Session["userid"] == null)
                {
                    Response.Redirect("../Authentication/Login.aspx");
                }
                else
                {
                    using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                    {
                        User user = smsPortalEntity.Users.ToList().Where(X => X.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                        ArrayList UserForms = new ArrayList();

                        if (user != null)
                        {
                            if (user.UserTypeId == 1) // 1 for admin & 2 for user                            
                            {
                                var rights = smsPortalEntity.GetRightsByFormUserType(1);

                                foreach (PageAllocation item in rights)
                                {
                                    if (item.PageName.ToUpper() == path.ToUpper())
                                    {
                                        isfound = true;
                                    }
                                }
                                if (!isfound)
                                    Response.Redirect("../Authentication/NOACCESS.aspx");
                            }
                            else if(user.UserTypeId == 2)
                            {
                                var rights = smsPortalEntity.GetRightsByFormUserType(2);

                                foreach (PageAllocation item in rights)
                                {
                                    if (item.PageName.ToUpper() == path.ToUpper())
                                    {
                                        isfound = true;
                                    }
                                }
                                if (!isfound)
                                    Response.Redirect("../Authentication/NOACCESS.aspx");
                            }
                        }
                    }
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        public UserLoginDetails LoggedUserDetails
        {
            set { Session["loggeduserdetails"] = value; }
            get
            {
                if (Session["loggeduserdetails"] == null)
                {
                    if (Session["userid"] == null)
                    {
                        Response.Redirect("../Authentication/Login.aspx");
                    }                    

                    using(SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                    {
                        User user = smsPortalEntity.Users.ToList().Where(X => X.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                        UserLoginDetails ULD = new UserLoginDetails();

                        if (user != null)
                        {
                            ULD = new UserLoginDetails();

                            ULD.Idpk = user.Idpk;
                            ULD.UserId = user.UserId;
                            ULD.Password = user.Password;
                            ULD.UserTypeId = int.Parse(user.UserTypeId.ToString());
                            ULD.StatusId = int.Parse(user.StatusId.ToString());
                            ULD.ClientId = int.Parse(user.ClientId.ToString());
                            ULD.UID = user.UID.ToString();
                            ULD.CreatedOn = DateTime.Parse(user.CreatedOn.ToString());
                            ULD.CreatedBy = int.Parse(user.CreatedBy.ToString());
                            ULD.UpdatedOn = DateTime.Parse(user.UpdatedOn.ToString());
                            ULD.UpdatedBy = int.Parse(user.UpdatedBy.ToString());
                        }
                        Session["loggeduserdetails"] = ULD;
                    }                    
                }
                return (UserLoginDetails)Session["loggeduserdetails"];
            }
        }
    }

    public class UserLoginDetails
    {
        public int Idpk = 0;
        public string UserId = string.Empty;
        public string Password = string.Empty;
        public int UserTypeId = 0;
        public int StatusId = 0;
        public int ClientId = 0;
        public string UID = string.Empty;
        public DateTime CreatedOn;
        public int CreatedBy = 0;
        public DateTime UpdatedOn;
        public int UpdatedBy = 0;                        
    }

}