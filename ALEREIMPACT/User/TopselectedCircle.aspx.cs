using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.Circles;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.DAO.Circles;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.DAL.User;

namespace ALEREIMPACT.User
{
    public partial class TopselectedCircle : System.Web.UI.Page
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        RegisterUserBAO objRegisterUserBAO = new RegisterUserBAO();
        UserCommentsBAL objUserCommentsBal = new UserCommentsBAL();
        SQLHelper objhelper = new SQLHelper();
        public static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Page.Header.DataBind();
                //countMessage();
                GetCircleName();
               
                lbcirclename.Text = MySession.Current.SelectedCircleName;
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void GetCircleName()
        {

            if (Convert.ToString(Request.QueryString["uid"]) == null || Convert.ToString(Request.QueryString["uid"]) == "")
            {

                if (Convert.ToString(Session["Topselcircle"]) == "" || Convert.ToString(Session["Topselcircle"]) == null)
                {
                    MySession.Current.SelectedCircleUserId = MySession.Current.LoginId;
                    string cid = MySession.Current.CircleId;
                }
                // MySession.Current.CircleId = "1";
            }
            else
            {
                int userid = Convert.ToInt32(Request.QueryString["uid"].ToString());
                int circleid = Convert.ToInt32(Request.QueryString["cid"].ToString());
                string circlename = Convert.ToString(Request.QueryString["cnam"]);
                MySession.Current.SelectedCircleUserId = Convert.ToInt32(userid).ToString();
                MySession.Current.CircleId = Convert.ToInt32(circleid).ToString();
                MySession.Current.SelectedCircleName = circlename;

            }

            try
            {
                DataTable dtcirclename = new DataTable();
                if (MySession.Current.MemberUserId == null || MySession.Current.MemberUserId == "")
                {
                    count = 0;
                    if (MySession.Current.SelectedCircleUserId == null || MySession.Current.SelectedCircleUserId == "")
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.LoginId);
                    }
                    else
                    {
                        objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                    }


                    if (MySession.Current.CircleId == null || MySession.Current.CircleId == "")
                    {
                        objusercircles.fk_circle_id = 1;
                    }
                    else
                    {
                        objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    }
                }
                else
                {
                    objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.MemberUserId);
                    if (count == 0)
                    {
                        objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.MemberCircleId);
                        count = 1;
                    }
                    else
                    {
                        objusercircles.fk_circle_id = Convert.ToInt32(MySession.Current.CircleId);
                    }
                }
                objusercircles.proceduretype = "CN";
                dtcirclename = UserCirclesDAO.GetCircleName(objusercircles);
                if (dtcirclename.Rows.Count > 0)
                {

                    lbcirclename.Text = dtcirclename.Rows[0]["circleName"].ToString();
                    MySession.Current.SelectedCircleName = lbcirclename.Text;
                    lbcirclename.Style.Add("color", "#" + dtcirclename.Rows[0]["circlecolor"].ToString());
                    if (dtcirclename.Rows[0]["circleimage"].ToString() == "" || dtcirclename.Rows[0]["circleimage"].ToString() == null)
                    {
                        imgtopcircle.ImageUrl = "CircleImages/DefaultInnerCircle.jpg";
                    }
                    else
                    {
                        imgtopcircle.ImageUrl = "CircleImages/" + dtcirclename.Rows[0]["circleimage"].ToString();
                    }
                    dvtopimagecircle.Style.Add("border-color", "#" + dtcirclename.Rows[0]["circlecolor"].ToString());
                }

            }
            catch (Exception ex)
            { ex.ToString(); }
        }
        //public HtmlControl iframe
        //{
        //    get
        //    {
        //        return this.iframeProfile;
        //    }
        //}
        //private void countMessage()
        //{
        //    DataTable dtMessage = new DataTable();
        //    objUserCommentsBal.ID = Convert.ToInt32(MySession.Current.LoginId);
        //    objUserCommentsBal.ProcedureType = "UN9";
        //    dtMessage = UserCommentsDAL.GetGlobalUnreadMessageCount(objUserCommentsBal);
        //    if (dtMessage.Rows.Count > 0)
        //    {
        //        DVAdminMessage.Style.Add("display", "block");
        //    }
        //    else
        //    {
        //        DVAdminMessage.Style.Add("display", "none");
        //    }
        //}

        //protected void lnkClick_Click(object sender, EventArgs e)
        //{
        //    DVAdminMessage.Style.Add("display", "none");
        //  //  Response.Redirect("~/User/AdminMessagesFront.aspx", false);
        //  //  MasterPage mstr = this.Parent.Page.Master as MasterPage;
        //  ((LoginUserMaster)this.Page.Master).MessagesShow();
        // //  this.iframeProfile.Attributes["src"] = "AdminMessagesFront.aspx";

        //}

        //protected void ImgBtnClose_Click(object sender, ImageClickEventArgs e)
        //{
        //    DVAdminMessage.Style.Add("display", "none");
        //}
    }
}
