using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPortal
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
            SetUserRights();
            GetRemainingSMSCount();
        }

        private void SetUserRights()
        {
            try
            {
                using (SMSPortalEntity smsPortalEmtity = new SMSPortalEntity())
                {
                    if (Session["userid"] != null && Session["userid"].ToString() != "")
                    {
                        User usr = smsPortalEmtity.Users.ToList().Where(X => X.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                        lblusername.InnerText = usr.UserId.ToString();
                        lblusernameinner.InnerText = usr.UserId.ToString();
                        lbljoiningdate.InnerText = "User Since : " + DateTime.Parse(usr.CreatedOn.ToString()).Date.ToString("dd MMM yyyy");
                    }
                    
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        private void GetRemainingSMSCount()
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (usr.UserTypeId == 2)
                    {
                        Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();
                        
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

                        lblremsms.InnerText = (Debit - Credit).ToString();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void LoadMenu()
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    if (Session["userid"] == null || Session["userid"].ToString() == "")
                    {
                        Response.Redirect("../Authentication/Login.aspx",false);    
                    }
                    User user = smsPortalEntity.Users.ToList().Where(X => X.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();

                    if (user != null)
                    {
                        var rights = smsPortalEntity.GetRightsByFormUserType(user.UserTypeId);

                        foreach (PageAllocation item in rights)
                        {
                            if (item != null)
                            {
                                if (item.PageName.ToUpper() == "DASHBOARD.ASPX")
                                {
                                    liHome.Visible = true;
                                    if (user.UserTypeId == 1)
                                    {
                                        dashboard.HRef = "Authentication/AdminDashboard.aspx";
                                    }
                                    else if (user.UserTypeId == 2)
                                    {
                                        dashboard.HRef = "Authentication/Dashboard.aspx";
                                    }
                                }
                                else if (item.PageName.ToUpper() == "USERREGISTRATION.ASPX")
                                {
                                    liUser.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "SMSCAMPAIGN.ASPX")
                                {
                                    liSmsCampaign.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "ADDPACKAGE.ASPX")
                                {
                                    liPackage.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "PACKAGEASSIGNING.ASPX")
                                {
                                    liAsign.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "CLIENTREGISTRATION.ASPX")
                                {
                                    liClients.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "ADDGROUPS.ASPX")
                                {
                                    //ddlGroups.Visible = true;
                                    liAddGroup.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "ADDCONTACT.ASPX")
                                {
                                    //ddlGroups.Visible = true;
                                    liAddContact.Visible = true;
                                }
                                else if (item.PageName.ToUpper() == "CONTACTLIST.ASPX")
                                {
                                    //ddlGroups.Visible = true;
                                    liContactList.Visible = true;
                                }
                                else if(item.PageName.ToUpper()== "SCHEDULESMS.ASPX")
                                {
                                    liScheduleSmS.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                Session["userid"] = null;
                Session["loggeduserdetails"] = null;
                Session.Clear();
                Session.Abandon();

                Response.Redirect("../Authentication/Login.aspx",false);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}