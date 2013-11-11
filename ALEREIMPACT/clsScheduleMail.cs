using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;

namespace ALEREIMPACT
{
    public class clsScheduleMail
    {
        public void SendScheduleMail(string Subject, string To, string Body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress("test@trigma.info");
                //mail.From = new MailAddress(ConfigurationSettings.AppSettings["MailFrom"]);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                //smtp.Host = ConfigurationSettings.AppSettings["Host"]; //Or Your SMTP Server Address
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("test@trigma.info", "Testing@123");
                // smtp.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["richa@gmail.com"], ConfigurationSettings.AppSettings[""]);
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
