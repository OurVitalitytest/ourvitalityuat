using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using System.Data;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.DAO.Circles;
using ALEREIMPACT.BAO.Circles;
using System.Web.UI.HtmlControls;
using ALEREIMPACT.alereimpactservice;
using ALEREIMPACT.Service;
using System.Web.Services;
using ALEREIMPACT.BAL.User;
using ASPSnippets.FaceBookAPI;
using ALEREIMPACT.BAO.Facebook;
using System.Web.Script.Serialization;
using System.Configuration;
using System.IO;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO;
using ALEREIMPACT.BAO;

namespace ALEREIMPACT
{
    public partial class privacyandpolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImgRedirectTo_Click(object sender, ImageClickEventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {

                Response.Redirect("login.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkTermsnConditions_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/termsandconditions.aspx", false);
        }

        protected void lnkprivacynPolicy_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/privacyandpolicy.aspx", false);
        }

        protected void lnkSupport_Click(object sender, EventArgs e)
        {
            Session["DirectUser"] = true;
            Response.Redirect("/support.aspx", false);
        }
    }
}
