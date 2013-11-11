using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.BAO.Admin;
using ALEREIMPACT.FRAMEWORK;
using System.Data;

namespace ALEREIMPACT.DAO.Admin
{
   public  class AdminFoodCategoryDAO
    {

        public static Int32 InserttblCategory(AdminFoodCategoryBAO objAdminFoodCategoryBAO)
       {
           int returnValue = 0;
           try
           {

               IList<Parameters> parametersList = new List<Parameters>();
               SQLHelper sQLHelper = new SQLHelper();

               parametersList.Add(new Parameters()
               {
                   TextName = "@CAT_ID",
                   TextValue = Convert.ToInt32(objAdminFoodCategoryBAO.CAT_ID).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@CAT_NAME",
                   TextValue = (objAdminFoodCategoryBAO.CAT_NAME).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@CAT_IMAGE",
                   TextValue = (objAdminFoodCategoryBAO.CAT_IMAGE).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@CAT_DATE",
                   TextValue = (objAdminFoodCategoryBAO.CAT_DATE).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@CAT_DESCRIPTION",
                   TextValue = (objAdminFoodCategoryBAO.CAT_DESCRIPTION).ToString()
               });
               parametersList.Add(new Parameters()
               {
                   TextName = "@ProcedureType",
                   TextValue = (objAdminFoodCategoryBAO.ProcedureType).ToString()
               });
               returnValue = sQLHelper.ExecuteNonQuery("spInserttblCategoryMaster", parametersList);
           }
           catch (Exception ex)
           {
               ex.ToString();
           }
           return returnValue;
       }

        public static Int32 InserttblSubCategory1(AdminFoodCategoryBAO objAdminFoodCategoryBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT1_ID",
                    TextValue = Convert.ToInt32(objAdminFoodCategoryBAO.SUBCAT1_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CAT_ID_FK",
                    TextValue = Convert.ToInt32(objAdminFoodCategoryBAO.CAT_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT1_NAME",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT1_NAME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT1_IMAGE",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT1_IMAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT1_DATE",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT1_DATE).ToString()
                });
             
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT1_DESCRIPTION",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT1_DESCRIPTION).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objAdminFoodCategoryBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblSucategory1", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static Int32 InserttblSubCategory2(AdminFoodCategoryBAO objAdminFoodCategoryBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT2_ID",
                    TextValue = Convert.ToInt32(objAdminFoodCategoryBAO.SUBCAT2_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT1_ID_FK",
                    TextValue = Convert.ToInt32(objAdminFoodCategoryBAO.SUBCAT1_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT2_NAME",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT2_NAME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT2_IMAGE",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT2_IMAGE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT2_DATE",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT2_DATE).ToString()
                });
               
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUBCAT2_DESCRIPTION",
                    TextValue = (objAdminFoodCategoryBAO.SUBCAT2_DESCRIPTION).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objAdminFoodCategoryBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblSubcategory2", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static Int32 DeleteFoodCategory(AdminFoodCategoryBAO objAdminFoodCategoryBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@ID",
                    TextValue = Convert.ToInt32(objAdminFoodCategoryBAO.ID).ToString()
                });
               
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objAdminFoodCategoryBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spFilterSearch", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


    }
}
