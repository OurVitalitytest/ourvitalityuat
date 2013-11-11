using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data;
using System.Web;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace ALEREIMPACT.FRAMEWORK
{
    public static class EncryptionHelper
    {
        private const string cryptoKey = "cryptoKey";

        // The Initialization Vector for the DES encryption routine
        private static readonly byte[] IV =
            new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        /// <summary>
        /// Encrypts provided string parameter
        /// </summary>
        public static string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Decrypts provided string parameter
        /// </summary>
        public static string Decrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Convert.FromBase64String(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                throw;
            }

            return result;
        }
    }
   public  class ClsGeneric
    {
        #region Email and SMS Sending Methods
        public string SendMail(string To, string Body, string Subject)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(To);
                mail.From = new MailAddress("noreply@alerevitality.com");
                //mail.From = new MailAddress(ConfigurationSettings.AppSettings["MailFrom"]);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient();
               // smtp.Host = "smtp.gmail.com";
                smtp.Host = "10.0.0.138";
                //smtp.Host = ConfigurationSettings.AppSettings["Host"]; //Or Your SMTP Server Address
                smtp.Port = 25;
                smtp.UseDefaultCredentials = true; 
               
                smtp.Credentials = new System.Net.NetworkCredential("noreply@alerevitality.com", "Passw0rd");
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = false;
                smtp.Send(mail);
                mail.Dispose();
                
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(ex));
            }
            return "Sent";
        }
        public void SendSMS(string Message, string MobileNo)
        {
            try
            {
                string logonurl = "http://www.smsbyname.com/api/messagecv.asp?userid=deepanshu&pwd=12345678&message=" + Message + "&senderidgsm=GFMS&sendto=" + MobileNo + "";

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(logonurl);
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                Console.WriteLine("Response stream received.");
                Console.WriteLine(readStream.ReadToEnd());
                response.Close();
                readStream.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        public static string md5(string sPassword)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPassword);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        #endregion


        #region  "File Upload check"
        public Boolean checkRealFile(FileUpload passfile)
        {
            byte[] imgfile;
            Stream fs = default(Stream);
            fs = passfile.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(fs);
            imgfile = br1.ReadBytes(passfile.PostedFile.ContentLength);

            //Image file Starting Bytes
            byte[] chkByte = { 255, 216, 255, 224 };
            byte[] chkBytejpg = { 255, 216, 255, 225 };
            byte[] chkBytepng = { 137,80,78,71 };
            byte[] chkBytegif = { 71,73,70,56 };
        
            int j = 0;

            //Check bytes are equal to real file bytes (jpg Image)
            for (Int32 i = 0; i <= 4; i++)
            {
                if (imgfile[i] == chkByte[i])
                {
                    j = j + 1;
                    if (j == 3)
                    {
                        return true;
                    }
                }
                else if (imgfile[i] == chkBytejpg[i])
                {
                    j = j + 1;
                    if (j == 3)
                    {
                        return true;
                    }
                }
                else if (imgfile[i] == chkBytepng[i])
                {
                    j = j + 1;
                    if (j == 3)
                    {
                        return true;
                    }
                }
                else if (imgfile[i] == chkBytegif[i])
                {
                    j = j + 1;
                    if (j == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            

            return false;
        }
        #endregion


        public static void ReplaceCookie()
        {
            //HttpContext.Current.Session["AuthToken"] = string.Empty;
            //HttpContext.Current.Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            //string guid = Guid.NewGuid().ToString();
            ////HttpContext.Current.Session["AuthToken"] = guid;
            //// now create a new cookie with this guid value
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("AuthToken", guid));

        }
        #region Clearing the session ID
        public static void Clear_Session()
        {
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoStore();
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            //HttpContext.Current.Response.Redirect("AdminLogin.aspx", false);
            //HttpContext.Current.Response.End();
        }

        public static void Clear_Session1()
        {
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoStore();
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            //HttpContext.Current.Response.Redirect("../Login.aspx", false);
            //HttpContext.Current.Response.End();
        }
        public static void Clear_Session2()
        {
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoStore();
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            //HttpContext.Current.Response.Redirect("Login.aspx", false);
            //HttpContext.Current.Response.End();
        }

        #endregion

    }
}
