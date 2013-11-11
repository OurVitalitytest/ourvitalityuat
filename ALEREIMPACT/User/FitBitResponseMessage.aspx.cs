using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALEREIMPACT.User
{
    public partial class FitBitResponseMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["Msg"]) == "Connected")
                {
                    lblMsgDisconnected.Visible = false;
                    lblMsgSuccess.Visible = true;
                }
                else
                {
                    if (Convert.ToString(Request.QueryString["Msg"]) == "Disconnected")
                    {
                        lblMsgDisconnected.Visible = true;
                        lblMsgSuccess.Visible = false;
                    }
                }
            }
        }
    }
}
