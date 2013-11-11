using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.DAO.Circles;

using System.IO;

namespace ALEREIMPACT.Service
{
    /// <summary>
    /// Summary description for alereimpactservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]

    public class alereimpactservice : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string[] FindFriends(string prefixText, string contextKey)
        {
            string sql = string.Empty;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            int value = Convert.ToInt32(contextKey);
          //  sql = "select UP.first_name as first_name,UR.login_email as login_email,user_image,UP.fk_user_registration_id from tblUser_profile UP inner join tblUser_registration UR on UR.pk_user_registration_Id=UP.fk_user_registration_Id where UP.first_name like @prefixText or UR.login_email like @prefixText";
          // sql = "select top 5 UP.first_name as first_name,UR.login_email as login_email,user_image,UP.fk_user_registration_id,'1' as member from tblUser_profile UP inner join tblUser_registration UR on UR.pk_user_registration_Id=UP.fk_user_registration_Id where UP.first_name like '%'+@prefixText+'%' or UR.login_email like'%'+@prefixText+'%' union  select top 5 ucm.circle_name,'2' ,uc.circle_color,uc.fk_user_registration_Id,up.first_name as circle  from tblUserCirclesMaster ucm inner join tblUserCircles uc on uc.fk_circle_id=ucm.pk_circle_id left join tblUser_profile up on up.fk_user_registration_Id=uc.fk_user_registration_Id where ucm.circle_name like '%'+@prefixText+'%'";
            sql = "select top 7 UP.first_name as first_name,UR.login_email as login_email,user_image,UP.fk_user_registration_id,'1' as member from tblUser_profile UP inner join tblUser_registration UR on UR.pk_user_registration_Id=UP.fk_user_registration_Id where UP.first_name like '%'+@prefixText+'%' or UR.login_email like'%'+@prefixText+'%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@prefixText", prefixText + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> FriendList = new List<string>();
            string FriendFinder = string.Empty;
            while (dr.Read())
            {
                UserCirclesBAO objUserCircleBAO = new UserCirclesBAO();
                DataTable dtPhoto = new DataTable();
                objUserCircleBAO.ID = Convert.ToInt32(dr["fk_user_registration_id"]);
                objUserCircleBAO.proceduretype = "GP";
                dtPhoto = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dtPhoto.Rows.Count > 0)
                {
                    if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                    {
                        FriendFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}", dr["fk_user_registration_id"], dr["member"], dr["first_name"]), dr["user_image"].ToString());
                    }
                    else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                    {
                        DataTable dtFreinds = new DataTable();
                        AdminBAO objAdminBAO = new AdminBAO();
                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                        objAdminBAO.ID1 = Convert.ToInt32(dr["fk_user_registration_id"]);
                        objAdminBAO.ProcedureType = "GF";
                        dtFreinds = AdminDAO.GetSearchDetail(objAdminBAO);
                        if (dtFreinds.Rows.Count > 0)
                        {
                            FriendFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}", dr["fk_user_registration_id"], dr["member"], dr["first_name"]), dr["user_image"].ToString());
                        }
                        //else
                        //{
                        //    string photo = "profileBlankPhoto.jpg";

                        //    FriendFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}", dr["fk_user_registration_id"], dr["login_email"], dr["first_name"]), photo.ToString());
                        //}
                    }
                    else if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                    {
                        string photo = "profileBlankPhoto.jpg";
                        FriendFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}", dr["fk_user_registration_id"], dr["member"], dr["first_name"]), photo.ToString());
                    }

                }
                else
                {
                    FriendFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}", dr["fk_user_registration_id"], dr["member"], dr["first_name"]), dr["user_image"].ToString());
                }
              
              
                FriendList.Add(FriendFinder);
            }
            con.Close();

            dr.Close();
            return FriendList.ToArray();

        }
        [WebMethod]
        public List<string> GetRecords(string prefixText, string contextKey)
        {
            string strConn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand("spGetActivities", con);

            cmd.Parameters.AddWithValue("@search_text", prefixText);
            cmd.Parameters.AddWithValue("@request_type", 1);

            cmd.CommandType = CommandType.StoredProcedure;
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            List<string> items = new List<string>();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    items.Add(sdr["activity"].ToString() + "\n");
                }
            }
            if (items.Count() == 0)
            {
                items.Add("No activity matches your search.");
            }
            con.Close();
            return items;
        }

        [WebMethod]

        public string[] FindCircles(string prefixText, string contextKey)
        {
            string sql = string.Empty;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con.Open();
            int value = Convert.ToInt32(contextKey);
            sql = "select UCM.pk_circle_id, UC.fk_user_registration_Id , UCM.circle_name from tblUserCirclesMaster UCM inner join 	tblUserCircles UC on UC.fk_circle_id=UCM.pk_circle_id where UC.fk_circle_permission_id in(2,3) and UCM.circle_name like @prefixText";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@prefixText", prefixText + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            List<string> CircleList = new List<string>();
            string CircleFinder = string.Empty;
            while (dr.Read())
            {
                CircleFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}", dr["fk_user_registration_id"], dr["circle_name"], dr["pk_circle_id"]), dr["pk_circle_id"].ToString());
                CircleList.Add(CircleFinder);
            }
            con.Close();

            dr.Close();
            return CircleList.ToArray();

        }

        [WebMethod]
        public static string sendMAil(string email, string msg)
        {
            // string email = "";
            // string msg = "";
            string body = "";
            string subject;
            ClsGeneric objClsGeneric = new ClsGeneric();
            try
            {

                if (email != "")
                {
                    AdminBAO objAdminBAO = new AdminBAO();
                    DataTable dt = new DataTable();
                    objAdminBAO.name = email;
                    objAdminBAO.name1 = "";
                    objAdminBAO.ProcedureType = "V";
                    dt = AdminDAO.GetUserDetailSearch(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        //for (int i = 0; i < dt.Rows.Count; i++)
                        //{
                        //    if (txtEmail.Text == dt.Rows[i]["login_email"].ToString())
                        //    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('User already exists');", true);
                        email = "";
                        msg = "";
                        // return;
                        //    }
                        //}
                    }
                    else
                    {

                        // get();
                        //email = txtEmail.Text;
                        int retval = 0;
                        objAdminBAO.UI_ID = 0;
                        objAdminBAO.fk_user_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objAdminBAO.UI_USER_MAIL_ID = email;
                        objAdminBAO.UI_DATE = DateTime.Now.ToString();
                        objAdminBAO.UI_STATUS = "False";
                        objAdminBAO.UI_CODE = 1;
                        objAdminBAO.UI_MAIL_STATUS = "Successfull";
                        objAdminBAO.ProcedureType = "I";
                        retval = AdminDAO.InserttblUserInvitation(objAdminBAO);
                        subject = "Alere Vitality Invitation";
                        if (msg == "")
                        {


                            body = PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval,
                 "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
                 " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, "
                 + "when an unknown printer took a galley of type and scrambled it to make a type specimen book.");
                        }
                        else
                        {
                            body = PopulateBody("Alere Vitality Invitation", ConfigurationManager.AppSettings["AlereVitality_Path"] + "/Register.aspx?val=" + retval, msg);
                        }
                        objClsGeneric.SendMail(email, body, subject);
                        //txtEmail.Text = "";
                        //txtmessage.Text = "";

                        //lbMsgSend.Visible = true;
                        //lbMsgSend.Text = "Invitation has been sent.";
                        //DivEmail.Style.Add("display", "block");

                    }


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return body;
        }

        public static string PopulateBody(string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("~/InvitationEmail.htm"))
            {
                body = reader.ReadToEnd();
            }
            //body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }

    }
}
