using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ALEREIMPACT.FRAMEWORK
{
    public class SQLHelper
    {
        //private static readonly ILog log = log4net.LogManager.GetLogger("File");
        SqlConnection con;// = new SqlConnection();
        public SQLHelper()
        {
            //
            // TODO: Add constructor logic here
            //
            con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            // con.ConnectionString = ConfigurationSettings.AppSettings["cn"].ToString();

        }
        //Code to Access Controls
        public void ReadOnlyTextBox(bool status, Control ctrlPage)
        {
            ContentPlaceHolder myConternt = (ContentPlaceHolder)ctrlPage.FindControl("ContentPlaceHolder1");
            foreach (Control c in myConternt.Controls)
            {
                foreach (Control ctr in c.Controls)
                {
                    foreach (Control ctr1 in ctr.Controls)
                    {
                        foreach (Control ctrR in ctr1.Controls)
                        {
                            foreach (Control ctrC in ctrR.Controls)
                            {
                                //TextBox
                                if (ctrC is HtmlInputText)
                                {
                                    ((HtmlInputText)(ctrC)).Disabled = status;
                                }
                                //RadioButton
                                if (ctrC is RadioButtonList)
                                {
                                    if (status == true)
                                    {
                                        ((RadioButtonList)(ctrC)).Enabled = false;
                                    }
                                    else
                                    {
                                        ((RadioButtonList)(ctrC)).Enabled = true;
                                    }
                                }

                                //CheckBox
                                if (ctrC is CheckBox)
                                {
                                    if (status == true)
                                    {
                                        ((CheckBox)(ctrC)).Enabled = false;
                                    }
                                    else
                                    {
                                        ((CheckBox)(ctrC)).Enabled = true;
                                    }
                                }

                                //ASP TextBox
                                if (ctrC is TextBox)
                                {
                                    if (status == true)
                                    {
                                        ((TextBox)(ctrC)).Enabled = false;
                                    }
                                    else
                                    {
                                        ((TextBox)(ctrC)).Enabled = true;
                                    }
                                }
                                //DropDownList
                                if (ctrC is DropDownList)
                                {
                                    if (status == true)
                                    {
                                        ((DropDownList)(ctrC)).Enabled = false;
                                    }
                                    else
                                    {
                                        ((DropDownList)(ctrC)).Enabled = true;
                                    }


                                }
                                //select Html
                                if (ctrC is HtmlSelect)
                                {
                                    ((HtmlSelect)(ctrC)).Disabled = status;
                                }

                                //Image button
                                if (ctrC is ImageButton)
                                {
                                    if (status == true)
                                    {
                                        ((ImageButton)(ctrC)).Enabled = false;
                                    }
                                    else
                                    {
                                        ((ImageButton)(ctrC)).Enabled = true;
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }
        public void OpenConnection()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }
        public void CloseConnection()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }

        }
        public SqlDataReader GetRecordsReader(string sqlstr, SqlConnection conn)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader rd = null;
            cmd.Connection = conn;
            string retval = "";
            cmd.CommandText = sqlstr;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
            }
            return rd;
        }
        public string getScalarDataForAction(string sqlstr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string retval = "";
            cmd.CommandText = sqlstr;
            OpenConnection();
            if (cmd.ExecuteScalar() == null)
            {
                retval = "100";
            }
            else
            {
                retval = cmd.ExecuteScalar().ToString();
            }
            CloseConnection();
            return retval;
        }
        public string getScalarData(string sqlstr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string retval = "";
            cmd.CommandText = sqlstr;
            OpenConnection();
            if (cmd.ExecuteScalar() != null)
            {
                retval = cmd.ExecuteScalar().ToString();
            }
            CloseConnection();
            return retval;
        }
        public string getScalarData(SqlCommand cmd)
        {
            cmd.Connection = con;
            string retval = "";
            try
            {
                OpenConnection();
                retval = cmd.ExecuteScalar().ToString();
            }
            catch
            {
                //do nothing
            }
            finally
            {
                CloseConnection();
            }
            return retval;
        }
        /// <summary>
        /// this is GetRecords returns a datatable against a supplied query
        /// </summary>
        /// <param name="sqlstr">A data base query or stored procedure supplied here.</param>
        /// <returns>datatable</returns>
        public string DeleteData(string sqlstr, IList<Parameters> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            // List<className>obj=new List<className>();
            string retval = "";

            try
            {

                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                retval = "1";
            }
            catch (Exception ex)
            {
                //do nothing
                retval = ex.Message + " Source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return retval;

        }
        public System.Data.DataTable getRecords(string sqlstr, IList<Parameters> parameters)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            System.Data.DataTable dt = new System.Data.DataTable();

            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {

                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {

                sda.Dispose();
                CloseConnection();

            }
            return dt;

        }
        public System.Data.DataSet getRecordsDS(string sqlstr, IList<Parameters> parameters)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            System.Data.DataSet ds = new System.Data.DataSet();

            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {

                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
            }
            catch
            {
                //do nothing
            }
            finally
            {

                sda.Dispose();
                CloseConnection();

            }
            return ds;

        }

        public System.Data.DataTable getRecords1(string sqlstr, IList<Parameters> parameters)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            System.Data.DataTable dt = new System.Data.DataTable();
            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {

                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
            catch
            {
                //do nothing
            }
            finally
            {

                sda.Dispose();
                CloseConnection();

            }
            return dt;

        }

        public System.Data.DataTable getRecords(string sqlstr)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            System.Data.DataTable dt = new System.Data.DataTable();

            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                OpenConnection();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
            catch
            {
                //do nothing
            }
            finally
            {

                sda.Dispose();
                CloseConnection();

            }
            return dt;

        }

        public System.Data.DataTable getRecords(SqlCommand cmd)
        {
            cmd.Connection = con;
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                OpenConnection();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
            catch
            {
                //do nothing
            }
            finally
            {

                sda.Dispose();
                CloseConnection();

            }
            return dt;
        }
        public string fillControl(Object obj, string qry, string dt, string dv)
        {
            string retVal = "";
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            System.Data.DataTable dt1 = new System.Data.DataTable();
            try
            {
                adp.Fill(dt1);
                ((ListControl)obj).DataTextField = dt;
                ((ListControl)obj).DataValueField = dv;
                ((ListControl)obj).DataSource = dt1;
                ((ListControl)obj).DataBind();
            }
            catch (Exception ex)
            {
                retVal = "Error: " + ex.Message + "Error Source: " + ex.Source;
            }
            return retVal;

        }
        public string fillDrpControl(Object obj, string qry, string dt, string dv, string proceduretype)
        {
            string retVal = "";
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            adp.SelectCommand.Parameters.AddWithValue("@proceduretype", proceduretype);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            System.Data.DataTable dt1 = new System.Data.DataTable();
            try
            {
                adp.Fill(dt1);
                ((ListControl)obj).DataTextField = dt;
                ((ListControl)obj).DataValueField = dv;
                ((ListControl)obj).DataSource = dt1;
                ((ListControl)obj).DataBind();
            }
            catch (Exception ex)
            {
                retVal = "Error: " + ex.Message + "Error Source: " + ex.Source;
            }
            return retVal;

        }
        public string fillDrpControlwithid(Object obj, string qry, string dt, string dv, string id, string proceduretype)
        {
            string retVal = "";
            SqlDataAdapter adp = new SqlDataAdapter(qry, con);
            adp.SelectCommand.Parameters.AddWithValue("@proceduretype", proceduretype);
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            System.Data.DataTable dt1 = new System.Data.DataTable();
            try
            {
                adp.Fill(dt1);
                ((ListControl)obj).DataTextField = dt;
                ((ListControl)obj).DataValueField = dv;
                ((ListControl)obj).DataSource = dt1;
                ((ListControl)obj).DataBind();
            }
            catch (Exception ex)
            {
                retVal = "Error: " + ex.Message + "Error Source: " + ex.Source;
            }
            return retVal;

        }

        public int ExecuteNonQuery(string sqlstr, IList<Parameters> parameters)
        {

            SqlParameter _ID = new SqlParameter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            int retval = 0;

            try
            {
                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                //  _ID.Direction = ParameterDirection.InputOutput;
                SqlParameter retValParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                retValParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retValParam);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(retValParam.Value);

                // return Convert.ToInt32(_ID.Value);
            }
            catch (Exception ex)
            {
                //do nothing
                retval = 0;
            }
            finally
            {
                CloseConnection();
            }
            return retval;

        }
        public string InsertData(string sqlstr, IList<Parameters> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            string retval = "";

            try
            {
                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                retval = "1";
            }
            catch (Exception ex)
            {
                //do nothing
                retval = ex.Message + " Source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return retval;

        }
        public string InsertData(SqlCommand cmd)
        {
            cmd.Connection = con;
            string retval = "";
            try
            {
                int ret = 0;
                OpenConnection();
                ret = cmd.ExecuteNonQuery();
                if (ret == 1)
                {
                    retval = "1";
                }
            }
            catch (Exception ex)
            {
                retval = ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return retval;

        }
        public string InsertData(SqlCommand cmd, SqlConnection con)
        {

            string retval = "";
            try
            {
                int ret = 0;

                ret = cmd.ExecuteNonQuery();
                if (ret == 1)
                {
                    retval = "1";
                }
            }
            catch (Exception ex)
            {
                retval = ex.Message + "source: " + ex.Source;
            }
            finally
            {

            }
            return retval;

        }
        public string InsertData(SqlCommand cmd, string outParam)
        {
            cmd.Connection = con;
            string retval = "";
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
                retval = Convert.ToString(cmd.Parameters[outParam].Value);
            }
            catch (Exception ex)
            {
                retval = ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return retval;

        }
        public string ExecuteNonQuery(string strSql)
        {
            try
            {
                OpenConnection();
                SqlCommand sqlCommand = new SqlCommand(strSql, con);
                sqlCommand.ExecuteNonQuery();
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataSet ReturnDataSet(string strSql)
        {
            DataSet ds = new DataSet();
            try
            {
                OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                //return ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
        public DataSet ReturnDataSet(string strSql, string proceduretype)
        {
            DataSet ds = new DataSet();
            try
            {
                OpenConnection();
                SqlDataAdapter sda = new SqlDataAdapter(strSql, con);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@proceduretype", proceduretype);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                //return ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
        public int InsertAndReturn(string sqlstr, IList<Parameters> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sqlstr;
            int retval = 0;

            try
            {
                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter retValParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                retValParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(retValParam);
                retval = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                //do nothing

            }
            finally
            {
                CloseConnection();
            }
            return retval;

        }

        /// <summary>
        /// Developed By  : Rishi Narula
        /// Date : 11 Nov, 2011
        /// Purpose : To return multiple Record Sets On CheckGuestFacultyEligibility.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="?"></param>
        /// <returns></returns>

        public DataSet ReturnDataSet(string strSql, IList<Parameters> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            System.Data.DataTable dt = new System.Data.DataTable();
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                SqlParameter retValParam = new SqlParameter("@TotalRows", SqlDbType.Int);
                retValParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(retValParam);
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                sda.Fill(ds);
                ds.Tables[0].TableName = "PagedRecords";
                ds.Tables[1].TableName = "TotalNumberOfRecords";
            }
            catch (Exception ex)
            {
                //return ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
        /// <summary>
        /// Developed By  : Rishi Narula
        /// Date : 14 Nov, 2011
        /// Purpose : To return multiple Record Sets On WorkExpereinceCertificate.
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataSet ReturnWorkExperienceDataSet(string strSql, IList<Parameters> parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            System.Data.DataTable dt = new System.Data.DataTable();
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {

                for (int i = 0; i <= parameters.Count - 1; i++)
                    cmd.Parameters.AddWithValue(parameters[i].TextName.ToString(), parameters[i].TextValue.ToString());
                OpenConnection();
                sda.SelectCommand = cmd;
                sda.Fill(dt);

                sda.Fill(ds);
                ds.Tables[0].TableName = "ServiceDetails";
                ds.Tables[1].TableName = "AlreadySendRequest";
            }
            catch (Exception ex)
            {
                //return ex.Message + "source: " + ex.Source;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
    }
}
