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

namespace ALEREIMPACT.User
{
    public partial class ucCircleList : System.Web.UI.UserControl
    {
        UserCirclesBAO objusercircles = new UserCirclesBAO();
        SQLHelper objhelper = new SQLHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetCircleList();
                }
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
                DataTable dtpendingreq = new DataTable();
                // grdPendingRequests.DataSource = dtpendingreq;
                // grdPendingRequests.DataBind();
                objusercircles.fk_user_registration_Id = Convert.ToInt32(MySession.Current.SelectedCircleUserId);
                objusercircles.fk_circle_id = MySession.Current.CircleId;
                objusercircles.proceduretype = "C";
                dtpendingreq = UserCirclesDAO.GetFriendList(objusercircles);
                if (dtpendingreq.Rows.Count > 0)
                {
                    if (dtpendingreq.Rows.Count >= 4)
                    {
                        dlcirclelist.RepeatColumns = 4;
                    }
                    else
                    {
                        dlcirclelist.RepeatColumns = dtpendingreq.Rows.Count;
                    }


                    dlcirclelist.DataSource = dtpendingreq;
                    dlcirclelist.DataBind();

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void dlcirclelist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                HtmlGenericControl dvcircleimage = (HtmlGenericControl)e.Item.FindControl("dvcircleimage");
                HiddenField hndcolor = (HiddenField)e.Item.FindControl("hndcolor");
                dvcircleimage.Style.Add("border-color", "#" + hndcolor.Value);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}