using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Xml;
using System.Net;
using ALEREIMPACT.FRAMEWORK;
using Newtonsoft.Json;

namespace ALEREIMPACT.Service
{
    /// <summary>
    /// Summary description for FoodEssentialAPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class FoodEssentialAPI : System.Web.Services.WebService
    {
        public static string total;
        public static Int32 s = 0;
        public static Int32 n = 10;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                string a = "";
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                    // if string with JSON data is not empty, deserialize it to class and return its instance
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                if (json_data != "")
                {
                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                }
                else
                {
                    return string.IsNullOrEmpty(a) ? JsonConvert.DeserializeObject<T>(a) : new T();
                }
            }

        }

        private static T _download_serialized_json_data_2<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                string a = "";
                var json_data = string.Empty;

                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url.Replace(",", "").Replace("''", "").Replace("\"", "").Replace("\r\n", "").Replace("\"", "").Replace("''", "").Replace("\"", "").Replace("''", "").Replace(",", ""));
                    json_data = json_data.Substring(11, json_data.Length - 12);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                if (json_data != "")
                {
                    if (json_data.Contains("error in your call"))
                    {
                        json_data = "";
                        return string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                    }

                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
                }
                else
                {
                    return string.IsNullOrEmpty(a) ? JsonConvert.DeserializeObject<T>(a) : new T();
                }
            }
        }
        public class CurrencyRates
        {
            public string numFound { get; set; }
            public string resultSize { get; set; }
            public string session_id { get; set; }
            public string Base { get; set; }
            public List<object> productsArray { get; set; }
        }
        public class CurrencyRates1
        {
            public string product { get; set; }
            public string product_name { get; set; }
            public string brand { get; set; }
            public string manufacturer { get; set; }
            public List<object> nutrients { get; set; }
        }
        [WebMethod]
        public string[] FoodEssentialAPISearch(string prefixText, string contextKey)
        {  
            decimal nutr_vale = 0;
            decimal nutr_vale1 = 0;
            decimal nutr_vale2 = 0;
            decimal nutr_vale3 = 0;
            decimal nutr_vale4 = 0;
            decimal nutr_vale5 = 0;
            decimal nutr_vale6 = 0;
            decimal nutr_vale7 = 0;
            List<string> ProductList = new List<string>();
            int nodeCount = 0;
            int value = Convert.ToInt32(contextKey);
          // string url = "http://api.foodessentials.com/searchprods?q=" + prefixText + "&sid=825655af-789e-482f-9ae1-2ce4f867a466&n=50&s=0&f=xml&api_key=mv4eez56p3g38cy4mukkqfxd";
           string url = "http://api.foodessentials.com/searchprods?q=" + prefixText + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&n=" + n + "&s=" + s + "&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";

            var currencyRates = _download_serialized_json_data<CurrencyRates>(url);

            string data = null;
            string data1 = null;

            DataTable table = new DataTable("ApiData");

            table.Columns.Add("upc", typeof(string));
            table.Columns.Add("product_name", typeof(string));
            //table.Columns.Add("brand", typeof(string));
            table.Columns.Add("product_size", typeof(string));
            table.Columns.Add("cal", typeof(string));
            // table.Columns.Add("Cal_Unit", typeof(string));
            table.Columns.Add("Cholesterol", typeof(string));
            table.Columns.Add("Fiber", typeof(string));
            table.Columns.Add("Protein", typeof(string));
            table.Columns.Add("Sodium", typeof(string));
            table.Columns.Add("Sugars", typeof(string));
            table.Columns.Add("Carbohydrate", typeof(string));
            table.Columns.Add("Fat", typeof(string));
            if (currencyRates.productsArray != null)
            {
                for (var x = 0; x < currencyRates.productsArray.Count; x++)
                {
                    data = currencyRates.productsArray[x].ToString();

                    int p_size = data.IndexOf("product_size");
                    // int b_brand = data.IndexOf("brand");
                    int p_name = data.IndexOf("product_name");
                    int p_desc = data.IndexOf("product_description");
                    int manu = data.IndexOf("manufacturer");

                    string upc = data.Substring(13, 12).Replace(",", "").Replace("''", "").Replace("\"", "").Replace("\r\n", "").Replace("\"", "").Replace("''", "").Replace("\"", "").Replace("''", "").Replace(",", "");
                    string url1 = "http://api.foodessentials.com/productscore?u=" + upc + "&sid=bed3cdd4-4e20-4ce6-a5b2-bed53076e9a3&f=json&api_key=mv4eez56p3g38cy4mukkqfxd";
                    int cal = 0;
                    int unit = 0;
                    var currencyRates1 = _download_serialized_json_data_2<CurrencyRates1>(url1);
                    if (currencyRates1 != null)
                    {
                        if (currencyRates1.nutrients != null)
                        {
                            if (currencyRates1.nutrients.Count > 0)
                            {
                                for (var x1 = 0; x1 < currencyRates1.nutrients.Count; x1++)
                                {
                                    data1 = currencyRates1.nutrients[x1].ToString();
                                    cal = data1.IndexOf("nutrient_value");
                                    unit = data1.IndexOf("nutrient_uom");
                                    int nu_feLevel = data1.IndexOf("nutrient_fe_level");



                                    string text = Convert.ToString(data1.Substring(23, 6));

                                    if (text == "Calori")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            // lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";
                                            // lbCalsTotal.Text = Convert.ToString(nutr_vale);

                                        }
                                        else
                                        {
                                            nutr_vale = 0;
                                            // lbTotalcal.Text = Convert.ToString(nutr_vale) + "cal";
                                            // lbCalsTotal.Text = Convert.ToString(nutr_vale);

                                        }
                                        //if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(unit + 16, nu_feLevel - unit - 18))))
                                        //{
                                        //    nutr_unit = Convert.ToString(data1.Substring(unit + 16, nu_feLevel - unit - 18));
                                        //}

                                        //else
                                        //{
                                        //    nutr_unit = "";
                                        //}
                                    }
                                    else if (text == "Choles")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale1 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            // lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
                                        }
                                        else
                                        {
                                            nutr_vale1 = 0;
                                            //lbtotalchol.Text = Convert.ToString(nutr_vale1) + "mg";
                                        }

                                    }
                                    else if (text == "Dietar")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale2 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            // lbTotalFiber.Text= Convert.ToString(nutr_vale2) + "g";
                                        }
                                        else
                                        {
                                            nutr_vale2 = 0;
                                            // lbTotalFiber.Text = Convert.ToString(nutr_vale2) + "g";
                                        }

                                    }

                                    else if (text == "Protei")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale3 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            //  lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
                                        }
                                        else
                                        {
                                            nutr_vale3 = 0;
                                            //  lbTotalProteins.Text = Convert.ToString(nutr_vale3) + "g";
                                        }

                                    }

                                    else if (text == "Sodium")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale4 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            // lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
                                        }
                                        else
                                        {
                                            nutr_vale4 = 0;
                                            //  lbTotalSodium.Text = Convert.ToString(nutr_vale4) + "mg";
                                        }

                                    }

                                    else if (text == "Sugars")
                                    {
                                        if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                        {

                                            nutr_vale5 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                            // lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
                                        }
                                        else
                                        {
                                            nutr_vale5 = 0;
                                            //  lbTotalSugar.Text = Convert.ToString(nutr_vale5) + "g";
                                        }

                                    }
                                    if (total == null)
                                    {
                                        if (text == "Total ")
                                        {
                                            if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                            {

                                                nutr_vale6 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                total = text;
                                                // lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
                                            }
                                            else
                                            {
                                                nutr_vale6 = 0;
                                                // lbtotalCarbs.Text = Convert.ToString(nutr_vale6) + "g";
                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (text == "Total ")
                                        {
                                            if (!String.IsNullOrEmpty(Convert.ToString(data1.Substring(cal + 18, unit - cal - 25))))
                                            {

                                                nutr_vale7 = Convert.ToDecimal(data1.Substring(cal + 18, unit - cal - 25));
                                                // lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
                                            }
                                            else
                                            {
                                                nutr_vale7 = 0;
                                                //  lbtotalfat.Text = Convert.ToString(nutr_vale7) + "g";
                                            }

                                        }
                                    }

                                }

                                // table.Rows.Add(nutr_vale, nutr_unit);
                            //    string size = data.Substring(p_size + 16, 3).Replace("''", "").Replace("}", "").Replace("\"\r\n", "").Replace("\"", "");
                                string size = data.Substring(p_size + 16).Replace("}", "").Replace("\"\r\n", "").Replace("\"", ""); ;
                                table.Rows.Add(data.Substring(13, 12), data.Substring(p_name + 16, p_desc - p_name - 23),
                           size, nutr_vale, nutr_vale1, nutr_vale2, nutr_vale3, nutr_vale4, nutr_vale5, nutr_vale6, nutr_vale7);
                            }
                        }
                    }

                }
            }       
          
                string ProductFinder = string.Empty;
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {

                       // ProductFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}", table.Rows[i]["product_name"].ToString()), table.Rows[i]["Fat"].ToString());
                        ProductFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", table.Rows[i]["product_name"].ToString(), table.Rows[i]["product_size"].ToString(), table.Rows[i]["cal"].ToString(), table.Rows[i]["Cholesterol"].ToString(), table.Rows[i]["Fiber"].ToString(),table.Rows[i]["Sugars"].ToString(),table.Rows[i]["Fat"].ToString()), table.Rows[i]["Protein"].ToString());
                        //ProductFinder = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(string.Format("{0}|{1}", table.Rows[i]["product_name"].ToString(), table.Rows[i]["cal"].ToString(),table.Rows[i]["Fiber"].ToString(),table.Rows[i]["Protein"].ToString(),table.Rows[i]["Carbohydrate"].ToString(),table.Rows[i]["Fat"].ToString(),table.Rows[i]["Fat"].ToString()),
                        ProductList.Add(ProductFinder);
                        
                    }

                }

           
            return ProductList.ToArray();
        }

       
    }
}


