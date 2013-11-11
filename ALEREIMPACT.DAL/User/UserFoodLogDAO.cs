using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.BAL.User;
using ALEREIMPACT.FRAMEWORK;
using ALEREIMPACT.BAO.User;
using System.Data;


namespace ALEREIMPACT.DAL.User
{
    public class UserFoodLogDAO
    {

        public static Int32 InserttblUserFoodLog(UserFoodLogBAO objUserFoodLogBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@UFL_ID",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.UFL_ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Search_Name",
                    TextValue = (objUserFoodLogBAO.Search_Name).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Product_Size",
                    TextValue = (objUserFoodLogBAO.Product_Size).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@QUANTITY",
                    TextValue = (objUserFoodLogBAO.QUANTITY).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CALORIES",
                    TextValue = (objUserFoodLogBAO.CALORIES).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FAT",
                    TextValue = (objUserFoodLogBAO.FAT).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CHOLESTROL",
                    TextValue = (objUserFoodLogBAO.CHOLESTROL).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SODIUM",
                    TextValue = (objUserFoodLogBAO.SODIUM).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CARBOHYDRATES",
                    TextValue = (objUserFoodLogBAO.CARBOHYDRATES).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FIBER",
                    TextValue = (objUserFoodLogBAO.FIBER).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PROTIENS",
                    TextValue = (objUserFoodLogBAO.PROTIENS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUGAR",
                    TextValue = (objUserFoodLogBAO.SUGAR).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UFL_DATE",
                    TextValue = (objUserFoodLogBAO.UFL_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserFoodLogBAO.ProcedureType).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_mission_id",
                    TextValue = (objUserFoodLogBAO.Fk_MissionId).ToString()
                });

                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserFoodLog", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }



        public static Int32 InserttblCustomFood(UserFoodLogBAO objUserFoodLogBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@food_Name",
                    TextValue = (objUserFoodLogBAO.FOOD_NAME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@brand_name",
                    TextValue = objUserFoodLogBAO.Brand_name.ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@serving_size",
                    TextValue = (objUserFoodLogBAO.Serving_size).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@calories",
                    TextValue = (objUserFoodLogBAO.CALORIES).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@calories_from_fat",
                    TextValue = (objUserFoodLogBAO.CaloriesFromFat).ToString()
                });
             
                parametersList.Add(new Parameters()
                {
                    TextName = "@total_fat",
                    TextValue = (objUserFoodLogBAO.TotalFat).ToString()
                });


                parametersList.Add(new Parameters()
                {
                    TextName = "@saturated_fat",
                    TextValue = (objUserFoodLogBAO.SaturatedFat).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@trans_fat",
                    TextValue = (objUserFoodLogBAO.TransFat).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@cholestrol",
                    TextValue = (objUserFoodLogBAO.Cholestrol).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@sodium",
                    TextValue = (objUserFoodLogBAO.Sodium).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@potassium",
                    TextValue = (objUserFoodLogBAO.Potassium).ToString()
                });



                parametersList.Add(new Parameters()
                {
                    TextName = "@total_carbohydrates",
                    TextValue = (objUserFoodLogBAO.TotalCarbohydrates).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@dietary_fiber",
                    TextValue = (objUserFoodLogBAO.DietaryFiber).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@sugars",
                    TextValue = (objUserFoodLogBAO.Sugars).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@protein",
                    TextValue = (objUserFoodLogBAO.Protein).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@vitamin_A",
                    TextValue = (objUserFoodLogBAO.Vitamin_A).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@vitamin_C",
                    TextValue = (objUserFoodLogBAO.Vitamin_C).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@calcium",
                    TextValue = (objUserFoodLogBAO.Calcium).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@iron",
                    TextValue = (objUserFoodLogBAO.Iron).ToString()
                });


