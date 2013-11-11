using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALEREIMPACT.FRAMEWORK;

namespace CAMPP
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                //if (string.IsNullOrEmpty(Request.Cookies["AuthToken"].Value))
                //{
                //    ClsGeneric.Clear_Session2();
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
