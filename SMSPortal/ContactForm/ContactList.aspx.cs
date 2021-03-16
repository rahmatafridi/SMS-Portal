using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPortal.ContactForm
{
    public partial class ContactList : SMSPortal.App_Code.WXBasePage
    {
        SMSPortalEntity smsPortalEntity = new SMSPortalEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.InnerHtml = GenerateHTML();
        }

        private string GenerateHTML()
        {
            User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();
            Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();

            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("<div class='box'>");

                sb.Append("<div class='box-header'>");
                sb.Append("<h3 class='box-title'>Contact List</h3>");
                sb.Append("</div>");

                sb.Append("<div class='box-body no-padding'>");
                sb.Append("<table class='table'>");
                sb.Append("<tbody><tr>");
                sb.Append("<th style='width: 10px'>#</th>");
                sb.Append("<th>Contact#</th>");
                sb.Append("<th>Group</th>");
                sb.Append("<th></th>");
               

                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    var obj = smsPortalEntity.GetContactList(clnt.Idpk);
                    int Count = 0;
                    foreach (var item in obj)
                    {
                        Count++;
                        sb.Append("<tr>");
                        sb.Append("<td>" + Count + "</td>");
                        sb.Append("<td>" + item.ContactNo + "</td>");
                        sb.Append("<td>" + item.GroupName + "</td>");
                        //sb.Append("<td><a href=#" + item.UID + " class='btn btn-danger btn-xs btn-edit'><i class='fa fa-trash' style='padding-right: 5px;'></i>Delete</a></td>");
                        sb.Append("</tr>");
                    }
                }

                sb.Append("</tbody></table>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");
            }
            catch (Exception ex)
            {
               // wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return sb.ToString();
        }

    }
}