                parametersList.Add(new Parameters()
                {
                    TextName = "@thiamin",
                    TextValue = (objUserFoodLogBAO.Thiamin).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@riboflavin",
                    TextValue = (objUserFoodLogBAO.Riboflavin).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@vitaminB6",
                    TextValue = (objUserFoodLogBAO.VitaminB6).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@vitaminB12",
                    TextValue = (objUserFoodLogBAO.VitaminB12).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@vitaminE",
                    TextValue = (objUserFoodLogBAO.VitaminE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@folic_acid",
                    TextValue = (objUserFoodLogBAO.FolicAcid).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@niacin",
                    TextValue = (objUserFoodLogBAO.Niacin).ToString()
                });



                parametersList.Add(new Parameters()
                {
                    TextName = "@magnesium",
                    TextValue = (objUserFoodLogBAO.Magnesium).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@phosphorus",
                    TextValue = (objUserFoodLogBAO.Phosphorus).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@iodine",
                    TextValue = (objUserFoodLogBAO.Iodine).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@zinc",
                    TextValue = (objUserFoodLogBAO.Zinc).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@copper",
                    TextValue = (objUserFoodLogBAO.Copper).ToString()
                });



                parametersList.Add(new Parameters()
                {
                    TextName = "@biotin",
                    TextValue = (objUserFoodLogBAO.Biotin).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@pantothenic_acid",
                    TextValue = (objUserFoodLogBAO.Pantothenic).ToString()
                });




                parametersList.Add(new Parameters()
                {
                    TextName = "@vitaminD",
                    TextValue = (objUserFoodLogBAO.VitaminD).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@carbohydrates",
                    TextValue = (objUserFoodLogBAO.CARBOHYDRATES).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fiber",
                    TextValue = (objUserFoodLogBAO.FIBER).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@date_added",
                    TextValue = (objUserFoodLogBAO.UFL_DATE).ToString()
                });
              

                returnValue = sQLHelper.ExecuteNonQuery("spAddCustom_Food", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataTable GetUserFoodLog(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@fk_user_registration_Id",
                TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_Id).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@UFL_DATE",
                TextValue =  objUserFoodLogBAO.UFL_DATE.ToString()
            });

            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objUserFoodLogBAO.ProcedureType.ToString()
            });


            parametersList.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = objUserFoodLogBAO.Fk_MissionId.ToString()
            });

            parametersList.Add(new Parameters()
            {
                TextName = "@RequestType",
                TextValue = objUserFoodLogBAO.ID.ToString()
            });

            return sQLHelper.getRecords("spViewUserFoodLog", parametersList);
        }

        public static Int32 DeletetblUSerFoodLog(UserFoodLogBAO objUserFoodLogBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();


                parametersList.Add(new Parameters()
                {
                    TextName = "@ID",
                    TextValue = (objUserFoodLogBAO.UFL_ID).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserFoodLogBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spFilterSearch", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }


        public static Int32 InserttblAddFavouriteFoodLog(UserFoodLogBAO objUserFoodLogBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();
                parametersList.Add(new Parameters()
                {
                    TextName = "@UAF_ID",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.UAF_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UFL_ID_FK",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.UFL_ID_FK).ToString()
                });

                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_Id",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_Id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FOOD_NAME",
                    TextValue = (objUserFoodLogBAO.FOOD_NAME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@Product_Size",
                    TextValue = (objUserFoodLogBAO.Product_Size).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@QUANTITY",
                    TextValue = (objUserFoodLogBAO.QUANTITY).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CALORIES",
                    TextValue = (objUserFoodLogBAO.CALORIES).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FAT",
                    TextValue = (objUserFoodLogBAO.FAT).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CHOLESTROL",
                    TextValue = (objUserFoodLogBAO.CHOLESTROL).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SODIUM",
                    TextValue = (objUserFoodLogBAO.SODIUM).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@CARBOHYDRATES",
                    TextValue = (objUserFoodLogBAO.CARBOHYDRATES).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@FIBER",
                    TextValue = (objUserFoodLogBAO.FIBER).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PROTIENS",
                    TextValue = (objUserFoodLogBAO.PROTIENS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@SUGAR",
                    TextValue = (objUserFoodLogBAO.SUGAR).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UFA_DATE",
                    TextValue = (objUserFoodLogBAO.UFA_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UFL_DATE",
                    TextValue = (objUserFoodLogBAO.UFL_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserFoodLogBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblAddFavFoodLog", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataTable GetFoodCategories(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();

            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objUserFoodLogBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spUsermanagement", parametersList);
        }

        public static DataTable GetFoodSubCategories(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();
            parametersList.Add(new Parameters()
            {
                TextName = "@ID",
                TextValue = Convert.ToInt32(objUserFoodLogBAO.ID).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@ProcedureType",
                TextValue = objUserFoodLogBAO.ProcedureType.ToString()
            });
            return sQLHelper.getRecords("spFilterSearch", parametersList);
        }


        public static DataTable ShowHistoryRecordsOnBasisOfDate(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();


            parametersList.Add(new Parameters()
            {
                TextName = "@selected_date",
                TextValue = (objUserFoodLogBAO.UFL_DATE).ToString()
            });

            parametersList.Add(new Parameters()
            {
                TextName = "@fk_mission_id",
                TextValue = (objUserFoodLogBAO.Fk_MissionId).ToString()
            });

            parametersList.Add(new Parameters()
            {
                TextName = "@fk_login_id",
                TextValue = (objUserFoodLogBAO.fk_user_registration_Id).ToString()
            });
            return sQLHelper.getRecords("spCaloriesRecordBasedOnDates", parametersList);
        }

        public static DataTable ShowActivitiesBasedonSearchText(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();


            parametersList.Add(new Parameters()
            {
                TextName = "@search_text",
                TextValue = (objUserFoodLogBAO.Search_Name).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@request_type",
                TextValue = (objUserFoodLogBAO.ID).ToString()
            });
            return sQLHelper.getRecords("spGetActivities", parametersList);
        }
        public static DataSet ShowQuickLogActivities(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();

            parametersList.Add(new Parameters()
            {
                TextName = "@log_type",
                TextValue = (objUserFoodLogBAO.RequestType).ToString()
            });
            parametersList.Add(new Parameters()
            {
                TextName = "@login_id",
                TextValue = (objUserFoodLogBAO.fk_user_registration_Id).ToString()
            });

            return sQLHelper.getRecordsDS("sp_BindQuickLog", parametersList);
        }

        public static Int32 InserttblUserEatingHabbit(UserFoodLogBAO objUserFoodLogBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_ID",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.EH_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_BREAKFAST",
                    TextValue = (objUserFoodLogBAO.EH_BREAKFAST).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_LUNCH",
                    TextValue = (objUserFoodLogBAO.EH_LUNCH).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_DINNER",
                    TextValue = (objUserFoodLogBAO.EH_DINNER).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_MORNINGSNACKS",
                    TextValue = (objUserFoodLogBAO.EH_MORNINGSNACKS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_EVENINGSNACKS",
                    TextValue = (objUserFoodLogBAO.EH_EVENINGSNACKS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_UNCLASSIFIED",
                    TextValue = (objUserFoodLogBAO.EH_UNCLASSIFIED).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_BREAKFAST_TIME",
                    TextValue = (objUserFoodLogBAO.EH_BREAKFAST_TIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_LUNCH_TIME",
                    TextValue = (objUserFoodLogBAO.EH_LUNCH_TIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_DINNER_TIME",
                    TextValue = (objUserFoodLogBAO.EH_DINNER_TIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_MORNSNACKS_TIME",
                    TextValue = (objUserFoodLogBAO.EH_MORNSNACKS_TIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_EVENSNACKS_TIME",
                    TextValue = (objUserFoodLogBAO.EH_EVENSNACKS_TIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@EH_UNCLASSIFIED_TIME",
                    TextValue = (objUserFoodLogBAO.EH_UNCLASSIFIED_TIME).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserFoodLogBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserEatingHabbit", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

        public static DataSet GetCustomFoodList(UserFoodLogBAO objUserFoodLogBAO)
        {
            IList<Parameters> parametersList = new List<Parameters>();
            SQLHelper sQLHelper = new SQLHelper();

            parametersList.Add(new Parameters()
            {
                TextName = "@type",
                TextValue = objUserFoodLogBAO.ProcedureType.ToString()
            });

            return sQLHelper.getRecordsDS("spGet_CustomFood", parametersList);
        }
         public static Int32 InsertEatingTimeLog(UserFoodLogBAO objUserFoodLogBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@ETL_ID",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.ETL_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UFL_ID_FK",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.UFL_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ET_ID_FK",
                    TextValue = Convert.ToInt32(objUserFoodLogBAO.ET_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ETL_DATE",
                    TextValue = (objUserFoodLogBAO.ETL_DATE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objUserFoodLogBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserEatingTimeLog", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

         public static DataTable GetEatingTimeID(UserFoodLogBAO objUserFoodLogBAO)
         {
             IList<Parameters> parametersList = new List<Parameters>();
             SQLHelper sQLHelper = new SQLHelper();
             parametersList.Add(new Parameters()
             {
                 TextName = "@presenttime",
                 TextValue = objUserFoodLogBAO.presenttime.ToString()
             });
             parametersList.Add(new Parameters()
             {
                 TextName = "@ProcedureType",
                 TextValue = objUserFoodLogBAO.ProcedureType.ToString()
             });
             return sQLHelper.getRecords("spGetEatingTime", parametersList);
         }


         public static Int32 InsertblEmailScheduling(UserFoodLogBAO objUserFoodLogBAO)
         {
             int returnValue = 0;
             try
             {

                 IList<Parameters> parametersList = new List<Parameters>();
                 SQLHelper sQLHelper = new SQLHelper();

                 parametersList.Add(new Parameters()
                 {
                     TextName = "@ES_ID",
                     TextValue = Convert.ToInt32(objUserFoodLogBAO.ES_ID).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@fk_user_registration_id",
                     TextValue = Convert.ToInt32(objUserFoodLogBAO.fk_user_registration_id).ToString()
                 });
              
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@ET_ID_FK",
                     TextValue = Convert.ToInt32(objUserFoodLogBAO.ET_ID_FK).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@ES_DATE",
                     TextValue = (objUserFoodLogBAO.ES_DATE).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@ES_STATUS",
                     TextValue = (objUserFoodLogBAO.ES_STATUS).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@ProcedureType",
                     TextValue = (objUserFoodLogBAO.ProcedureType).ToString()
                 });
                 returnValue = sQLHelper.ExecuteNonQuery("spInserttblEmailScheduling", parametersList);
             }
             catch (Exception ex)
             {
                 ex.ToString();
             }
             return returnValue;
         }

         public static DataTable GetEatingID(UserFoodLogBAO objUserFoodLogBAO)
         {
             IList<Parameters> parametersList = new List<Parameters>();
             SQLHelper sQLHelper = new SQLHelper();
             parametersList.Add(new Parameters()
             {
                 TextName = "@presenttime",
                 TextValue = objUserFoodLogBAO.presenttime.ToString()
             });
             parametersList.Add(new Parameters()
             {
                 TextName = "@fk_user_registration_id",
                 TextValue = objUserFoodLogBAO.fk_user_registration_id.ToString()
             });
             parametersList.Add(new Parameters()
             {
                 TextName = "@ProcedureType",
                 TextValue = objUserFoodLogBAO.ProcedureType.ToString()
             });
             return sQLHelper.getRecords("spGetUserEmailScheduling", parametersList);
         }
    }
}

