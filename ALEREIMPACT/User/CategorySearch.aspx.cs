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
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.DAO.User;
using ALEREIMPACT.FRAMEWORK;
using System.Xml;
using System.Net;
using System.Data.SqlClient;

namespace ALEREIMPACT.User
{
    public partial class CategorySearch : System.Web.UI.Page
    {
        SQLHelper objSqlHelper = new SQLHelper();
        UserFoodLogBAO objUserFoodLog = new UserFoodLogBAO();
        public static string Search = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDrpDown();
                BindCAt();
            }

        }

        private void BindCAt()
        {
            DataTable dt = new DataTable();
            objUserFoodLog.ProcedureType = "FC";
            dt = UserFoodLogDAO.GetFoodCategories(objUserFoodLog);
            dMajor.DataSource = dt;
            dMajor.DataBind();
        }

        protected void dMajor_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater dMajorSubcat = (Repeater)e.Item.FindControl("dMajorSubcat");
                LinkButton lnkPsubcat = (LinkButton)e.Item.FindControl("lnkPsubcat");
                Label lbid = (Label)e.Item.FindControl("lbid");
                //  Label lbPsubcatid = (Label)e.Item.FindControl("lbPsubcatid");
                //  Label lbsubcatid = (Label)e.Item.FindControl("lbsubcatid");
                //  LinkButton lnkSubcat = (LinkButton)e.Item.FindControl("lnkSubcat");
                // HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("a1");
                DataTable dtPsubcat = new DataTable();
                objUserFoodLog.ID = Convert.ToInt32(lbid.Text);
                objUserFoodLog.ProcedureType = "FS";
                dtPsubcat = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
                dMajorSubcat.DataSource = dtPsubcat;
                dMajorSubcat.DataBind();
               
            }
        }
        protected void dMajorSubcat_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbPsubcatid = (Label)e.Item.FindControl("lbPsubcatid");
                Repeater dSubcat = (Repeater)e.Item.FindControl("dSubcat");
                DataTable dtsubcat = new DataTable();
                objUserFoodLog.ID = Convert.ToInt32(lbPsubcatid.Text);
                objUserFoodLog.ProcedureType = "FC";
                dtsubcat = UserFoodLogDAO.GetFoodSubCategories(objUserFoodLog);
                dSubcat.DataSource = dtsubcat;
                dSubcat.DataBind();
            }
        }
        private void FillDrpDown()
        {
            objSqlHelper.fillDrpControl(DrpCategory, "spFillDrpDown", "CAT_NAME", "CAT_ID", "FC");
            objSqlHelper.fillDrpControl(DrpParentSubcat, "spFillDrpDown", "SUBCAT1_NAME", "SUBCAT1_ID", "FS");
            objSqlHelper.fillDrpControl(DrpSubcat, "spFillDrpDown", "SUBCAT2_NAME", "SUBCAT2_ID", "FP");
        }

        protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            DrpParentSubcat.Items.Clear();
            DrpParentSubcat.Items.Add("Select");
            if (DrpCategory.SelectedValue != "0")
            {
                string id = DrpCategory.SelectedValue;
                objSqlHelper.fillDrpControlwithid(DrpParentSubcat, "spFilterSearch", "SUBCAT1_NAME", "SUBCAT1_ID", id, "FD");
            }
            else 
            {
                objSqlHelper.fillDrpControl(DrpParentSubcat, "spFillDrpDown", "SUBCAT1_NAME", "SUBCAT1_ID", "FS");

            }

           

        }

        protected void DrpParentSubcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            DrpSubcat.Items.Clear();
            DrpSubcat.Items.Add("Select");
            if (DrpParentSubcat.SelectedValue != "0")
            {
                string id = DrpParentSubcat.SelectedValue;
                objSqlHelper.fillDrpControlwithid(DrpSubcat, "spFilterSearch", "SUBCAT2_NAME", "SUBCAT2_ID", id, "FD1");
            }
            else
            {
                objSqlHelper.fillDrpControl(DrpSubcat, "spFillDrpDown", "SUBCAT2_NAME", "SUBCAT2_ID", "FP");

            }

        }

        private void getSearchanme()
        {
            if (DrpSubcat.SelectedIndex == 0 && DrpParentSubcat.SelectedIndex == 0 &&  DrpCategory.SelectedIndex!=0)
            {
                Search = DrpCategory.SelectedItem.ToString();
                Search = Search.Replace(",", " ");
            }
            else if (DrpSubcat.SelectedIndex == 0 && DrpParentSubcat.SelectedIndex != 0 && DrpCategory.SelectedIndex != 0)
            {
                Search = DrpParentSubcat.SelectedItem.ToString();
                Search = Search.Replace(",", " ");
            }
            else if (DrpSubcat.SelectedIndex != 0 && DrpParentSubcat.SelectedIndex != 0 && DrpCategory.SelectedIndex != 0)
            {
                Search = DrpSubcat.SelectedItem.ToString();
                Search = Search.Replace(",", " ");
            }
            else if (DrpSubcat.SelectedIndex != 0 && DrpParentSubcat.SelectedIndex == 0 && DrpCategory.SelectedIndex == 0)
            {
                Search = DrpSubcat.SelectedItem.ToString();
                Search = Search.Replace(",", " ");
            }
            else if (DrpSubcat.SelectedIndex == 0 && DrpParentSubcat.SelectedIndex != 0 && DrpCategory.SelectedIndex == 0)
            {
                Search = DrpParentSubcat.SelectedItem.ToString();
                Search = Search.Replace(",", " ");
            }
            else if (DrpSubcat.SelectedIndex != 0 && DrpParentSubcat.SelectedIndex == 0 && DrpCategory.SelectedIndex != 0)
            {
                Search = DrpSubcat.SelectedItem.ToString();
                Search = Search.Replace(",", " ");
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            if (DrpCategory.SelectedIndex != 0 || DrpParentSubcat.SelectedIndex != 0 || DrpSubcat.SelectedIndex != 0)
            {
                getSearchanme();
                var nodeCount = 0;
                GridView1.Visible = true;
                string url = "http://api.foodessentials.com/searchprods?q=" + Search + "&sid=825655af-789e-482f-9ae1-2ce4f867a466&n=10&s=0&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
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
                    DataTable dt1 = new DataTable("Company1");
                    DataSet ds1 = new DataSet();
                    DataTable dt = new DataTable("Company");
                    DataRow dr;
                    DataColumn dc;
                    dt.Columns.Add(new DataColumn("UPC", typeof(string)));
                    dt.Columns.Add(new DataColumn("Brand", typeof(string)));
                    dt.Columns.Add(new DataColumn("Product_Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Product_Size", typeof(string)));
                    dt.Columns.Add(new DataColumn("cal_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("cal_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("cholestrol_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("cholestrol_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("Fiber_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("Fiber_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("Proteins_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("Proteins_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("Sodium_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("Sodium_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("Sugar_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("Sugar_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("Carbohydrates_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("Carbohydrates_value", typeof(string)));
                    dt.Columns.Add(new DataColumn("Fat_unit", typeof(string)));
                    dt.Columns.Add(new DataColumn("Fat_value", typeof(string)));
                    for (int i = 0; i < nodeCount; i++)
                    {

                        dr = dt.NewRow();
                        dr[0] = ds.Tables[9].Rows[i][1];
                        dr[1] = ds.Tables[3].Rows[i][1];
                        dr[2] = ds.Tables[7].Rows[i][1];
                        dr[3] = ds.Tables[8].Rows[i][1];



                        var nodeCount1 = 0;
                        string url1 = "http://api.foodessentials.com/productscore?u=" + ds.Tables[9].Rows[i][1].ToString() + "&sid=825655af-789e-482f-9ae1-2ce4f867a466&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
                        XmlTextReader reader1 = new XmlTextReader(url1);
                        while (reader1.Read())
                        {

                            if (reader1.NodeType == XmlNodeType.Element &&
                           reader1.Name == "e")
                            {
                                nodeCount1++;
                            }
                        }

                        XmlTextReader xmlRead1;
                        WebRequest wrq1;
                        wrq = WebRequest.Create(url1);
                        wrq.Proxy = WebProxy.GetDefaultProxy();
                        wrq.Proxy.Credentials = CredentialCache.DefaultCredentials;
                        xmlRead1 = new XmlTextReader(wrq.GetResponse().GetResponseStream());
                        DataSet ds2 = new DataSet();
                        ds2.ReadXml(xmlRead1);

                        if (ds2.Tables.Count > 0)
                        {

                            DataSet ds3 = new DataSet();
                            dr[4] = ds2.Tables[9].Rows[0][1];
                            dr[5] = ds2.Tables[10].Rows[0][1];
                            dr[6] = ds2.Tables[9].Rows[1][1];
                            dr[7] = ds2.Tables[10].Rows[1][1];
                            dr[8] = ds2.Tables[9].Rows[2][1];
                            dr[9] = ds2.Tables[10].Rows[2][1];
                            dr[10] = ds2.Tables[9].Rows[3][1];
                            dr[11] = ds2.Tables[10].Rows[3][1];
                            dr[12] = ds2.Tables[9].Rows[4][1];
                            dr[13] = ds2.Tables[10].Rows[4][1];
                            dr[14] = ds2.Tables[9].Rows[5][1];
                            dr[15] = ds2.Tables[10].Rows[5][1];
                            dr[16] = ds2.Tables[9].Rows[6][1];
                            dr[17] = ds2.Tables[10].Rows[6][1]; 
                            dr[18] = ds2.Tables[9].Rows[7][1];
                            dr[19] = ds2.Tables[10].Rows[7][1];
                            dt.Rows.Add(dr);
                        }
                    }
                    ds1.Tables.Add(dt);
                    GridView1.DataSource = ds1;
                    GridView1.DataBind();

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Info", "alert('Please select atleast one option');", true);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbCal = (Label)e.Row.FindControl("lbCal");
                Label lbfat = (Label)e.Row.FindControl("lbfat");
                Label lbchol = (Label)e.Row.FindControl("lbchol");
                Label lbsodium = (Label)e.Row.FindControl("lbsodium");
                Label lbcarbs = (Label)e.Row.FindControl("lbcarbs");
                Label lbfiber = (Label)e.Row.FindControl("lbfiber");
                Label lbprot = (Label)e.Row.FindControl("lbprot");
                Label lbsugar = (Label)e.Row.FindControl("lbsugar");
                if (lbCal.Text == "")
                {
                    lbCal.Text = "0.0";
                }
                if (lbfat.Text == "")
                {
                    lbfat.Text = "0.0";
                }
                if (lbchol.Text == "")
                {
                    lbchol.Text = "0.0";
                }
                if (lbsodium.Text == "")
                {
                    lbsodium.Text = "0.0";
                }
                if (lbcarbs.Text == "")
                {
                    lbcarbs.Text = "0.0";
                }
                if (lbfiber.Text == "")
                {
                    lbfiber.Text = "0.0";
                }
                if (lbprot.Text == "")
                {
                    lbprot.Text = "0.0";
                }
                if (lbsugar.Text == "")
                {
                    lbsugar.Text = "0.0";
                }
            }
        }

   
    }
}
