using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WXLogging
{
    public class ErrorLogger
    {

        public static void WriteToErrorLog(string msg, string stkTrace, string Title)
        {
            


            //// SKIP EXCEPTION "Thread was being aborted" From Logging.
            //if (msg.Contains("Thread was being aborted"))
            //    return;
            //// Checking Directory If Not Exist Then Create It.
            //string FilePath =  
            //if (!System.IO.Directory.Exists("C:\\Error_WX_SMSPortal\\"))
            //{
            //    System.IO.Directory.CreateDirectory("C:\\Error_WX_SMSPortal\\");
            //}

            //// Checking File.
            //FileStream fs = new FileStream("C:\\Error_WX_SMSPortal\\ErrorLog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //StreamWriter s = new StreamWriter(fs);

            //s.Close();
            //fs.Close();

            //// Logging

            //FileStream fs1 = new FileStream("C:\\Error_WX_SMSPortal\\ErrorLog.txt", FileMode.Append, FileAccess.Write);
            //StreamWriter s1 = new StreamWriter(fs1);

            //s1.Write("Title : " + Title + Environment.NewLine);
            //s1.Write("Message : " + msg + Environment.NewLine);
            //s1.Write("StackTrace : " + stkTrace + Environment.NewLine);
            //s1.Write("Date / Time : " + DateTime.Now.ToString() + Environment.NewLine);
            //s1.Write("==============================================================================================" + Environment.NewLine);
            //s1.Close();
            //fs1.Close();

        }
    }
}
