using SMSPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSPortal.ScheduleSMS
{
    public partial class ScheduleList : SMSPortal.App_Code.WXBasePage
    {
        SMSPortalEntity smsPortalEntity = new SMSPortalEntity();
        protected void Page_Load(object sender, EventArgs e)
        {
            //tbl.InnerHtml = GenerateHTML();

            
           

            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {

            try
            {

                User usr = smsPortalEntity.Users.ToList().Where(x => x.Idpk == int.Parse(Session["userid"].ToString())).FirstOrDefault();
                Client clnt = smsPortalEntity.Clients.ToList().Where(x => x.Idpk == usr.ClientId).FirstOrDefault();
                // ProductsDAL objProductsDAL = new ProductsDAL();

                grdProducts.DataSource = smsPortalEntity.GetSchedleList(clnt.Idpk);

                grdProducts.DataBind();
            }
            catch (Exception ex)
            {
                
            }
        }
        protected void grdProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                LoadProducts();
                grdProducts.PageIndex = e.NewPageIndex;
                grdProducts.DataBind();
            }
            catch (Exception ex)
            {
                //WebixoftExceptions.WriteToErrorLog(ex.Message, ex.StackTrace, "Exception", GeneralSettingsDAL.str_module);
                //Message("Error Occured, Please contact support team.", GeneralSettingsDAL.str_danger_msg);
            }
        }
        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DataCommand")
                {
                    var UID = e.CommandArgument;
                    Guid newid = new Guid(UID.ToString());

                    SMSSchedule ssm = smsPortalEntity.SMSSchedules.Where(x => x.UID == newid).FirstOrDefault();
                    ssm.Status = 3;

                    smsPortalEntity.SaveChanges();
                    Response.Redirect("../ScheduleSMS/ScheduleList.aspx", false);


                }
            }
            catch (Exception ex)
            {
                //WebixoftExceptions.WriteToErrorLog(ex.Message, ex.StackTrace, "Exception", GeneralSettingsDAL.str_module);
                //Message("Error Occured, Please contact support team.", GeneralSettingsDAL.str_danger_msg);
            }
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
                sb.Append("<h3 class='box-title'>Schedule List</h3>");
                sb.Append("</div>");

                sb.Append("<div class='box-body no-padding'>");
                sb.Append("<table class='table'>");
                sb.Append("<tbody><tr>");
                sb.Append("<th style='width: 10px'>#</th>");
                sb.Append("<th>DateTime</th>");
                sb.Append("<th>Text SmS</th>");
                sb.Append("<th>Group</th>");
                sb.Append("<th></th>");


                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    var obj = smsPortalEntity.GetSchedleList(clnt.Idpk);
                    int Count = 0;
                    foreach (var item in obj)
                    {
                        Count++;
                        sb.Append("<tr>");
                        sb.Append("<td>" + Count + "</td>");
                        sb.Append("<td>" + item.DateTime + "</td>");
                        sb.Append("<td>" + item.TextSms + "</td>");
                        sb.Append("<td>" + item.GroupName + "</td>");
                        sb.Append("<td><a href=#" + item.UID + " class='btn btn-danger btn-xs btn-edit'><i class='fa fa-trash' style='padding-right: 5px;'></i>Delete</a></td>");
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