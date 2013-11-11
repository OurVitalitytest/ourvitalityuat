using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.DAL.User;
namespace ALEREIMPACT.User
{
    public partial class ucUserProfile : System.Web.UI.UserControl
    {
        UserCirclesBAO objUserCircleBAO = new UserCirclesBAO();
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        UserInspiratorsBAL objUserInspiratorBAL = new UserInspiratorsBAL();
        AdminBAO objAdminBAO = new AdminBAO();
        public static string inspiratorid = "";
        public static string useriispd = "";
        public static Int32 userid = 0;
        public static Int32 circleid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    if (Convert.ToString(Request.QueryString["val"]) == "" || Convert.ToString(Request.QueryString["val"]) == null)
                    {
                        btnRemove.Visible = false;
                        if (Convert.ToString(MySession.Current.searchfriendId) == "" || Convert.ToString(MySession.Current.searchfriendId) == null)
                        {
                            if (MySession.Current.MemberUserId == "" || MySession.Current.MemberUserId == null)
                            {
                                if (MySession.Current.PublicCircleUserId == "" || MySession.Current.PublicCircleUserId == null)
                                {

                                }
                                else
                                {
                                    userid = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                                }
                                if (MySession.Current.PublicCircleId == "" || MySession.Current.PublicCircleId == null)
                                {
                                    circleid = Convert.ToInt32(MySession.Current.CircleId);
                                }
                                else
                                {
                                    circleid = Convert.ToInt32(MySession.Current.PublicCircleId);

                                }
                                checkUser();
                            }

                            else
                            {

                                userid = Convert.ToInt32(MySession.Current.MemberUserId);
                                circleid = Convert.ToInt32(MySession.Current.MemberCircleId);
                                btnAcceptInvitation.Visible = true;
                                btnRejectInvitation.Visible = true;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = false;
                                lbmsgsent.Visible = false;

                            }

                        }

                        if (MySession.Current.PublicCircleUserId == "" || MySession.Current.PublicCircleUserId == null)
                        {
                            if (MySession.Current.MemberUserId == "" || MySession.Current.MemberUserId == null)
                            {

                                btnInvitation.Visible = true;
                                btnAcceptInvitation.Visible = false;
                                btnRejectInvitation.Visible = false;
                                btnJoin.Visible = false;
                                lbmsgsent.Visible = false;




                                if (MySession.Current.searchfriendId == "" || MySession.Current.searchfriendId == null)
                                {

                                }
                                else
                                {
                                    userid = Convert.ToInt32(MySession.Current.searchfriendId);
                                }
                                // userid = Convert.ToInt32(MySession.Current.searchfriendId);

                                circleid = Convert.ToInt32(MySession.Current.CircleId);
                                GetFriendProfile();
                            }

                            else
                            {

                                btnAcceptInvitation.Visible = true;
                                btnRejectInvitation.Visible = true;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = false;
                                lbmsgsent.Visible = false;
                                userid = Convert.ToInt32(MySession.Current.MemberUserId);
                                circleid = Convert.ToInt32(MySession.Current.MemberCircleId);
                            }



                        }
                    }
                    else
                    {
                        userid = Convert.ToInt32(Request.QueryString["val"]);
                        circleid = Convert.ToInt32(MySession.Current.CircleId);
                        if (MySession.Current.LoginId == Convert.ToString(userid))
                        {
                        }
                        else
                        {
                            DataTable dtuserFreind1 = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ID1 = userid;
                            objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                            objAdminBAO.ProcedureType = "S";
                            dtuserFreind1 = AdminDAO.GetUserMemberStatus(objAdminBAO);
                            if (dtuserFreind1.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtuserFreind1.Rows[0][0]) == 1 || Convert.ToInt32(dtuserFreind1.Rows[0][0]) == 7 || Convert.ToInt32(dtuserFreind1.Rows[0][0]) == 5)
                                {
                                    lbJoin.Visible = true;
                                    lbJoin.Text = "Invitation Pending for Approval.";
                                }
                                else if(Convert.ToInt32(dtuserFreind1.Rows[0][0]) == 2)
                                {
                                    btnRemove.Visible = true;
                                }
                                else if (Convert.ToInt32(dtuserFreind1.Rows[0][0]) == 3)
                                {
                                    btnInvitation.Visible = true;
                                }
                            }
                            else
                            {
                                DataTable dt1 = new DataTable();
                                objAdminBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
                                objAdminBAO.ProcedureType = "GC";
                                dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                                if (dt1.Rows.Count > 0)
                                {
                                    MySession.Current.PublicPermissions = dt1.Rows[0]["fk_circle_permission_id"].ToString();
                                }
                                btnRemove.Visible = false;
                                DataTable dtFreind = new DataTable();
                                objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                objAdminBAO.ID1 = userid;
                                objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                                objAdminBAO.ProcedureType = "G";
                                dtFreind = AdminDAO.GetUserMemberStatus(objAdminBAO);
                                if (dtFreind.Rows.Count > 0)
                                {
                                    if (MySession.Current.PublicPermissions == "1")
                                    {
                                        lbmsgsent.Visible = true;
                                        btnInvitation.Visible = false;
                                    }
                                    else if (MySession.Current.PublicPermissions == "2")
                                    {
                                        lbmsgsent.Visible = true;
                                        divmsg.Visible = false;
                                        txtMessage.Visible = false;
                                        btnSendmsg.Visible = false;
                                    }
                                    else if (MySession.Current.PublicPermissions == "3")
                                    {
                                        lbmsgsent.Visible = true;
                                        btnJoin.Visible = false;
                                    }

                                }
                                else
                                {
                                    if (MySession.Current.PublicPermissions == "1")
                                    {
                                        DataTable dt = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                        objAdminBAO.ID1 = Convert.ToInt32(MySession.Current.UserCircleID);
                                        objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                                        objAdminBAO.ProcedureType = "C";
                                        dt = AdminDAO.GetUserMemberStatus(objAdminBAO);
                                        if (dt.Rows.Count > 0)
                                        {
                                            btnInvitation.Visible = true;
                                        }
                                        else
                                        {


                                            btnRemove.Visible = true;
                                            btnRemove.Text = "Leave";
                                            Session["Leave"] = true;
                                        }
                                    }
                                    else if (MySession.Current.PublicPermissions == "2")
                                    {DataTable dt = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                        objAdminBAO.ID1 = Convert.ToInt32(MySession.Current.UserCircleID);
                                        objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                                        objAdminBAO.ProcedureType = "C";
                                        dt = AdminDAO.GetUserMemberStatus(objAdminBAO);
                                        if (dt.Rows.Count > 0)
                                        {
                                            btnInvitation.Visible = true;
                                            divmsg.Visible = false;
                                            txtMessage.Visible = false;
                                            btnSendmsg.Visible = false;
                                        }
                                        else
                                        {
                                            btnRemove.Visible = true;
                                            btnRemove.Text = "Leave";
                                            Session["Leave"] = true;
                                        }
                                    }
                                    else if (MySession.Current.PublicPermissions == "3")
                                    {
                                        DataTable dt = new DataTable();
                                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                        objAdminBAO.ID1 = Convert.ToInt32(MySession.Current.UserCircleID);
                                        objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                                        objAdminBAO.ProcedureType = "C";
                                        dt = AdminDAO.GetUserMemberStatus(objAdminBAO);
                                        if (dt.Rows.Count > 0)
                                        {
                                            btnInvitation.Visible = true;
                                        }
                                        else
                                        {


                                            btnRemove.Visible = true;
                                            btnRemove.Text = "Leave";
                                            Session["Leave"] = true;
                                        }
                                        //btnJoin.Visible = true;
                                    }
                                }
                            }
                        }

                       

                    }
                    getProfile();
                    BindPublicCircles();
                    BindSelectedCircle();
                    BindInspirators();
                    BindMission();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        

       

        private void getProfile()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.ID = userid;
                objUserCircleBAO.proceduretype = "MP1";
                dt = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["user_image"].ToString() == "" || dt.Rows[0]["user_image"].ToString() == null)
                        {
                            imgProfile.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";

                        }
                        else
                        {
                            if (MySession.Current.LoginId == Convert.ToString(userid))
                            {
                                imgProfile.ImageUrl = "~/User/profile_image/" + dt.Rows[0]["user_image"].ToString();
                            }
                            else
                            {
                                DataTable dtPhoto = new DataTable();
                                objUserCircleBAO.ID = userid;
                                objUserCircleBAO.proceduretype = "GP";
                                dtPhoto = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                                if (dtPhoto.Rows.Count > 0)
                                {
                                    if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                    {
                                        imgProfile.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";
                                    }
                                    else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                    {
                                        imgProfile.ImageUrl = "~/User/profile_image/" + dt.Rows[0]["user_image"].ToString();
                                    }
                                    else if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                    {
                                        imgProfile.ImageUrl = "~/User/profile_image/" + dt.Rows[0]["user_image"].ToString();
                                    }
                                }
                                else
                                {
                                    imgProfile.ImageUrl = "~/User/profile_image/" + dt.Rows[0]["user_image"].ToString();
                                }
                            }
                        }
                        lbUserName.Text = dt.Rows[0]["name"].ToString();
                        DataTable dtEmail = new DataTable();
                        objUserCircleBAO.ID = userid;
                        objUserCircleBAO.proceduretype = "GE1";
                        dtEmail = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                        if (dtEmail.Rows.Count > 0)
                        {
                            if (MySession.Current.LoginId == Convert.ToString(userid))
                            {
                                lbEmail.Visible = true;
                                lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                            }
                            else
                            {
                                if (dtEmail.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    DataTable dtuserFreind1 = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                    objAdminBAO.ID1 = userid;
                                    objAdminBAO.ProcedureType = "GF";
                                    dtuserFreind1 = AdminDAO.GetSearchDetail(objAdminBAO);
                                    if (dtuserFreind1.Rows.Count > 0)
                                    {
                                        lbEmail.Visible = true;
                                        lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                                    }
                                    else
                                    {
                                        lbEmail.Visible = false;
                                    }
                                }
                                else
                                {
                                    lbEmail.Visible = false;

                                }
                            }

                        }
                        else
                        {
                            lbEmail.Visible = false;
                        }
                       
                        DataTable dtDHW = new DataTable();
                        objUserCircleBAO.ID = userid;
                        objUserCircleBAO.proceduretype = "GD";
                        dtDHW = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                        if (dtDHW.Rows.Count > 0)
                        {
                            if (MySession.Current.LoginId == Convert.ToString(userid))
                            {
                                dvHeight.Visible = true;
                                lbHeight.Text = (dt.Rows[0]["height"].ToString()).Replace(".00", "") + "." + (dt.Rows[0]["height_inches"].ToString()) + " " + (dt.Rows[0]["height_units"].ToString());
                                dvWeight.Visible = true;
                                lbWeight.Text = (dt.Rows[0]["weight"].ToString()) + " " + (dt.Rows[0]["weight_units"].ToString());
                                dvDOB.Visible = true;
                                if (dt.Rows[0]["dateOfBirth"].ToString() == "0")
                                {
                                    lbDOB.Text = "--NA--";
                                }
                                else
                                {
                                    lbDOB.Text = dt.Rows[0]["monthOfBirth1"].ToString() + " " + dt.Rows[0]["dateOfBirth"].ToString();
                                }
                                dvLocation.Visible = true;
                                lbLocation.Text = dt.Rows[0]["location_name"].ToString();
                            }
                            else
                            {
                                if (dtDHW.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    dvHeight.Visible = false;
                                }
                                else if (dtDHW.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    DataTable dtuserFreind1 = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                    objAdminBAO.ID1 = userid;
                                    objAdminBAO.ProcedureType = "GF";
                                    dtuserFreind1 = AdminDAO.GetSearchDetail(objAdminBAO);
                                    if (dtuserFreind1.Rows.Count > 0)
                                    {
                                        dvHeight.Visible = true;
                                        lbHeight.Text = (dt.Rows[0]["height"].ToString()).Replace(".00", "") + "." + (dt.Rows[0]["height_inches"].ToString()) + " " + (dt.Rows[0]["height_units"].ToString());
                                    }
                                    else
                                    {
                                        dvHeight.Visible = false;
                                    }
                                }
                                else if (dtDHW.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dvHeight.Visible = true;
                                    lbHeight.Text = (dt.Rows[0]["height"].ToString()).Replace(".00", "") + "." + (dt.Rows[0]["height_inches"].ToString()) + " " + (dt.Rows[0]["height_units"].ToString());
                                }

                                if (dtDHW.Rows[1]["UPS_YOU"].ToString() == "True")
                                {
                                    dvWeight.Visible = false;
                                }
                                else if (dtDHW.Rows[1]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    DataTable dtuserFreind1 = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                    objAdminBAO.ID1 = userid;
                                    objAdminBAO.ProcedureType = "GF";
                                    dtuserFreind1 = AdminDAO.GetSearchDetail(objAdminBAO);
                                    if (dtuserFreind1.Rows.Count > 0)
                                    {
                                        dvWeight.Visible = true;
                                        lbWeight.Text = (dt.Rows[0]["weight"].ToString()) + " " + (dt.Rows[0]["weight_units"].ToString());
                                    }
                                    else
                                    {
                                        dvWeight.Visible = false;
                                    }
                                }
                                else if (dtDHW.Rows[1]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dvWeight.Visible = true;
                                    lbWeight.Text = (dt.Rows[0]["weight"].ToString()) + " " + (dt.Rows[0]["weight_units"].ToString());
                                }

                                if (dtDHW.Rows[2]["UPS_YOU"].ToString() == "True")
                                {
                                    dvDOB.Visible = false;
                                }
                                else if (dtDHW.Rows[2]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    DataTable dtuserFreind1 = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                    objAdminBAO.ID1 = userid;
                                    objAdminBAO.ProcedureType = "GF";
                                    dtuserFreind1 = AdminDAO.GetSearchDetail(objAdminBAO);
                                    if (dtuserFreind1.Rows.Count > 0)
                                    {
                                        dvDOB.Visible = true;
                                        if (dt.Rows[0]["dateOfBirth"].ToString() == "0")
                                        {
                                            lbDOB.Text = "--NA--";
                                        }
                                        else
                                        {
                                            lbDOB.Text = dt.Rows[0]["monthOfBirth1"].ToString() + " " + dt.Rows[0]["dateOfBirth"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dvDOB.Visible = false;
                                    }
                                }

                                else if (dtDHW.Rows[2]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dvDOB.Visible = true;
                                    if (dt.Rows[0]["dateOfBirth"].ToString() == "0")
                                    {
                                        lbDOB.Text = "--NA--";
                                    }
                                    else
                                    {
                                        lbDOB.Text = dt.Rows[0]["monthOfBirth1"].ToString() + " " + dt.Rows[0]["dateOfBirth"].ToString();
                                    }
                                }


                                if (dtDHW.Rows[2]["UPS_YOU"].ToString() == "True")
                                {
                                    dvLocation.Visible = false;
                                }
                                else if (dtDHW.Rows[2]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    DataTable dtuserFreind1 = new DataTable();
                                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                                    objAdminBAO.ID1 = userid;
                                    objAdminBAO.ProcedureType = "GF";
                                    dtuserFreind1 = AdminDAO.GetSearchDetail(objAdminBAO);
                                    if (dtuserFreind1.Rows.Count > 0)
                                    {
                                        dvLocation.Visible = true;
                                        lbLocation.Text = dt.Rows[0]["location_name"].ToString();
                                    }
                                    else
                                    {
                                        dvLocation.Visible = false;
                                    }
                                }
                                else if (dtDHW.Rows[2]["UPS_ANYONE"].ToString() == "True")
                                {
                                    dvLocation.Visible = true;
                                    lbLocation.Text = dt.Rows[0]["location_name"].ToString();
                                }


                            }

                        }
                        else
                        {
                            lbEmail.Text = dt.Rows[0]["login_email"].ToString();
                            dvHeight.Visible = false;
                            dvLocation.Visible = false;
                            dvDOB.Visible = false;
                            dvWeight.Visible = false;
                        }
                    }
                }

                DataTable dtFreinds = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ID1 = circleid;
                objAdminBAO.ProcedureType = "UF";
                dtFreinds = AdminDAO.GetSearchDetail(objAdminBAO);
                if (MySession.Current.LoginId == Convert.ToString(userid))
                {
                    GrdFreinds.DataSource = dtFreinds;
                    GrdFreinds.DataBind();
                }
                else
                {
                    DataTable dtPrivacy = new DataTable();
                    objUserCircleBAO.ID = userid;
                    objUserCircleBAO.proceduretype = "GF";
                    dtPrivacy = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                    if (dtPrivacy.Rows.Count > 0)
                    {
                        if (dtPrivacy.Rows[0]["UPS_ANYONE"].ToString() == "True")
                        {
                            GrdFreinds.DataSource = dtFreinds;
                            GrdFreinds.DataBind();
                        }
                        else if (dtPrivacy.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                        {
                            DataTable dtuserFreind = new DataTable();
                            objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                            objAdminBAO.ID1 = userid;
                            objAdminBAO.ProcedureType = "GF";
                            dtuserFreind = AdminDAO.GetSearchDetail(objAdminBAO);
                            if (dtuserFreind.Rows.Count > 0)
                            {
                                GrdFreinds.DataSource = dtFreinds;
                                GrdFreinds.DataBind();
                            }
                            else
                            {
                                lbmsg.Visible = true;
                                lbmsg.Text = "You have no authority to view members until unless you join the circle";
                            }

                        }
                        else if (dtPrivacy.Rows[0]["UPS_YOU"].ToString() == "True")
                        {
                            lbmsg.Visible = true;
                            //dtFreinds = null;
                            //GrdFreinds.DataSource = dtFreinds;
                            //GrdFreinds.DataBind();
                        }
                    }
                    else
                    {
                        GrdFreinds.DataSource = dtFreinds;
                        GrdFreinds.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindPublicCircles()
        {
            try
            {
                DataTable dt = new DataTable();
                if (userid == Convert.ToInt32(MySession.Current.LoginId))
                {
                    objAdminBAO.ID = userid;
                    objAdminBAO.ProcedureType = "UC";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
                    objAdminBAO.ProcedureType = "GC";
                    dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        MySession.Current.PublicPermissions = dt1.Rows[0]["fk_circle_permission_id"].ToString();
                    }


                    objAdminBAO.ID = userid;
                    objAdminBAO.ID1 = circleid;
                    //if (MySession.Current.PublicPermissions == "2" || MySession.Current.PublicPermissions == "3")
                    //{
                    //    objAdminBAO.ProcedureType = "BC1";
                    //}
                    //else
                    //{
                        objAdminBAO.ProcedureType = "BC";
                    //}
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lbCircle.Visible = false;
                        dlcirclelist.DataSource = dt;
                        dlcirclelist.DataBind();
                    }
                    else
                    {
                        lbCircle.Visible = true;
                    }
                }
                else
                {
                    lbCircle.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindSelectedCircle()
        {
            try
            {
                DataTable dt1 = new DataTable();
                if (MySession.Current.PublicCircleId == "" || MySession.Current.PublicCircleId == null)
                {
                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
                }
                else
                {
                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.PublicCircleId);
                }
                objAdminBAO.ProcedureType = "GC";
                dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt1.Rows.Count > 0)
                {
                    MySession.Current.PublicPermissions = dt1.Rows[0]["fk_circle_permission_id"].ToString();
                }
                DataTable dtCircle = new DataTable();
                objAdminBAO.ID = userid;
                if (Convert.ToString(Request.QueryString["val1"]) == null || Convert.ToString(Request.QueryString["val1"]) == "")
                {
                    objAdminBAO.ID1 = circleid;
                }
                else
                {
                    circleid = Convert.ToInt32(Request.QueryString["val1"]);
                    objAdminBAO.ID1 = circleid;
                }
                //if (MySession.Current.PublicPermissions == "2" || MySession.Current.PublicPermissions == "3")
                //{
                //    objAdminBAO.ProcedureType = "UC1";
                //}
                //else
                //{
                    objAdminBAO.ProcedureType = "UC";
                //}
                dtCircle = AdminDAO.GetSearchDetail(objAdminBAO);
                if (dtCircle.Rows.Count > 0)
                {
                    dlCircle.DataSource = dtCircle;
                    dlCircle.DataBind();
                    //if (dtCircle.Rows[0]["fk_circle_permission_id"].ToString() == "2")
                    //{
                    //    lbJoin.Visible = false;
                    //}
                    //else if (dtCircle.Rows[0]["fk_circle_permission_id"].ToString() == "3")
                    //{
                    //    lbJoin.Visible = true;
                    //}
                }
                else
                {
                    DVDefaulrt.Visible = true;
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(userid);
                    objAdminBAO.ProcedureType = "N1";
                    dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        lbname1.Text = dt.Rows[0]["name"].ToString();
                        lbname11.Text = dt.Rows[0]["name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void GrdFreinds_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnImage = (HiddenField)e.Row.FindControl("hdnImage");
                    Image ImgFreind = (Image)e.Row.FindControl("ImgFreind");
                    Label lbID = (Label)e.Row.FindControl("lbID");
                    if (hdnImage.Value == "" || hdnImage.Value == null)
                    {
                        ImgFreind.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";
                    }
                    else
                    {
                        if (MySession.Current.LoginId == Convert.ToString(lbID.Text))
                        {
                            ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImage.Value;
                        }
                        else
                        {
                            DataTable dtPhoto = new DataTable();
                            objUserCircleBAO.ID = Convert.ToInt32(lbID.Text);
                            objUserCircleBAO.proceduretype = "GP";
                            dtPhoto = UserCirclesDAO.GetUserNameEmail(objUserCircleBAO);
                            if (dtPhoto.Rows.Count > 0)
                            {
                                if (dtPhoto.Rows[0]["UPS_YOU"].ToString() == "True")
                                {
                                    ImgFreind.ImageUrl = "~/User/profile_image/profileBlankPhoto.jpg";
                                }
                                else if (dtPhoto.Rows[0]["UPS_FRIENDS"].ToString() == "True")
                                {
                                    ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImage.Value;
                                }
                                else if (dtPhoto.Rows[0]["UPS_ANYONE"].ToString() == "True")
                                {
                                    ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImage.Value;
                                }
                            }
                            else
                            {
                                ImgFreind.ImageUrl = "~/User/profile_image/" + hdnImage.Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void dlcirclelist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    HtmlGenericControl divCircle = (HtmlGenericControl)e.Item.FindControl("divCircle");
                    HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                    divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                    divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void dlCircle_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdnColor = (HiddenField)e.Item.FindControl("hdnColor");
                    HiddenField hdnImage = (HiddenField)e.Item.FindControl("hdnImage");
                    HtmlGenericControl divCircle = (HtmlGenericControl)e.Item.FindControl("divCircle");
                    HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                    divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                    divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        //private void BindNotes()
        //{
        //    DataTable dtNotes = new DataTable();
        //    objAdminBAO.ID = userid;
        //    objAdminBAO.ID1 = circleid;
        //    objAdminBAO.ProcedureType = "UN";
        //    dtNotes = AdminDAO.GetSearchDetail(objAdminBAO);
        //    if (dtNotes.Rows.Count > 0)
        //    {
        //        dlNotes.DataSource = dtNotes;
        //        dlNotes.DataBind();
        //        lbNotes.Visible = false;
        //    }
        //    else
        //    {
        //        lbNotes.Visible = true;
        //    }
        //}

        private void BindInspirators()
        {
            try
            {
                DataTable dtInspirator = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ID1 = circleid;
                objAdminBAO.ProcedureType = "UI";
                dtInspirator = AdminDAO.GetSearchDetail(objAdminBAO);
                if (dtInspirator.Rows.Count > 0)
                {
                    lbInspiartor.Visible = false;
                    dlInspirators.DataSource = dtInspirator;
                    dlInspirators.DataBind();
                }
                else
                {
                    lbInspiartor.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void BindMission()
        {
            try
            {
                DataTable dtMission = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ID1 = circleid;
                objAdminBAO.ProcedureType = "UM";
                dtMission = AdminDAO.GetSearchDetail(objAdminBAO);
                if (dtMission.Rows.Count > 0)
                {
                    lbMission.Visible = false;
                    dlMissions.DataSource = dtMission;
                    dlMissions.DataBind();
                }
                else
                {
                    lbMission.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                DataTable dt1 = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(circleid);
                objAdminBAO.ProcedureType = "GC";
                dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt1.Rows.Count > 0)
                {
                    MySession.Current.PublicPermissions = dt1.Rows[0]["fk_circle_permission_id"].ToString();
                }
                if (MySession.Current.PublicPermissions == "3")
                {
                    DataTable dt = new DataTable();

                    if (Convert.ToString(Request.QueryString["val2"]) == "" || Convert.ToString(Request.QueryString["val2"]) == null)
                    {
                        objUserCircleBAO.fk_user_registration_Id = userid;
                        objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserCircleBAO.fk_circle_id = circleid;
                        objUserCircleBAO.request_status = 5; 
                    }
                    else
                    {
                        objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserCircleBAO.friend_registration_id = userid;
                        objUserCircleBAO.fk_circle_id = circleid;
                        objUserCircleBAO.request_status =7; 
                    }
                 
                  // Requested to add in the circle
                    objUserCircleBAO.updated_on = System.DateTime.Now;
                    objUserCircleBAO.proceduretype = "I";
                    UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                    btnJoin.Visible = false;
                    lbmsgsent.Visible = true;
                    lbJoin.Visible = false;
                    btnInvitation.Visible = false;

                }
                else if (MySession.Current.PublicPermissions == "2")
                {
                    objUserCircleBAO.fk_user_registration_Id = userid;
                    objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserCircleBAO.fk_circle_id = circleid;
                    objUserCircleBAO.request_status = 2; //Accept Request
                    objUserCircleBAO.updated_on = System.DateTime.Now;
                    objUserCircleBAO.proceduretype = "I";
                    UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);

                    MySession.Current.SelectedCircleUserId = Convert.ToString( userid);
                    MySession.Current.CircleId = Convert.ToString( circleid);
                    Session["NewcircleId"] = MySession.Current.CircleId; // Select Circle ID
                    Session["Topselcircle"] = MySession.Current.CircleId;//to display circle name at top
                    MySession.Current.PublicCircleUserId = "";
                    MySession.Current.PublicCircleId = "";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow3", "parentwindow3();", true);
                }
            }

            catch (Exception ex)
            {

            }
        }
        protected void btnInvitation_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Int32 frdreq = 0;
                DataTable dt = new DataTable();
                objUserCircleBAO.userRegistration_ID = Convert.ToInt32(MySession.Current.LoginId);
                if (MySession.Current.searchfriendId == null || MySession.Current.searchfriendId == "")
                {
                    objUserCircleBAO.userfriend_ID = Convert.ToInt32(userid);
                }
                else
                {
                    objUserCircleBAO.userfriend_ID = Convert.ToInt32(MySession.Current.searchfriendId);
                }
                objUserCircleBAO.fk_circle_ID = circleid;
                objUserCircleBAO.fk_circlePermission_ID = 0;
                objUserCircleBAO.proceduretype = "GS";
                dt = UserCirclesDAO.GetUserFriendPublicCircles(objUserCircleBAO);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["fk_request_status_id"].ToString() == "3")
                    { 
                        objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.searchfriendId);
                        objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                        objUserCircleBAO.fk_circle_id = circleid;
                        objUserCircleBAO.request_status = 1; //Accept Request
                        objUserCircleBAO.updated_on = System.DateTime.Now;
                        objUserCircleBAO.proceduretype = "A";
                        frdreq = UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                     
                    }
                }
                else
                {
                    objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    if (MySession.Current.searchfriendId == null || MySession.Current.searchfriendId == "")
                    {
                        objUserCircleBAO.friend_registration_id = Convert.ToInt32(userid);
                    }
                    else
                    {
                        objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.searchfriendId);
                    }
                    objUserCircleBAO.fk_circle_id = MySession.Current.CircleId;
                    DataTable dt1 = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(circleid);
                    objAdminBAO.ProcedureType = "GC";
                    dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        MySession.Current.PublicPermissions = dt1.Rows[0]["fk_circle_permission_id"].ToString();
                    }
                    if (MySession.Current.PublicPermissions == "3")
                    {
                        objUserCircleBAO.request_status =7;
                    }
                    else
                    {

                        objUserCircleBAO.request_status = 1;
                    }
                    objUserCircleBAO.updated_on = System.DateTime.Now;
                    objUserCircleBAO.proceduretype = "I";
                   
                    frdreq = UserCirclesDAO.SendFriendRequest(objUserCircleBAO);
                }
                    if (frdreq > 0)
                    {

                        //lbmemberinvitation.Visible = true;
                        //lbmemberinvitation.Text = "Invitation has been successfully sent to join your " + MySession.Current.SelectedCircleName;
                        btnJoin.Visible = false;
                        lbmsgsent.Visible = true;
                        lbJoin.Visible = false;
                        btnInvitation.Visible = false;
                        // Session["USerProfile"] = true;

                    }
                    else
                    {
                        //  Session["USerProfile"] = true;
                        btnJoin.Visible = false;
                        lbmsgsent.Visible = true;
                        lbmsgsent.Text = "Request already sent.";
                        lbJoin.Visible = false;
                        btnInvitation.Visible = false;
                    }
                    MySession.Current.searchfriendId = null;
                }
            
            catch (Exception ex)
            {

            }
        }

        private void checkUser()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserCircleBAO.UserId = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.fk_circle_id = circleid;

                objUserCircleBAO.proceduretype = "S";
                dt = UserCirclesDAO.GetUserCircles(objUserCircleBAO);

                objUserCircleBAO.request_status = Convert.ToInt32(MySession.Current.StatusID);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["fk_request_status_id"].ToString() == "2")
                    {
                        btnAcceptInvitation.Visible = false;
                        btnRejectInvitation.Visible = false;
                        btnInvitation.Visible = false;
                        btnJoin.Visible = false;
                        lbmsgsent.Visible = false;
                        lbJoin.Visible = true;
                        lbJoin.Text = "You are already member of this circle";
                    }
                    else if (dt.Rows[0]["fk_request_status_id"].ToString() == "5")
                    {
                        btnAcceptInvitation.Visible = false;
                        btnRejectInvitation.Visible = false;
                        btnInvitation.Visible = false;
                        btnJoin.Visible = false;
                        lbmsgsent.Visible = true;
                        lbJoin.Visible = false;
                    }
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    objUserRegisterBAO.ID = circleid;
                    objUserRegisterBAO.procedureType = "GC";
                    dt1 = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0]["fk_user_registration_Id"].ToString() != MySession.Current.LoginId)
                        {
                            if (dt1.Rows[0]["fk_circle_permission_id"].ToString() == "3")
                            {
                                btnAcceptInvitation.Visible = false;
                                btnRejectInvitation.Visible = false;
                                MySession.Current.PublicPermissions = "3";
                                lbmsgsent.Visible = false;
                                lbJoin.Visible = true;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = true;
                            }
                            else
                            {
                                btnAcceptInvitation.Visible = false;
                                btnRejectInvitation.Visible = false;
                                MySession.Current.PublicPermissions = "2";
                                lbmsgsent.Visible = false;
                                lbJoin.Visible = false;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = true;
                            }
                        }
                        else
                        {
                            btnAcceptInvitation.Visible = false;
                            btnRejectInvitation.Visible = false;
                            lbmsgsent.Visible = false;
                            lbJoin.Visible = false;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //}
        }

        protected void btnAcceptInvitation_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                AcceptInvitation();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void AcceptInvitation()
        {
            try
            {
                string userfkid="";
                string circlename = "";
                DataTable dt1 = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(circleid);
                objAdminBAO.ProcedureType = "GC";
                dt1 = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt1.Rows.Count > 0)
                {
                    MySession.Current.PublicPermissions = dt1.Rows[0]["fk_circle_permission_id"].ToString();
                    userfkid= Convert.ToString(dt1.Rows[0]["fk_user_registration_Id"]);
                    circlename = Convert.ToString(dt1.Rows[0]["circle_name"]);
                }
                objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.friend_registration_id = userid;
                objUserCircleBAO.fk_circle_id = circleid;
                objUserCircleBAO.request_status = 2; //Accept Request
                objUserCircleBAO.updated_on = System.DateTime.Now;
                if (MySession.Current.PublicPermissions == "3")
                {
                    objUserCircleBAO.proceduretype = "U";
                }
                else
                {
                    objUserCircleBAO.proceduretype = "A";
                }
                UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                MySession.Current.SelectedCircleUserId = MySession.Current.MemberUserId;
                MySession.Current.CircleId = MySession.Current.MemberCircleId;
                Session["NewcircleId"] = MySession.Current.MemberCircleId; // Select Circle ID
                Session["Topselcircle"] = MySession.Current.MemberCircleId;//to display circle name at top
                MySession.Current.MemberCircleId = "";
                MySession.Current.MemberUserId = "";
               
                if (MySession.Current.PublicPermissions == "3")
                {
                    if (MySession.Current.LoginId == Convert.ToString(userfkid))
                    {
                        Response.Redirect("PendingFriendRequests.aspx", false);
                    }
                    else
                    {
                        MySession.Current.SelectedCircleName = circlename;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow3", "parentwindow3();", true);
                    }
                }
                else
                {
                    MySession.Current.SelectedCircleName = circlename;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "parentwindow1", "parentwindow1()", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow3", "parentwindow3();", true);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void GetFriendProfile()
        {

            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
                objAdminBAO.ProcedureType = "GC";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    MySession.Current.PublicPermissions = dt.Rows[0]["fk_circle_permission_id"].ToString();
                }

                int mutualfrd = 0;
                objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.searchfriendId);
                mutualfrd = UserCirclesDAO.GetMutualFriends(objUserCircleBAO);

                if (MySession.Current.searchfriendId == MySession.Current.LoginId)
                {
                    divmsg.Visible = false;
                    btnInvitation.Visible = false;
                }
                else
                {

                    if (mutualfrd == 1) // already Member of this current circle
                    {
                        lbJoin.Visible = true;
                        lbJoin.Text = "This member is already in your " + MySession.Current.SelectedCircleName;
                        if (MySession.Current.PublicPermissions == "2")
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "This member is already in your " + MySession.Current.SelectedCircleName;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            //lbJoin.Visible = false;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                        else if (MySession.Current.PublicPermissions == "3")
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "This member is already in your " + MySession.Current.SelectedCircleName;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                           // lbJoin.Visible = true;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                        else
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "This member is already in your " + MySession.Current.SelectedCircleName;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            lbJoin.Visible = true;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                    }
                    else if (mutualfrd == 2) // already Member but not this current circle
                    {
                        lbJoin.Visible = true;
                        lbJoin.Text = "This member is already in your other circle";
                        if (MySession.Current.PublicPermissions == "2")
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "This member is already in your other circle";
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            //lbJoin.Visible = false;
                            btnInvitation.Visible = true;
                            btnJoin.Visible = false;
                        }
                        else if (MySession.Current.PublicPermissions == "3")
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "This member is already in your other circle";
                            lbmsgsent.Visible = false;
                            lbJoin.Visible = true;
                            btnInvitation.Visible = true;
                            btnSendmsg.Visible = false;
                            btnJoin.Visible = false;
                            divmsg.Visible = false;
                        }

                        else
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "This member is already in your other circle";
                            btnSendmsg.Visible = false;
                            btnJoin.Visible = false;
                            lbJoin.Visible = true;
                            divmsg.Visible = false;
                            btnInvitation.Visible = true;
                        }
                    }
                    else if (mutualfrd == 3) // Invitation already sent to this Member for this current circle but not approved yet
                    {
                        lbJoin.Visible = true;
                        lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                        if (MySession.Current.PublicPermissions == "2")
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            //lbJoin.Visible = false;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                        else if (MySession.Current.PublicPermissions == "3")
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            lbJoin.Visible = true;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                        else
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            lbJoin.Visible = true;
                            btnInvitation.Visible = false;
                            btnJoin.Visible = false;
                        }
                    }
                    //if (mutualfrd == 4) // Invitation already sent to this Member for other circle but not approved yet
                    //{
                    //    lbmemberinvitation.Visible = true;
                    //    lbmemberinvitation.Text = "Invitation already sent to join other circle";
                    //    btnsendfrdrequest.Visible = true;                   
                    //}
                    else   if (mutualfrd == 5) // Not A member of any circle
                    {

                        if (MySession.Current.PublicPermissions == "2")
                        {
                            divmsg.Visible = false;
                            lbmsgsent.Visible = false;
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            lbJoin.Visible = false;
                            btnInvitation.Visible = true;
                            btnJoin.Visible = false;
                            btnInvitation.Visible = false;
                        }
                        else if (MySession.Current.PublicPermissions == "3")
                        {
                            lbmsgsent.Visible = false;
                            lbJoin.Visible = true;
                            btnInvitation.Visible = false;
                            btnSendmsg.Visible = false;
                            btnJoin.Visible = true;
                            divmsg.Visible = false;
                        }
                        else
                        {
                            btnSendmsg.Visible = false;
                            btnJoin.Visible = false;
                            lbJoin.Visible = false;
                            divmsg.Visible = false;
                            btnInvitation.Visible = true;
                        }
                    
                        //if (MySession.Current.PublicPermissions == "2")
                        //{
                        //    btnSendmsg.Visible = true;
                        //}

                    }
                    else
                    {
                        DataTable dtuserFreind1 = new DataTable();
                        objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                        objAdminBAO.ID1 = userid;
                        objAdminBAO.ID2 = Convert.ToInt32(MySession.Current.CircleId);
                        objAdminBAO.ProcedureType = "S";
                        dtuserFreind1 = AdminDAO.GetUserMemberStatus(objAdminBAO);
                        if (dtuserFreind1.Rows.Count > 0)
                        {
                            lbJoin.Visible = true;
                            lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                            if (MySession.Current.PublicPermissions == "2")
                            {
                                lbJoin.Visible = true;
                                lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                                lbmsgsent.Visible = false;
                                divmsg.Visible = false;
                                btnSendmsg.Visible = false;
                                //lbJoin.Visible = false;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = false;
                                return;
                            }
                            else if (MySession.Current.PublicPermissions == "3")
                            {
                                lbJoin.Visible = true;
                                lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                                lbmsgsent.Visible = false;
                                divmsg.Visible = false;
                                btnSendmsg.Visible = false;
                                lbJoin.Visible = true;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = false;
                                return;
                            }
                            else
                            {
                                lbJoin.Visible = true;
                                lbJoin.Text = "Invitation already sent to join your " + MySession.Current.SelectedCircleName;
                                lbmsgsent.Visible = false;
                                divmsg.Visible = false;
                                btnSendmsg.Visible = false;
                                lbJoin.Visible = true;
                                btnInvitation.Visible = false;
                                btnJoin.Visible = false;
                                return;
                            }
                        }
                        if (MySession.Current.PublicPermissions == "2")
                        {
                            divmsg.Visible = false;
                            btnSendmsg.Visible = false;
                            lbJoin.Visible = false;
                            btnInvitation.Visible = true;
                            btnJoin.Visible = false;
                        }
                        else if (MySession.Current.PublicPermissions == "3")
                        {
                            lbmsgsent.Visible = false;
                            lbJoin.Visible = false; 
                            btnInvitation.Visible = true;
                            btnSendmsg.Visible = false;
                            btnJoin.Visible = false ;
                            divmsg.Visible = false;
                        }

                        else
                        {
                            btnSendmsg.Visible = false;
                            btnJoin.Visible = false;
                            lbJoin.Visible = false;
                            divmsg.Visible = false;
                            btnInvitation.Visible = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            { }

        }

        protected void btnSendmsg_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserCircleBAO.CI_ID = 0;
                objUserCircleBAO.fk_login_id = Convert.ToInt32(MySession.Current.LoginId);
                if (MySession.Current.searchfriendId == null || MySession.Current.searchfriendId == "")
                {
                    objUserCircleBAO.freind_user_id = userid;
                }
                else
                {
                    objUserCircleBAO.freind_user_id = Convert.ToInt32(MySession.Current.searchfriendId);
                }
                if (txtMessage.Text != "")
                {
                    objUserCircleBAO.CI_MESSAGE = txtMessage.Text;
                }
                else
                {
                    objUserCircleBAO.CI_MESSAGE = "This is my public circle , request you to join this circle.";
                }
                objUserCircleBAO.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                objUserCircleBAO.CI_DATE = DateTime.Now.ToString();
                objUserCircleBAO.CI_STATUS = "False";
                objUserCircleBAO.proceduretype = "I";
                retval = UserCirclesDAO.InsertCircleInvitation(objUserCircleBAO);
                lbmsgsent.Visible = true;
                
                lbmsgsent.Text = "Invitation has been successfully sent to join your " + MySession.Current.SelectedCircleName;
                divmsg.Visible = false;
                btnSendmsg.Visible = false;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnRejectInvitation_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                RejectInvitation();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void RejectInvitation()
        {
            try
            {
                objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserCircleBAO.friend_registration_id = userid;
                objUserCircleBAO.fk_circle_id = circleid;
                objUserCircleBAO.request_status = 3; //Accept Request
                objUserCircleBAO.updated_on = System.DateTime.Now;
                objUserCircleBAO.proceduretype = "A";
                UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                MySession.Current.SelectedCircleUserId = MySession.Current.MemberUserId;
                MySession.Current.CircleId = MySession.Current.MemberCircleId;
                Session["NewcircleId"] = MySession.Current.MemberCircleId; // Select Circle ID
                Session["Topselcircle"] = MySession.Current.MemberCircleId;//to display circle name at top
                MySession.Current.MemberCircleId = "";
                MySession.Current.MemberUserId = "";
                btnRejectInvitation.Visible = false;
                btnAcceptInvitation.Visible = false;
                Response.Redirect("PendingFriendRequests.aspx", false);

            }
            catch (Exception ex)
            {

            }
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (Convert.ToString(Session["Leave"]) == "True")
                {
                    objUserCircleBAO.fk_user_registration_Id = userid;
                    objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserCircleBAO.fk_circle_id = circleid;
                    objUserCircleBAO.request_status = 6;
                    objUserCircleBAO.updated_on = System.DateTime.Now;
                    objUserCircleBAO.proceduretype = "D1";   //remove friend
                    UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                    Session["selectedcircleid"] = MySession.Current.LoginId + "-" + MySession.Current.CircleId;
                    Session["Topselcircle"] = MySession.Current.CircleId;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow3", "parentwindow3();", true);
                }
                else
                {
                    objUserCircleBAO.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserCircleBAO.friend_registration_id = userid;
                    objUserCircleBAO.fk_circle_id = circleid;
                    objUserCircleBAO.request_status = 6;
                    objUserCircleBAO.updated_on = System.DateTime.Now;
                    objUserCircleBAO.proceduretype = "D";   //remove friend
                    UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                    objUserCircleBAO.fk_user_registration_Id = userid;
                    objUserCircleBAO.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserCircleBAO.fk_circle_id = circleid;
                    objUserCircleBAO.request_status = 6;
                    objUserCircleBAO.updated_on = System.DateTime.Now;
                    objUserCircleBAO.proceduretype = "D";   //remove friend
                    UserCirclesDAO.AcceptFriendRequest(objUserCircleBAO);
                    Response.Redirect("MemberList.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GrdFreinds_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            if (e.CommandName == "ImgBtnFrnd")
            {
                string id = e.CommandArgument.ToString();
                if (MySession.Current.LoginId == Convert.ToString(id))
                {
                }
                else
                {
                    Session["USerProfile"] = true;
                }
                Response.Redirect("~/User/MyProfile.aspx?val=" + id, false);
            }
        }

        protected void dlMissions_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "LnkMission")
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    string missionid = arg[0];
                    string useriid = arg[1];
                    DataTable dt = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.ID1 = Convert.ToInt32(useriid);
                    objAdminBAO.ProcedureType = "GF";
                    dt = AdminDAO.GetSearchDetail(objAdminBAO);
                    if (dt.Rows.Count > 0)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Session["track_mission_graphs"] = "True";
                        Session["selected_mission_id"] = Convert.ToInt32(missionid);
                        Response.Redirect("~/User/Missions.aspx", false);
                    }
                    else
                    {
                        DataTable dtMission = new DataTable();
                        objAdminBAO.ID = Convert.ToInt32(useriid);
                        objAdminBAO.ID1 = Convert.ToInt32(missionid);
                        objAdminBAO.ProcedureType = "GM";
                        dtMission = AdminDAO.GetSearchDetail(objAdminBAO);
                        if (dtMission.Rows.Count > 0)
                        {
                            this.PnlInspirator_ModalPopupExtender.Show();
                            lbMissionName.Text = dtMission.Rows[0]["mission_name"].ToString();
                            lbUsersname.Text = dtMission.Rows[0]["name"].ToString();
                            lbCDate.Text = dtMission.Rows[0]["date_created_on"].ToString();
                            lbDDate.Text = dtMission.Rows[0]["deadline_date_set"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void dlInspirators_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkViewInsp")
                {
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    useriispd = arg[0];
                    inspiratorid = arg[1];
                    this.ModalPopupExtender1.Show();
                    bindDesc();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        
        }

        private void bindDesc()
        {
            try
            {
                DataTable dt = new DataTable();
                objUserInspiratorBAL.pk_Inspirator_id = inspiratorid;
                objUserInspiratorBAL.ProcedureType = "S";
                dt = UserInspiratorsDAL.GetViewInspirator(objUserInspiratorBAL);
                if (dt.Rows.Count > 0)
                {
                    Image1.ImageUrl = "../User/InspiratorImages/" + dt.Rows[0]["Inspirator_image"].ToString();
                    lbName.Text = dt.Rows[0]["first_name"].ToString();
                    lbDesc.Text = dt.Rows[0]["Inspirator_desc"].ToString();
                    MySession.Current.LabelId = dt.Rows[0]["pk_Inspirator_id"].ToString();

                    DataTable dt1 = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
                    objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    objUserInspiratorBAL.ProcedureType = "S";
                    dt1 = UserInspiratorsDAL.GetUserInspiratorLike(objUserInspiratorBAL);
                    if (dt1.Rows.Count > 0)
                    {
                        lnkInspLike.Text = "Liked";
                        lnkInspLike.Enabled = false;
                    }
                    else
                    {

                        lnkInspLike.Text = "Like";
                        lnkInspLike.Enabled = true;

                    }
                    DataTable dtlike = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
                    objUserInspiratorBAL.ProcedureType = "L";
                    dtlike = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
                    if (dtlike.Rows.Count > 0)
                    {
                        lbLikeCount.Text = dtlike.Rows[0]["nooflike"].ToString();
                    }
                    else
                    {
                        lbLikeCount.Text = "0";
                    }

                    DataTable dtcomment = new DataTable();
                    objUserInspiratorBAL.fk_Inspirator_id = MySession.Current.LabelId;
                    objUserInspiratorBAL.ProcedureType = "C";
                    dtcomment = UserInspiratorsDAL.GetCountLCInspirator(objUserInspiratorBAL);
                    if (dtcomment.Rows.Count > 0)
                    {
                        lbCommentCount.Text = dtcomment.Rows[0]["noofcomments"].ToString();
                    }
                    else
                    {
                        lbCommentCount.Text = "0";
                    }



                    DataTable dtCommentDesc = new DataTable();
                    objUserInspiratorBAL.pk_Inspirator_id = inspiratorid;
                    objUserInspiratorBAL.ProcedureType = "C";
                    dtCommentDesc = UserInspiratorsDAL.GetViewInspirator(objUserInspiratorBAL);
                    if (dtCommentDesc.Rows.Count > 0)
                    {
                        divComments.Style.Add("display", "");
                        Repeater1.DataSource = dtCommentDesc;
                        Repeater1.DataBind();
                    }
                    else
                    {
                        divComments.Style.Add("display", "none");
                    }


                }
                if (MySession.Current.LoginId == useriispd)
                {
                    lnkInspLike.Enabled = true;
                    txtComments.Enabled = true;
                    btnComment.Enabled = true;
                }
                else
                {
                    DataTable dtDesc = new DataTable();
                    objAdminBAO.ID = Convert.ToInt32(MySession.Current.LoginId);
                    objAdminBAO.ID1 = Convert.ToInt32(useriispd);
                    objAdminBAO.ProcedureType = "GF";
                    dtDesc = AdminDAO.GetSearchDetail(objAdminBAO);
                    if (dtDesc.Rows.Count > 0)
                    {
                        lnkInspLike.Enabled = true;
                        txtComments.Enabled = true;
                        btnComment.Enabled = true;
                    }
                    else
                    {

                        lnkInspLike.Enabled = false;
                        txtComments.Enabled = false;
                        btnComment.Enabled = false;
                        lnkInspLike.Style.Add("cursor", "not-allowed");
                        btnComment.Style.Add("cursor", "not-allowed");

                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkInspLike_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserInspiratorBAL.pk_InspiratorLiked_id = 0;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.InspiratorLiked_on = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorLike(objUserInspiratorBAL);
                bindDesc();
                BindInspirators();
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkComments_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
        }


     
        protected void btnComment_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                int retval = 0;
                objUserInspiratorBAL.pk_InspiratorComments_id = 0;
                objUserInspiratorBAL.InspiratorComment_text = txtComments.Text;
                objUserInspiratorBAL.fk_Inspirator_id = Convert.ToInt32(inspiratorid);
                objUserInspiratorBAL.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objUserInspiratorBAL.InspiratorComment_on = DateTime.Now.ToString();
                objUserInspiratorBAL.ProcedureType = "I";
                retval = UserInspiratorsDAL.InsertInspiratorComment(objUserInspiratorBAL);
                bindDesc();
                BindInspirators();
                txtComments.Text = "";
                this.ModalPopupExtender1.Show();
                panel4.Visible = true;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void dlcirclelist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "lnkView")
            {
                MySession.Current.PublicCircleUserId = "";
                MySession.Current.PublicCircleId ="";
                MySession.Current.MemberUserId = "";
               
                string[] arg = new string[3];
                arg = e.CommandArgument.ToString().Split(';');
                string userID = arg[0];
                string CircleiD = arg[1];
                string circlename = arg[2];
                userid = Convert.ToInt32(userID);
                circleid = Convert.ToInt32(CircleiD);
                if (MySession.Current.LoginId == userID)
                {
                   
                }
                else
                {
                    MySession.Current.searchfriendId = "";
                        MySession.Current.PublicCircleUserId = Convert.ToString(userid);
                        MySession.Current.PublicCircleId = Convert.ToString(circleid);
                    
                    Session["USerProfile"] = true;
                }
                MySession.Current.SelectedCircleName = circlename;
                Response.Redirect("~/User/MyProfile.aspx?val1="+CircleiD, false);
            }
        }

    }
}