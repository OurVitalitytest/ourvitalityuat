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
using System.Xml;
using System.Net;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.BAO.User;
using ALEREIMPACT.DAL.User;
using ALEREIMPACT.DAO.User;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace ALEREIMPACT.User
{
    public partial class APISearch : System.Web.UI.Page
    {
        SQLHelper objSqlHelper = new SQLHelper();
        UserFoodLogBAO objUserFoodLogBAO = new UserFoodLogBAO();
        RegisterUserBAO objUserRegisterBAO = new RegisterUserBAO();
        protected static int chartPoints = 0;
        public static Int32 cal, fat, chol, sodium, fiber, prot, sugar, carbs = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                objSqlHelper.fillDrpControl(DrpQuanityUnit, "spFillDrpDown", "SR_NAME", "SR_ID", "SM");

                dvSearch.Style.Add("display", "none");
                // txtCalender.Attributes.Add("OnChange", "javascript:return DoPostBack()");
               
            }
            if (hdfromdate.Value != "")
            {
                txtCalender.Text = hdfromdate.Value;
            }

            BindFoodLog();
            Chart2.Series[0].PostBackValue = "#INDEX";
            BindTotal();
            piechartbind();
            chartPoints = Chart2.Series["Series1"].Points.Count;

            //txtSearch.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
            //bindDrp();
        }
        //private void bindDrp()
        //{
        //    DrpTime.Items.Clear();
        //    objSqlHelper.fillDrpControl(DrpTime, "spFillDrpDown", "ET_NAME", "ET_ID", "EM");

        //}

        private void BindFoodLog()
        {
            DataTable dt = new DataTable();
            objUserFoodLogBAO.fk_user_registration_Id = 146;
            if (hdfromdate.Value == "")
            {
                objUserFoodLogBAO.UFL_DATE = Convert.ToString(DateTime.Now.Date);
            }
            else
            {
                objUserFoodLogBAO.UFL_DATE = Convert.ToString(hdfromdate.Value);
            }
            objUserFoodLogBAO.ProcedureType = "V";
            dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLogBAO);
            if (dt.Rows.Count > 0)
            {
                GridView2.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.Visible = false;
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            dvSearch.Style.Add("display", "");
            var nodeCount = 0;
            GridView1.Visible = true;
            string url = "http://api.foodessentials.com/searchprods?q=" + textSearch.Text + "&sid=825655af-789e-482f-9ae1-2ce4f867a466&n=10&s=0&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
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
                //dt.Columns.Add(new DataColumn("cal", typeof(string)));
                dt.Columns.Add(new DataColumn("cal_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("cal_value", typeof(string)));
                // dt.Columns.Add(new DataColumn("cholestrol", typeof(string)));
                dt.Columns.Add(new DataColumn("cholestrol_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("cholestrol_value", typeof(string)));

                // dt.Columns.Add(new DataColumn("Fiber", typeof(string)));
                dt.Columns.Add(new DataColumn("Fiber_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("Fiber_value", typeof(string)));
                //  dt.Columns.Add(new DataColumn("Proteins", typeof(string)));
                dt.Columns.Add(new DataColumn("Proteins_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("Proteins_value", typeof(string)));
                //   dt.Columns.Add(new DataColumn("Sodium", typeof(string)));
                dt.Columns.Add(new DataColumn("Sodium_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("Sodium_value", typeof(string)));
                //   dt.Columns.Add(new DataColumn("Sugar", typeof(string)));
                dt.Columns.Add(new DataColumn("Sugar_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("Sugar_value", typeof(string)));
                //   dt.Columns.Add(new DataColumn("Carbohydrates", typeof(string)));
                dt.Columns.Add(new DataColumn("Carbohydrates_unit", typeof(string)));
                dt.Columns.Add(new DataColumn("Carbohydrates_value", typeof(string)));
                //   dt.Columns.Add(new DataColumn("Fat", typeof(string)));
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


                        // dr = dt.NewRow();
                        //  dr[4] = ds2.Tables[8].Rows[0][1];
                        dr[4] = ds2.Tables[9].Rows[0][1];
                        dr[5] = ds2.Tables[10].Rows[0][1];
                        //  dr[7] = ds2.Tables[8].Rows[1][1];
                        dr[6] = ds2.Tables[9].Rows[1][1];
                        dr[7] = ds2.Tables[10].Rows[1][1];
                        //  dr[10] = ds2.Tables[8].Rows[2][1];
                        dr[8] = ds2.Tables[9].Rows[2][1];
                        dr[9] = ds2.Tables[10].Rows[2][1];
                        // dr[13] = ds2.Tables[8].Rows[3][1];
                        dr[10] = ds2.Tables[9].Rows[3][1];
                        dr[11] = ds2.Tables[10].Rows[3][1];
                        //  dr[16] = ds2.Tables[8].Rows[4][1];
                        dr[12] = ds2.Tables[9].Rows[4][1];
                        dr[13] = ds2.Tables[10].Rows[4][1];
                        //  dr[19] = ds2.Tables[8].Rows[5][1];
                        dr[14] = ds2.Tables[9].Rows[5][1];
                        dr[15] = ds2.Tables[10].Rows[5][1];
                        // dr[22] = ds2.Tables[8].Rows[6][1];
                        dr[16] = ds2.Tables[9].Rows[6][1];
                        dr[17] = ds2.Tables[10].Rows[6][1];
                        // dr[25] = ds2.Tables[8].Rows[7][1];
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkAdd")
            {
                string[] arg = new string[9];
                arg = e.CommandArgument.ToString().Split(',');
                string name = arg[0];
                string cal = arg[1];
                string fat = arg[2];
                string chol = arg[3];
                string sodium = arg[4];
                string carbs = arg[5];
                string fiber = arg[6];
                string prot = arg[7];
                string sugar = arg[8];
                string size = arg[9];
                int retval = 0;
                objUserFoodLogBAO.UFL_ID = 0;
                objUserFoodLogBAO.ET_ID_FK = 4;
                objUserFoodLogBAO.SR_ID_FK = Convert.ToInt32(DrpQuanityUnit.SelectedValue);
                objUserFoodLogBAO.fk_user_registration_Id = 146;
                objUserFoodLogBAO.Search_Name = name;
                objUserFoodLogBAO.Product_Size = size;
                objUserFoodLogBAO.QUANTITY = txtQuantity.Text;
                if (cal != "")
                {
                    objUserFoodLogBAO.CALORIES = cal;
                }
                else
                {
                    objUserFoodLogBAO.CALORIES = "0.0";
                }
                if (fat != "")
                {
                    objUserFoodLogBAO.FAT = fat;
                }
                else
                {
                    objUserFoodLogBAO.FAT = "0.0";
                }
                if (chol != "")
                {
                    objUserFoodLogBAO.CHOLESTROL = chol;
                }
                else
                {
                    objUserFoodLogBAO.CHOLESTROL = "0.0";
                }
                if (sodium != "")
                {
                    objUserFoodLogBAO.SODIUM = sodium;
                }
                else
                {
                    objUserFoodLogBAO.SODIUM = "0.0";
                }
                if (carbs != "")
                {
                    objUserFoodLogBAO.CARBOHYDRATES = carbs;
                }
                else
                {
                    objUserFoodLogBAO.CARBOHYDRATES = "0.0";
                }
                if (fiber != "")
                {
                    objUserFoodLogBAO.FIBER = fiber;
                }
                else
                {
                    objUserFoodLogBAO.FIBER = "0.0";
                }
                if (prot != "")
                {
                    objUserFoodLogBAO.PROTIENS = prot;
                }
                else
                {
                    objUserFoodLogBAO.PROTIENS = "0.0";
                }
                if (sugar != "")
                {
                    objUserFoodLogBAO.SUGAR = sugar;
                }
                else
                {
                    objUserFoodLogBAO.SUGAR = "0.0";
                }
                objUserFoodLogBAO.UFL_DATE = DateTime.Now.ToString();
                objUserFoodLogBAO.ProcedureType = "I";
                retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLogBAO);
                BindFoodLog();
                dvSearch.Style.Add("display", "");
                BindTotal();
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string lbid;
            lbid = ((Label)GridView2.Rows[e.RowIndex].FindControl("lbID")).Text;
            if (lbid != "")
            {
                int retval = 0;
                objUserFoodLogBAO.UFL_ID = lbid;
                objUserFoodLogBAO.ProcedureType = "DF";
                retval = UserFoodLogDAO.DeletetblUSerFoodLog(objUserFoodLogBAO);
                GridView2.EditIndex = -1;
                BindFoodLog();
            }

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lbid, DrpEatTime1, txtServing, txtcal;
            lbid = ((Label)GridView2.Rows[e.RowIndex].FindControl("lbID")).Text;
            DrpEatTime1 = ((DropDownList)GridView2.Rows[e.RowIndex].FindControl("DrpEatTime")).SelectedValue;
            txtServing = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("txtServings")).Text;
            txtcal = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("txtcals")).Text;
            DataTable dt = new DataTable();
            objUserRegisterBAO.ID = Convert.ToInt32(lbid);
            objUserRegisterBAO.procedureType = "FL";
            dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
            if (dt.Rows.Count > 0)
            {
                int retval = 0;
                objUserFoodLogBAO.UFL_ID = lbid;
                objUserFoodLogBAO.ET_ID_FK = DrpEatTime1;
                objUserFoodLogBAO.SR_ID_FK = dt.Rows[0]["SR_ID_FK"].ToString();
                objUserFoodLogBAO.fk_user_registration_Id = dt.Rows[0]["fk_user_registration_Id"].ToString();
                objUserFoodLogBAO.Search_Name = dt.Rows[0]["Search_Name"].ToString();
                objUserFoodLogBAO.Product_Size = dt.Rows[0]["Product_Size"].ToString();
                objUserFoodLogBAO.QUANTITY = txtServing;
                objUserFoodLogBAO.CALORIES = txtcal;
                objUserFoodLogBAO.FAT = dt.Rows[0]["FAT"].ToString();
                objUserFoodLogBAO.CHOLESTROL = dt.Rows[0]["CHOLESTROL"].ToString();
                objUserFoodLogBAO.SODIUM = dt.Rows[0]["SODIUM"].ToString();
                objUserFoodLogBAO.CARBOHYDRATES = dt.Rows[0]["CARBOHYDRATES"].ToString();
                objUserFoodLogBAO.FIBER = dt.Rows[0]["FIBER"].ToString();
                objUserFoodLogBAO.PROTIENS = dt.Rows[0]["PROTIENS"].ToString();
                objUserFoodLogBAO.SUGAR = dt.Rows[0]["SUGAR"].ToString();
                objUserFoodLogBAO.UFL_DATE = dt.Rows[0]["UFL_DATE"].ToString();
                objUserFoodLogBAO.ProcedureType = "U";
                retval = UserFoodLogDAO.InserttblUserFoodLog(objUserFoodLogBAO);
            }
            GridView2.EditIndex = -1;
            BindFoodLog();
        }

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;

            BindFoodLog();
        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView2.EditIndex = -1;
            BindFoodLog();
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkAddFAv")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                objUserRegisterBAO.ID = id;
                objUserRegisterBAO.procedureType = "FL";
                dt = RegisterUserDAO.GetInvitationDetail(objUserRegisterBAO);
                if (dt.Rows.Count > 0)
                {
                    int retval = 0;
                    objUserFoodLogBAO.UAF_ID = 0;
                    objUserFoodLogBAO.UFL_ID_FK = id;
                    objUserFoodLogBAO.ET_ID_FK = dt.Rows[0]["ET_ID_FK"].ToString();
                    objUserFoodLogBAO.SR_ID_FK = dt.Rows[0]["SR_ID_FK"].ToString();
                    objUserFoodLogBAO.fk_user_registration_Id = dt.Rows[0]["fk_user_registration_Id"].ToString();
                    objUserFoodLogBAO.FOOD_NAME = dt.Rows[0]["Search_Name"].ToString();
                    objUserFoodLogBAO.Product_Size = dt.Rows[0]["Product_Size"].ToString();
                    objUserFoodLogBAO.QUANTITY = dt.Rows[0]["QUANTITY"].ToString();
                    objUserFoodLogBAO.CALORIES = dt.Rows[0]["CALORIES"].ToString();
                    objUserFoodLogBAO.FAT = dt.Rows[0]["FAT"].ToString();
                    objUserFoodLogBAO.CHOLESTROL = dt.Rows[0]["CHOLESTROL"].ToString();
                    objUserFoodLogBAO.SODIUM = dt.Rows[0]["SODIUM"].ToString();
                    objUserFoodLogBAO.CARBOHYDRATES = dt.Rows[0]["CARBOHYDRATES"].ToString();
                    objUserFoodLogBAO.FIBER = dt.Rows[0]["FIBER"].ToString();
                    objUserFoodLogBAO.PROTIENS = dt.Rows[0]["PROTIENS"].ToString();
                    objUserFoodLogBAO.SUGAR = dt.Rows[0]["SUGAR"].ToString();
                    objUserFoodLogBAO.UFA_DATE = DateTime.Now.ToString();
                    objUserFoodLogBAO.UFL_DATE = dt.Rows[0]["UFL_DATE"].ToString();
                    objUserFoodLogBAO.ProcedureType = "I";
                    retval = UserFoodLogDAO.InserttblAddFavouriteFoodLog(objUserFoodLogBAO);

                }
            }

        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList DrpEatTime = (DropDownList)e.Row.FindControl("DrpEatTime");
                if (DrpEatTime != null)
                {
                    DrpEatTime.Items.Clear();
                    objSqlHelper.fillDrpControl(DrpEatTime, "spFillDrpDown", "ET_NAME", "ET_ID", "EM");

                }
            }
        }

        private void piechartbind()
        {
            Series series1 = Chart2.Series[0];
            string[] xValues = { "Cals", "Fat", "Chol", "Sodium", "Carbs", "Fiber", "Prot", "Sugars" };
            int[] yValues = { cal, fat, chol, sodium, carbs, fiber, prot, sugar };
            Chart2.Series["Series1"].Points.DataBindXY(xValues, yValues);
            Chart2.Series["Series1"].Points[0].Color = Color.Red;
            Chart2.Series["Series1"].Points[1].Color = Color.BlueViolet;
            Chart2.Series["Series1"].Points[2].Color = Color.Blue;
            Chart2.Series["Series1"].Points[3].Color = Color.Indigo;
            Chart2.Series["Series1"].Points[4].Color = Color.DarkBlue;
            Chart2.Series["Series1"].Points[5].Color = Color.RosyBrown;
            Chart2.Series["Series1"].Points[6].Color = Color.RoyalBlue;
            Chart2.Series["Series1"].Points[7].Color = Color.Yellow;
            Chart2.Series["Series1"].ChartType = SeriesChartType.Pie;
            Chart2.Series["Series1"]["PieLabelStyle"] = "Enable";
            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart2.Legends.Add("Legend1");
            Chart2.Legends["Legend1"].Enabled = true;
            Chart2.Legends["Legend1"].Docking = Docking.Bottom;
            Chart2.Series["Series1"].IsVisibleInLegend = true;
            Chart2.Series[0].Points[0].CustomProperties += "Exploded=true";
        }

        private void BindTotal()
        {
           
            DataTable dt = new DataTable();
            objUserFoodLogBAO.fk_user_registration_Id = 146;
            if (hdfromdate.Value == "")
            {
                objUserFoodLogBAO.UFL_DATE = Convert.ToString(DateTime.Now.Date);
            }
            else
            {
                objUserFoodLogBAO.UFL_DATE = Convert.ToString(hdfromdate.Value);
            }
            objUserFoodLogBAO.ProcedureType = "T";
            dt = UserFoodLogDAO.GetUserFoodLog(objUserFoodLogBAO);
            if (dt.Rows.Count > 0)
            {
                dvChart.Style.Add("display", "");
                if (dt.Rows[0]["totalcal"].ToString() != "")
                {
                    lbCal.Text = dt.Rows[0]["totalcal"].ToString() + "cal";
                    cal = Convert.ToInt32(dt.Rows[0]["totalcal"]);
                }
                else
                {
                    lbCal.Text = "0cal";
                    dvChart.Style.Add("display", "none");
                }

                if (dt.Rows[0]["totalfat"].ToString() != "")
                {
                    lbFat.Text = dt.Rows[0]["totalfat"].ToString() + "g";
                    fat = Convert.ToInt32(dt.Rows[0]["totalfat"]);
                }
                else
                {
                    lbFat.Text = "0g";
                    dvChart.Style.Add("display", "none");
                }

                if (dt.Rows[0]["totalchol"].ToString() != "")
                {
                    lbChol.Text = dt.Rows[0]["totalchol"].ToString() + "mg";
                    chol = Convert.ToInt32(dt.Rows[0]["totalchol"]);
                }
                else
                {
                    lbChol.Text = "0mg";
                    dvChart.Style.Add("display", "none");
                }

                if (dt.Rows[0]["totalsodium"].ToString() != "")
                {
                    lbSodium.Text = dt.Rows[0]["totalsodium"].ToString() + "mg";
                    sodium = Convert.ToInt32(dt.Rows[0]["totalsodium"]);
                }
                else
                {
                    lbSodium.Text = "0mg";
                    dvChart.Style.Add("display", "none");
                }

                if (dt.Rows[0]["totalcarbs"].ToString() != "")
                {
                    lbCrabs.Text = dt.Rows[0]["totalcarbs"].ToString() + "g";
                    carbs = Convert.ToInt32(dt.Rows[0]["totalcarbs"]);
                }
                else
                {
                    lbCrabs.Text = "0g";
                    dvChart.Style.Add("display", "none");
                }

                if (dt.Rows[0]["totalfiber"].ToString() != "")
                {
                    lbFiber.Text = dt.Rows[0]["totalfiber"].ToString() + "g";
                    fiber = Convert.ToInt32(dt.Rows[0]["totalfiber"]);
                }
                else
                {
                    lbFiber.Text = "0g";
                    dvChart.Style.Add("display", "none");
                }

                if (dt.Rows[0]["totalprot"].ToString() != "")
                {
                    lbProt.Text = dt.Rows[0]["totalprot"].ToString() + "g";
                    prot = Convert.ToInt32(dt.Rows[0]["totalprot"]);
                }
                else
                {
                    lbProt.Text = "0g";
                    dvChart.Style.Add("display", "none");
;                }

                if (dt.Rows[0]["totalsugar"].ToString() != "")
                {
                    lbSugars.Text = dt.Rows[0]["totalsugar"].ToString() + "g";
                    sugar = Convert.ToInt32(dt.Rows[0]["totalsugar"]);
                }
                else
                {
                    lbSugars.Text = "0g";
                    dvChart.Style.Add("display", "none");
                }

            }
            else
            {
                dvChart.Style.Add("display", "none");
                lbCal.Text = "0";
                lbFat.Text = "0";
                lbChol.Text = "0";
                lbSodium.Text = "0";
                lbCrabs.Text = "0";
                lbFiber.Text = "0";
                lbProt.Text = "0";
                lbSugars.Text = "0";
            }
        }
        protected void Chart2_Click(object sender, ImageMapEventArgs e)
        {
            int _clickedPoint = int.Parse(e.PostBackValue);
            Series series1 = Chart2.Series[0];
            string[] xValues = { "Cals", "Fat", "Chol", "Sodium", "Carbs", "Fiber", "Prot", "Sugars" };
            int[] yValues = { cal, fat, chol, sodium, carbs, fiber, prot, sugar };
            Chart2.Series["Series1"].Points.DataBindXY(xValues, yValues);
            Chart2.Series["Series1"].Points[0].Color = Color.Red;
            Chart2.Series["Series1"].Points[1].Color = Color.BlueViolet;
            Chart2.Series["Series1"].Points[2].Color = Color.Blue;
            Chart2.Series["Series1"].Points[3].Color = Color.Indigo;
            Chart2.Series["Series1"].Points[4].Color = Color.DarkBlue;
            Chart2.Series["Series1"].Points[5].Color = Color.RosyBrown;
            Chart2.Series["Series1"].Points[6].Color = Color.RoyalBlue;
            Chart2.Series["Series1"].Points[7].Color = Color.Yellow;
            Series defaultSeries = Chart2.Series["Series1"];
            if (_clickedPoint >= 0 && _clickedPoint < chartPoints)
            {
                Chart2.Series["Series1"].Points[_clickedPoint].CustomProperties += "Exploded=true";
            }
        }

        protected void txtCalender_TextChanged(object sender, EventArgs e)
        {
            BindFoodLog();
            BindTotal();
        }
    }
}