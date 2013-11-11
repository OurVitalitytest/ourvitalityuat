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
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ALEREIMPACT.User
{
    public partial class ucAllCircles : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();

        public static Int32 userid = 0;
        public static Int32 circleid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetCircleList();
                }
                MySession.Current.PublicCircleId = "";
                MySession.Current.PublicCircleUserId = "";
                Session["selectedcircleid"] = null;
                this.txtSearch.Attributes.Add("onkeypress", "ShowImage()");
                this.txtSearch.Attributes.Add("onblur", "HideImage()");
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GetCircleList()
        {
            try
            {
               
                DataTable dtcircles = new DataTable();
                if (Convert.ToString(Session["CircleView"]) == "True")
                {
                    objusercircles.ID = Convert.ToInt32(MySession.Current.PublicCircleId);
                    objusercircles.proceduretype = "GC1";
                    dtcircles = UserCirclesDAO.GetUserNameEmail(objusercircles);
                }

                else if (Session["seachByCircel"] != null)
                {
                    string sql = string.Empty;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    con.Open();
                    sql = "select UCM.pk_circle_id,UCM.circle_name,UC.circle_image,UC.circle_color,(up.first_name) as name,UC.fk_user_registration_Id,(select COUNT(pk_user_friend_id)+1 from tblUserFriendList ufl where ufl.fk_user_registration_Id=UC.fk_user_registration_Id and ufl.fk_circle_id=UCM.pk_circle_id and ufl.fk_request_status_id=2) as members ,(select COUNT(Pk_mission_id) from tblmission mi where mi.fk_created_by_user_Id=UC.fk_user_registration_Id and mi.fk_circle_Id=UCM.pk_circle_id) as missions,    (select COUNT(pk_Inspirator_id) from tblInspirators ip where ip.fk_user_registration_Id=UC.fk_user_registration_Id and ip.fk_circle_id=UCM.pk_circle_id) as Inspirators  from tblUserCirclesMaster UCM inner join 	tblUserCircles UC on UC.fk_circle_id=UCM.pk_circle_id left join tblUser_profile up on up.fk_user_registration_Id=UC.fk_user_registration_Id	where UCM.circle_name like '" + MySession.Current.SearchNAme + "%'" + " and ( UC.fk_circle_permission_id=2 or UC.fk_circle_permission_id=3 )	order by pk_circle_id desc";
                    Session.Remove("seachByCircel");
                    SqlDataAdapter adp = new SqlDataAdapter(sql, con);
                    adp.Fill(dtcircles);
                
                }
                else
                {
                    objusercircles.proceduretype = "S";
                    dtcircles = UserCirclesDAO.GetCircleList(objusercircles);
                }
                if (dtcircles.Rows.Count > 0)
                {
                    dlcirclelist.DataSource = dtcircles;
                    dlcirclelist.DataBind();
                }
                else
                {
                    lbNorecord.Visible = true;
                    lbNorecord.Text = "No Circles Found..";
                }
                Session["CircleView"] = false;
            }
            catch (Exception ex)
            {

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
                   // ImageButton ImageButton1 = (ImageButton)e.Item.FindControl("ImageButton1");

                HtmlGenericControl divHoverColor = (HtmlGenericControl)e.Item.FindControl("divHoverColor");
                divCircle.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                   // divCircle.Style.Add("  border", " 3px solid #" + hdnColor.Value + " !important");
                  divHoverColor.Style.Add("background", "none repeat scroll 0 0 #" + hdnColor.Value + " !important");
                    //if (hdnImage.Value == "" || hdnImage.Value == null)
                    //{
                    //    ImageButton1.ImageUrl = "~/User/CircleImages/DefaultInnerCircle.jpg";
                    //}
                    //else
                    //{
                    //    ImageButton1.ImageUrl = "~/User/CircleImages/" + hdnImage.Value;
                    //}
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void dlcirclelist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                if (e.CommandName == "lnkView")
                {
                    string[] arg = new string[3];
                    arg = e.CommandArgument.ToString().Split(';');
                    string userID = arg[0];
                    string CircleiD = arg[1];
                    string circlename = arg[2];
                    userid = Convert.ToInt32(userID);
                    circleid = Convert.ToInt32(CircleiD);
                  
                    if (userID == MySession.Current.LoginId)
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
                    Response.Redirect("~/User/MyProfile.aspx", false);
                    //Session["selectedcircleid"] = MySession.Current.PublicCircleUserId + "-" + MySession.Current.PublicCircleId;
                    //Session["Topselcircle"] = MySession.Current.PublicCircleId;
                    //Session["Circle"] = true;
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void btnCircleSearch_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                MySession.Current.searchfriendId = "";
                string userid = hdnUserid.Value;
                string circleid = hdnCircleid.Value;
                MySession.Current.PublicCircleId = circleid;
                MySession.Current.PublicCircleUserId = userid;
                Session["CircleView"] = true;
                GetCircleList();
                // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "parentwindow1", "parentwindow1();", true);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}