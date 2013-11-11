using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAO.User;

namespace ALEREIMPACT.User
{
    public partial class ucAcceptInvitation : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {
                            //btnJoinPublicGroup.Visible = false;
                            //btnAcceptInvitation.Visible = false;
                            // test();
                            if (MySession.Current.StatusID == "5")
                            {
                                lblmsgRequestSent.Visible = true;
                                btnJoinPublicGroup.Visible = false;
                                btnAcceptInvitation.Visible = false;
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            checkUser();
                            // test();

                        }
                    }
                    else
                    {
                        if (MySession.Current.PublicCircleUserId == null || MySession.Current.PublicCircleUserId == "")
                        {

                            btnJoinPublicGroup.Visible = false;
                            btnAcceptInvitation.Visible = true;
                        }
                        else
                        {
                            checkUser();
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void checkUser()
        {
            DataTable dt = new DataTable();
            objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
            objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
            
            objusercircles.proceduretype = "S";
            dt = UserCirclesDAO.GetUserCircles(objusercircles);

            objusercircles.request_status = Convert.ToInt32(MySession.Current.StatusID);
                if (dt.Rows.Count > 0)
                {
                    
                    lblmsgRequestSent.Visible = true;
                    btnAcceptInvitation.Visible = false;
                    btnJoinPublicGroup.Visible = false;
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    objRegisterUserBAO.ID = Convert.ToInt32(MySession.Current.CircleId);
                       objRegisterUserBAO.procedureType="GC";
                    dt1= RegisterUserDAO.GetInvitationDetail(objRegisterUserBAO);
                    if (dt1.Rows.Count > 0)
                    {
                        if (dt1.Rows[0]["fk_user_registration_Id"].ToString() != MySession.Current.LoginId)
                        {
                            if (dt1.Rows[0]["fk_circle_permission_id"].ToString() == "3")
                            {
                                lbJoin.Visible = true;
                                btnAcceptInvitation.Visible = false;
                                btnJoinPublicGroup.Visible = true;
                            }
                            else
                            {
                                lbJoin.Visible = false;
                                btnAcceptInvitation.Visible = false;
                                btnJoinPublicGroup.Visible = true;
                            }
                        }
                        else
                        {
                            lbJoin.Visible = false;
                            btnAcceptInvitation.Visible = false;
                            btnJoinPublicGroup.Visible = false;
                        }
                    }
                 
                }

            //}
        }

        protected void btnAcceptInvitation_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            AcceptInvitation();
        }

        private void AcceptInvitation()
        {
            try
            {
                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                objusercircles.friend_registration_id = Convert.ToInt32(MySession.Current.MemberUserId);
                objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.MemberCircleId);
                objusercircles.request_status = 2; //Accept Request
                objusercircles.updated_on = System.DateTime.Now;
                objusercircles.proceduretype = "A";
                UserCirclesDAO.AcceptFriendRequest(objusercircles);
                MySession.Current.SelectedCircleUserId = MySession.Current.MemberUserId;
                MySession.Current.CircleId = MySession.Current.MemberCircleId;
                Session["NewcircleId"] = MySession.Current.MemberCircleId; // Select Circle ID
                Session["Topselcircle"] = MySession.Current.MemberCircleId;//to display circle name at top
                MySession.Current.MemberCircleId = "";
                MySession.Current.MemberUserId = "";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "parentwindow", "parentwindow()", true);
                
              
            }
            catch (Exception ex)
            { 
                
            }
        }

        //private void test()
        //{

        //    DataTable dt = new DataTable();
        //    objusercircles.UserId = Convert.ToInt32(MySession.Current.LoginId);
        //    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);

        //    objusercircles.proceduretype = "S";
        //    dt = UserCirclesDAO.GetUserCircles(objusercircles);
        //    if (dt.Rows.Count > 0)
        //    {
        //        MySession.Current.StatusID = Convert.ToString(dt.Rows[0]["fk_request_status_id"]);
        //    }
        //    else
        //    {
               
                
        //            btnJoinPublicGroup.Visible = true;
        //            lblmsgRequestSent.Visible = false;
                
            
        //    }
        //    if (MySession.Current.StatusID == "5" || MySession.Current.StatusID == "1")
        //    {
        //        lblmsgRequestSent.Visible = true;
        //        btnJoinPublicGroup.Visible = false;
        //        btnAcceptInvitation.Visible = false;
        //    }
        //    else
        //    {
                
        //            lblmsgRequestSent.Visible = false;
        //            //btnJoinPublicGroup.Visible = false;
        //        }
             
        //    }
            //objusercircles.request_status = Convert.ToInt32(MySession.Current.StatusID);

        
        protected void btnJoinPublicGroup_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (MySession.Current.PublicPermissions == "3")
                {
                    DataTable dt = new DataTable();
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                    objusercircles.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    objusercircles.request_status = 5; // Requested to add in the circle
                    objusercircles.updated_on = System.DateTime.Now;
                    objusercircles.proceduretype = "I";
                    UserCirclesDAO.AcceptFriendRequest(objusercircles);
                    btnJoinPublicGroup.Style.Add("display", "none");

                  //  test();
                  
                    if (MySession.Current.StatusID == "5")
                    {
                        uplblMsg.Visible = true;
                        btnJoinPublicGroup.Visible = false;
                    }
                    else
                    { 
                    
                    }

                }
                else if (MySession.Current.PublicPermissions == "2")
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.PublicCircleUserId);
                    objusercircles.friend_registration_id = Convert.ToInt32(MySession.Current.LoginId);
                    objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    objusercircles.request_status = 2; //Accept Request
                    objusercircles.updated_on = System.DateTime.Now;
                    objusercircles.proceduretype = "I";
                    UserCirclesDAO.AcceptFriendRequest(objusercircles);

                    MySession.Current.SelectedCircleUserId = MySession.Current.PublicCircleUserId;
                    MySession.Current.CircleId = MySession.Current.CircleId;
                    Session["NewcircleId"] = MySession.Current.CircleId; // Select Circle ID
                    Session["Topselcircle"] = MySession.Current.CircleId;//to display circle name at top
                    MySession.Current.PublicCircleUserId = "";
                    MySession.Current.PublicCircleId = "";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
                }
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "alert('You have already joined this circle.');", true);               
            //}

            
            catch (Exception ex)
            {

            }
        }
    }
}