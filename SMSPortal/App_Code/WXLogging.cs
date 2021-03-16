using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMSPortal.App_Code
{
    public class WXLogging
    {
        public void WriteToErrorLog(string Msg, string StkTrace)
        {
            try
            {
                using (SMSPortalEntity smsPortalEntity = new SMSPortalEntity())
                {
                    ErrorLog el = new ErrorLog();

                    el.Message = Msg.ToString();
                    el.StackTrace = StkTrace.ToString();

                    smsPortalEntity.ErrorLogs.Add(el);
                    smsPortalEntity.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;                
            }
        }
    }
}