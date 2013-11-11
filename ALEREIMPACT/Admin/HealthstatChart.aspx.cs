using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.DAO.Admin;
using ALEREIMPACT.FRAMEWORK;

namespace ALEREIMPACT.Admin
{
    public partial class HealthstatChart : System.Web.UI.Page
    {
        AdminBAO objAdminBAO = new AdminBAO();
        public static Int32 userid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                //Response.Cache.SetNoStore();
                //Response.AppendHeader("Pragma", "no-cache");
               
                if (string.IsNullOrEmpty(MySession.Current.LoginId))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["val"]))
                        {
                            userid = Convert.ToInt32(Request.QueryString["val"]);
                        }
                        bindName();
                        BindChart();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void bindName()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.ID = userid;
                objAdminBAO.ProcedureType = "N1";
                dt = AdminDAO.GetUserDeatilsCount(objAdminBAO);
                if (dt.Rows.Count > 0)
                {
                    lbname.Text = dt.Rows[0]["usercode"].ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void BindChart()
        {
            try
            {
                DataTable dt = new DataTable();
                objAdminBAO.fk_login_id = userid;
                objAdminBAO.login_user_Id = userid;
                objAdminBAO.ProcedureType = "S";
                dt = AdminDAO.GetUserMissionProgressGraph(objAdminBAO);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        lbname.Text = dt.Rows[0]["name"].ToString();
                        if (Convert.ToString(dt.Rows[0]["weight_units"]) == "1")
                        {
                            spWeightunit.InnerText = "Kgs";
                        }
                        else
                        {
                            spWeightunit.InnerText = "lbs";
                        }
                        tblChartInfo.Visible = true;
                        tblEmptyRow.Visible = false;
                        string[] x = new string[dt.Rows.Count];
                        decimal[] y = new decimal[dt.Rows.Count];
                        int sumOfCalBurn = 0;
                        int stepsTaken = 0;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToString(dt.Rows[i]["DateOfInputSubmitted"]) != "0")
                            {
                                x[i] = dt.Rows[i]["DateOfInputSubmitted"].ToString();
                                y[i] = Convert.ToInt32(dt.Rows[i]["InputSubmitted"]);

                                sumOfCalBurn += Convert.ToInt32(dt.Rows[i]["InputSubmitted"].ToString().Trim());
                                stepsTaken += Convert.ToInt32(dt.Rows[i]["StepsCovered"].ToString().Trim());
                            }
                        }
                        spCalBurned.InnerText = sumOfCalBurn.ToString();
                        spStepsTaken.InnerText = stepsTaken.ToString();

                        x = x.Where(i => !String.IsNullOrEmpty(i)).ToArray();
                        y = y.Where(j => !String.IsNullOrEmpty(Convert.ToString(j))).ToArray();

                        LineChart2.CategoriesAxis = string.Join(",", x);
                        LineChart2.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y, Name = "Calorie Burnt", LineColor = "Orange" });


                        /* Consumed Line*/

                        decimal[] x_consume = new decimal[dt.Rows.Count];
                        int sumOfCalConsume = 0;
                        for (int i_consume = 0; i_consume < dt.Rows.Count; i_consume++)
                        {
                            if (!String.IsNullOrEmpty(Convert.ToString(dt.Rows[i_consume]["CalorieConsumed"])))
                            {
                                x_consume[i_consume] = Convert.ToInt32(dt.Rows[i_consume]["CalorieConsumed"]);
                                sumOfCalConsume += Convert.ToInt32(dt.Rows[i_consume]["CalorieConsumed"].ToString().Trim());
                            }
                            //LineChart2.AreaDataLabel = x[i_consume] + " <br/> Calories Consumed " + x_consume[i_consume];
                        }

                        spCalConsume.InnerText = sumOfCalConsume.ToString();


                        string[] strArray = new string[dt.Rows.Count];
                        for (int iCount = 0; iCount < x_consume.Count(); iCount++)
                        {
                            strArray[iCount] = x_consume[iCount].ToString();
                        }

                        strArray = strArray.Where(i => !String.IsNullOrEmpty(i)).ToArray();
                        y = new decimal[strArray.Count()];

                        for (int iCountDec = 0; iCountDec < strArray.Count(); iCountDec++)
                        {
                            y[iCountDec] = Convert.ToDecimal(strArray[iCountDec].ToString());
                        }


                        spWeight.InnerText = dt.Rows[0]["weight_left"].ToString();



                        if (sumOfCalConsume != 0)
                        {
                            LineChart2.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y, Name = "Calorie Consume", LineColor = "Green" });
                        }


                        if (dt.Rows.Count > 3)
                        {
                            LineChart2.ChartWidth = Convert.ToString(dt.Rows.Count * 50);
                        }




                        /******************** weight *********************/


                        string category = "";
                        decimal[] y_weight = new decimal[dt.Rows.Count];


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            category = category + "," + dt.Rows[i]["DateOfInputSubmitted"].ToString();
                            y_weight[i] = Convert.ToDecimal(dt.Rows[i]["weight_left"]);

                        }
                        lnchweigth.CategoriesAxis = category.Remove(0, 1);
                        lnchweigth.Series.Add(new AjaxControlToolkit.LineChartSeries { Data = y_weight, Name = "Weight", LineColor = "Blue" });

                        if (dt.Rows.Count > 3)
                        {
                            lnchweigth.ChartWidth = Convert.ToString(dt.Rows.Count * 50);
                        }

                    }

                    else
                    {
                        tblChartInfo.Visible = false;
                        tblEmptyRow.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            }

        protected void lnkHealthstats_Click(object sender, EventArgs e)
        {
            ClsGeneric.ReplaceCookie();
            try
            {
                Session["Healthstats"] = true;
                Response.Redirect("HealthStats.aspx", false);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        }
    }

