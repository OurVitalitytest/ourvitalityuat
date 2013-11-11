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
using ALEREIMPACT.FRAMEWORK;
using System.Data.SqlClient;

namespace ALEREIMPACT.User
{
    public partial class SearchMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Request.QueryString["val"]) == "1")
            {
                Click();
            }
            else
            {
                SerachMembers();
            }
        
        }


        private void SerachMembers()
        {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                con.Open();
                String q = Request.Params[0];
                string sql = string.Empty;
                sql = "select UP.first_name as first_name,UR.login_email as login_email,user_image,UP.fk_user_registration_id,'1' as member, 0 as circleid from tblUser_profile UP inner join tblUser_registration UR on UR.pk_user_registration_Id=UP.fk_user_registration_Id where UP.first_name like '%'+@prefixText+'%' or UR.login_email like'%'+@prefixText+'%'  and UR.fk_user_role_id in (2,3,4,5) union  select ucm.circle_name,uc.circle_image  ,uc.circle_color,uc.fk_user_registration_Id,up.first_name as circle,uc.fk_circle_id as circleid  from tblUserCirclesMaster ucm inner join tblUserCircles uc on uc.fk_circle_id=ucm.pk_circle_id left join tblUser_profile up on up.fk_user_registration_Id=uc.fk_user_registration_Id where ucm.circle_name like '%'+@prefixText+'%'  and uc.fk_circle_permission_id in(2,3)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@prefixText", q + "%");
                try
                {
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                     
                        string username = dr.GetValue(0).ToString();
                        string email = dr.GetValue(1).ToString();
                        string image = dr.GetValue(2).ToString();
                        string userid = dr.GetValue(3).ToString();
                        string member = dr.GetValue(4).ToString();
                        string circleid = dr.GetValue(5).ToString();
                        if (member == "1")
                        {
                          //  Response.Write("<asp:Label ID='Label1' runat='server'>" + userid + "</asp:Label>" + "<div  class='display_box' align='left' ><img src='profile_image/" + image + "' style='width:50px; height:50px; float:left; margin-right:13px;' /><span class='name'>" + username + "</span></div>");
                            Response.Write("<div  class='display_box' align='left' ><label visible='false' style='display:none;'>" + userid + "</label><input  type='hidden' value='0'/>" + "<img src='profile_image/" + image + "' style='width:50px; height:50px; float:left; margin-right:13px;' /><span class='name'>" + username + "</span></div>");
                        }
                        else
                        {
                          //  Response.Write("<asp:Label ID='Label1' runat='server'>" + userid + "</asp:Label>" + "<div class='display_box' align='left'><div  class='topthumb' style='border:3px solid #" + image + " !important;'><img src='CircleImages/" + email + "' style='width:45px; height:45px; float:left;  background-color: #DDDDDD; border: 2px solid white !important; border-radius: 120px 120px 120px 120px;  display: block;' /></div>" + "<span class='name_search'>" + username + "</span></div>");
                            Response.Write("<div class='display_box' align='left'><label visible='false' style='display:none;'>" + userid + "</label><input  type='hidden' value='" + circleid + "'/><div  class='topthumb' style='border:3px solid #" + image + " !important;'><img src='CircleImages/" + email + "' style='width:45px; height:45px; float:left;  background-color: #DDDDDD; border: 2px solid white !important; border-radius: 120px 120px 120px 120px;  display: block;' /></div>" + "<span class='name_search'>" + username + "</span></div>");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                con.Close();
            }

        private void Click()
        {
            //MySession.Current.searchfriendId = hdnId.Value;
            //MySession.Current.PublicCircleId = "";
            //MySession.Current.PublicCircleUserId = "";
            //MasterPage mstr = this.Parent.Page.Master as MasterPage;
            //((LoginUserMaster)this.Page.Master).SearchMembers();
        }
     
        }
    
}
