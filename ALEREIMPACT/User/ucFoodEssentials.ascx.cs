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
using System.Xml;
using System.Net;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.User
{
    public partial class ucFoodEssentials : System.Web.UI.UserControl
    {
        public static string upc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MySession.Current.LoginId))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Redirect", "window.parent.location='../Login.aspx';", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            lbSearch.Text = txtSearch.Text;
            var nodeCount = 0;
            divFESearch.Style.Add("display", "");
            GridView1.Visible = true;
            string url = "http://api.foodessentials.com/searchprods?q=" + txtSearch.Text + "&sid=825655af-789e-482f-9ae1-2ce4f867a466&n=50&s=0&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element &&
                    reader.Name == "e")
                {
                    nodeCount++;
                }
            }
            XmlTextReader xmlRead;
            WebRequest wrq;
            wrq = WebRequest.Create(url);
            wrq.Proxy = WebProxy.GetDefaultProxy();
            wrq.Proxy.Credentials = CredentialCache.DefaultCredentials;
            xmlRead = new XmlTextReader(wrq.GetResponse().GetResponseStream());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlRead);

            if (ds.Tables.Count > 0)
            {

                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable("Company");
                DataRow dr;
                DataColumn dc;
                dt.Columns.Add(new DataColumn("UPC", typeof(string)));
                dt.Columns.Add(new DataColumn("Brand", typeof(string)));
                dt.Columns.Add(new DataColumn("Manafacturer", typeof(string)));
                dt.Columns.Add(new DataColumn("Product_Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Product_Size", typeof(string)));
                for (int i = 0; i < nodeCount; i++)
                {

                    dr = dt.NewRow();
                    dr[0] = ds.Tables[9].Rows[i][1];
                    dr[1] = ds.Tables[3].Rows[i][1];
                    dr[2] = ds.Tables[5].Rows[i][1];
                    dr[3] = ds.Tables[7].Rows[i][1];
                    dr[4] = ds.Tables[8].Rows[i][1];
                    dt.Rows.Add(dr);

                }
                ds1.Tables.Add(dt);
                GridView1.DataSource = ds1;
                GridView1.DataBind();

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ClsGeneric.ReplaceCookie();

            if (e.CommandName == "lnkView")
            {
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(',');
                Session["upc"] = arg[0];
                Session["name"] = arg[1];
                 upc = arg[0];
                 string name = arg[1];
                 Label1.Text = name;
                 this.ModalPopupExtender1.Show();
                 PanleFE.Visible = true;
                 bindNutrients();
                 bindAdditive();
                 bindAllergen();
            }
        }
        private void bindAdditive()
        {
            var nodeCount = 0;
            string url = "http://api.foodessentials.com/label?u=" + upc + "&sessid=825655af-789e-482f-9ae1-2ce4f867a466&appid=mv4eez56p3g38cy4mukkqfxd&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element &&
               reader.Name == "additive_name")
                {
                    nodeCount++;
                }
            }

            XmlTextReader xmlRead;
            WebRequest wrq;
            wrq = WebRequest.Create(url);
            wrq.Proxy = WebProxy.GetDefaultProxy();
            wrq.Proxy.Credentials = CredentialCache.DefaultCredentials;
            xmlRead = new XmlTextReader(wrq.GetResponse().GetResponseStream());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlRead);

            if (ds.Tables.Count > 0)
            {

                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable("Company");
                DataRow dr;
                DataColumn dc;
                dt.Columns.Add(new DataColumn("additive_name", typeof(string)));
                dt.Columns.Add(new DataColumn("Additive_Red_Ingredients", typeof(string)));
                dt.Columns.Add(new DataColumn("Additive_Value", typeof(string)));
                dt.Columns.Add(new DataColumn("Additive_Yellow_Ingredients", typeof(string)));

                int count = 0;
                for (int i = 0; i < nodeCount; i++)
                {

                    dr = dt.NewRow();
                    dr[0] = ds.Tables[2].Rows[i][1];
                    dr[1] = ds.Tables[3].Rows[i][1];
                    dr[2] = ds.Tables[4].Rows[i][1];
                    dr[3] = ds.Tables[5].Rows[i][1];

                    dt.Rows.Add(dr);

                }
                ds1.Tables.Add(dt);
                GrdAdditives.DataSource = ds1;
                GrdAdditives.DataBind();

            }
        }

        private void bindAllergen()
        {
            var nodeCount = 0;
            string url = "http://api.foodessentials.com/label?u=" + upc + "&sessid=825655af-789e-482f-9ae1-2ce4f867a466&appid=mv4eez56p3g38cy4mukkqfxd&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element &&
               reader.Name == "allergen_name")
                {
                    nodeCount++;
                }
            }

            XmlTextReader xmlRead;
            WebRequest wrq;
            wrq = WebRequest.Create(url);
            wrq.Proxy = WebProxy.GetDefaultProxy();
            wrq.Proxy.Credentials = CredentialCache.DefaultCredentials;
            xmlRead = new XmlTextReader(wrq.GetResponse().GetResponseStream());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlRead);

            if (ds.Tables.Count > 0)
            {

                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable("Company");
                DataRow dr;
                DataColumn dc;
                dt.Columns.Add(new DataColumn("allergen_name", typeof(string)));
                dt.Columns.Add(new DataColumn("allergen_red_ingredients", typeof(string)));
                dt.Columns.Add(new DataColumn("allergen_value", typeof(string)));
                dt.Columns.Add(new DataColumn("allergen_yellow_ingredients", typeof(string)));

                int count = 0;
                for (int i = 0; i < nodeCount; i++)
                {

                    dr = dt.NewRow();
                    dr[0] = ds.Tables[2].Rows[i][1];
                    dr[1] = ds.Tables[3].Rows[i][1];
                    dr[2] = ds.Tables[4].Rows[i][1];
                    dr[3] = ds.Tables[5].Rows[i][1];

                    dt.Rows.Add(dr);

                }
                ds1.Tables.Add(dt);
                GrdAllergens.DataSource = ds1;
                GrdAllergens.DataBind();

            }
        }

        private void bindNutrients()
        {
            var nodeCount = 0;
            string url = "http://api.foodessentials.com/productscore?u="+upc+"&sid=825655af-789e-482f-9ae1-2ce4f867a466&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
            XmlTextReader reader = new XmlTextReader(url);
            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element &&
               reader.Name == "e")
                {
                    nodeCount++;
                }
            }

            XmlTextReader xmlRead;
            WebRequest wrq;
            wrq = WebRequest.Create(url);
            wrq.Proxy = WebProxy.GetDefaultProxy();
            wrq.Proxy.Credentials = CredentialCache.DefaultCredentials;
            xmlRead = new XmlTextReader(wrq.GetResponse().GetResponseStream());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlRead);

            if (ds.Tables.Count > 0)
            {

                DataSet ds1 = new DataSet();
                DataTable dt = new DataTable("Company");
                DataRow dr;
                DataColumn dc;
                //dt.Columns.Add(new DataColumn("nutrient_fe_level", typeof(string)));
                dt.Columns.Add(new DataColumn("nutrient_name", typeof(string)));
                dt.Columns.Add(new DataColumn("nutrient_uom", typeof(string)));
                dt.Columns.Add(new DataColumn("nutrient_value", typeof(string)));

                int count = 0;
                for (int i = 0; i < nodeCount; i++)
                {

                    dr = dt.NewRow();
                    dr[0] = ds.Tables[8].Rows[i][1];
                    dr[1] = ds.Tables[9].Rows[i][1];
                    dr[2] = ds.Tables[10].Rows[i][1];
                    // dr[3] = ds.Tables[10].Rows[i][1];

                    dt.Rows.Add(dr);

                }
                ds1.Tables.Add(dt);
                GrdNutrients.DataSource = ds1;
                GrdNutrients.DataBind();
            }
        }

       
    }

}