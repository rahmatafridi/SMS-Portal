using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SMSPortal.Authentication
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        App_Code.WXLogging wxlog = new App_Code.WXLogging();

        protected void Page_Load(object sender, EventArgs e)
        {
            tbl.InnerHtml = GenerateHTML();
        }

        private string GenerateHTML()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("<div class='box'>");

                sb.Append("<div class='box-header'>");
                sb.Append("<h3 class='box-title'>Clients SMS Package Status</h3>");
                sb.Append("</div>");

                sb.Append("<div class='box-body no-padding'>");
                sb.Append("<table class='table'>");
                sb.Append("<tbody><tr>");
                sb.Append("<th style='width: 10px'>#</th>");
                sb.Append("<th>Client Name</th>");
                sb.Append("<th>Masking</th>");
                sb.Append("<th>Expiry Date</th>");
                sb.Append("<th>Package Status</th>");
                sb.Append("<th style='width: 40px'></th>");
                sb.Append("<th style='width: 40px'>Status</th>");

                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    var obj = smsPortalEntity.GetClientSummaryStatus();
                    int Count = 0;
                    foreach (var item in obj)
                    {
                        Count++;
                        sb.Append("<tr>");
                        sb.Append("<td>" + Count + "</td>");
                        sb.Append("<td>"+ item.Name +"</td>");
                        sb.Append("<td>"+ item.Masking.ToUpper() +"</td>");
                        sb.Append("<td>"+ DateTime.Parse(item.EndDate.ToString()).ToString("dd MMM yyyy") +"</td>");
                        sb.Append("<td>");
                        if (item.pcent <= 25)
                        {
                            sb.Append("<div class='progress progress-xs'>");
                            sb.Append("<div class='progress-bar progress-bar-primary' style='width: " + int.Parse(item.pcent.ToString()) + "%'></div>");
                            sb.Append("</div>");    
                        }
                        else if (item.pcent <= 50)
                        {
                            sb.Append("<div class='progress progress-xs'>");
                            sb.Append("<div class='progress-bar progress-bar-success' style='width: " + int.Parse(item.pcent.ToString()) + "%'></div>");
                            sb.Append("</div>");    
                        }
                        else if (item.pcent <= 75)
                        {
                            sb.Append("<div class='progress progress-xs'>");
                            sb.Append("<div class='progress-bar progress-bar-yellow' style='width: " + int.Parse(item.pcent.ToString()) + "%'></div>");
                            sb.Append("</div>");    
                        }
                        else if (item.pcent <= 100)
                        {
                            sb.Append("<div class='progress progress-xs'>");
                            sb.Append("<div class='progress-bar progress-bar-danger' style='width: " + int.Parse(item.pcent.ToString()) + "%'></div>");
                            sb.Append("</div>");    
                        }

                        sb.Append("</td>");

                        if (item.pcent <= 25)
                        {
                            sb.Append("<td><span class='badge bg-light-blue'>" + int.Parse(item.pcent.ToString()) + "%</span></td>");
                        }
                        else if (item.pcent <= 50)
                        {
                            sb.Append("<td><span class='badge bg-green'>" + int.Parse(item.pcent.ToString()) + "%</span></td>");
                        }
                        else if (item.pcent <= 75)
                        {
                            sb.Append("<td><span class='badge bg-yellow'>" + int.Parse(item.pcent.ToString()) + "%</span></td>");
                        }
                        else if (item.pcent <= 100)
                        {
                            sb.Append("<td><span class='badge bg-red'>" + int.Parse(item.pcent.ToString()) + "%</span></td>");
                        }
                        
                        
                        if (item.status.ToUpper() == "ACTIVE")
                        {
                            sb.Append("<td><span class='badge bg-green'><b>Active</b></span></td>");
                        }
                        else if (item.status.ToUpper() == "EXPIRED")
                        {
                            sb.Append("<td><span class='badge bg-red'><b>Expired</b></span></td>");
                        }

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
                wxlog.WriteToErrorLog(ex.Message, ex.StackTrace);
            }
            return sb.ToString();
        }


    }
}