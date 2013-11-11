using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.UI;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.FRAMEWORK;
//using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.DAO;
using ALEREIMPACT.BAO;


namespace ALEREIMPACT.MobileAPI
{
    /// <summary>
    /// Summary description for AlereVitalityMobileAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AlereVitalityMobileAPI : System.Web.Services.WebService
    {
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        ClsGeneric objGeneric = new ClsGeneric();
        SQLHelper objhelper = new SQLHelper();

        [WebMethod(Description = "Your Description")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]


        public string ForgtPWD()
        {
            DataTable dt = new DataTable();
            objRegisterUserBAO.LoginEmail = "richa.sharma@trigma.in";
            string email = objRegisterUserBAO.LoginEmail;
            objRegisterUserBAO.procedureType = "S";
            dt = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);

            string retJSON = "";
            if (dt.Rows.Count != 0)
            {
                //ForgotPassword[] FP = null;
                string randomPassword = System.Guid.NewGuid().ToString().Substring(0, 8);

                objRegisterUserBAO.user_registration_Id = Convert.ToInt32(dt.Rows[0]["pk_user_registration_Id"]);
                objRegisterUserBAO.LoginPassword = ALEREIMPACT.FRAMEWORK.ClsGeneric.md5(randomPassword);
                objRegisterUserBAO.PasswordSalt = "";
                objRegisterUserBAO.IsPasswordChanged = false;
                objRegisterUserBAO.procedureType = "U1";
                int updwd = RegisterUserDAO.UpdatePassword(objRegisterUserBAO);

                string subject = "Alere Impact : Forgot Password Detail";
                string body = "Your New  Password is  " + randomPassword + ".";
                string retval = objGeneric.SendMail(email, body, subject);

                JavaScriptSerializer js = new JavaScriptSerializer();
                retJSON = js.Serialize(retval);

            }
            return retJSON;

        }


        //        public string LoginVerify()
        //        { 
        //         DataTable dt = new DataTable();

        //            UserOperationDAO objUserOperationDAO = new UserOperationDAO();
        //            UserOperationsBAO objUserOperationsBAO = new UserOperationsBAO();

        //            objUserOperationsBAO.LoginWithEmail =  "richa.sharma@trigma.in";
        //                //txtUserName.Text.Trim();
        //            objUserOperationsBAO.LoginWithPassword = ClsGeneric.md5("richa.sharma@trigma.in");

        //            DataSet dsLogin = UserOperationDAO.Login(objUserOperationsBAO);
        //            if (dsLogin != null)
        //            {
                  //   MySession.Current.CircleId = "1";

        //                if (Convert.ToString(dsLogin.Tables[0].Rows[0]["LoginStatus"]) == "1")
        //                {
        //                    MySession.Current.LoginId = dsLogin.Tables[1].Rows[0]["LoginId"].ToString();
        //                    Session["Email"] = txtUserName.Text;

        //                    // To check, user change inner circle image or not
        //                    objRegisterUserBAO.LoginEmail = txtUserName.Text;
        //                    objRegisterUserBAO.procedureType = "C";
        //                    dt = RegisterUserDAO.GetEmailDetail(objRegisterUserBAO);

        //        }

        //    }
        //}
    }

}
