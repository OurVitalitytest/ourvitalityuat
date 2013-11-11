using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAL.User
{
    public class UserFoodLogBAO
    {
        #region "Data Members"
        private object _UFL_ID = string.Empty;
        private object _ET_ID_FK = string.Empty;
        private object _SR_ID_FK = string.Empty;
        private object _fk_user_registration_Id = string.Empty;
        private object _Search_Name = string.Empty;
        private object _QUANTITY = string.Empty;
        private object _CALORIES = string.Empty;
        private object _FAT = string.Empty;
        private object _CHOLESTROL = string.Empty;
        private object _SODIUM = string.Empty;
        private object _CARBOHYDRATES = string.Empty;
        private object _FIBER = string.Empty;
        private object _PROTIENS = string.Empty;
        private object _SUGAR = string.Empty;
        private object _UFL_DATE = string.Empty;
        private object _UAF_ID = string.Empty;
        private object _UFL_ID_FK = string.Empty;
        private object _FOOD_NAME = string.Empty;
        private object _UFA_DATE = string.Empty;
        private object _ID = string.Empty;
        private object _Product_Size = string.Empty;
        private object _ProcedureType = string.Empty;
        private object _ETL_ID = string.Empty;
        private object _fk_user_registration_id = string.Empty;
        private object _ETL_DATE = string.Empty;
        private object _EH_ID = string.Empty;
        private object _EH_BREAKFAST = string.Empty;
        private object _EH_LUNCH = string.Empty;
        private object _EH_DINNER = string.Empty;
        private object _EH_MORNINGSNACKS = string.Empty;
        private object _EH_EVENINGSNACKS = string.Empty;
        private object _EH_UNCLASSIFIED = string.Empty;
        private object _EH_BREAKFAST_TIME = string.Empty;
        private object _EH_LUNCH_TIME = string.Empty;
        private object _EH_DINNER_TIME = string.Empty;
        private object _EH_MORNSNACKS_TIME = string.Empty;
        private object _EH_EVENSNACKS_TIME = string.Empty;
        private object _EH_UNCLASSIFIED_TIME = string.Empty;
        private object _presenttime = string.Empty;

        private object _ES_ID = string.Empty;
        private object _ES_DATE = string.Empty;
        private object _ES_STATUS = string.Empty;

        private int _fk_mission_id = 0;
        private int _request_type = 0;


        /**
         * Custom Food Added here
         * */
        private object _brand_name = string.Empty;
        private object _serving_size = string.Empty;
        private object _calories = string.Empty;
        private object _calories_from_fat = string.Empty;
        private object _Quantity = string.Empty;
        private object _total_fat = string.Empty;
        private object _saturated_fat = string.Empty;
        private object _trans_fat = string.Empty;

        private object _cholestrol = string.Empty;
        private object _sodium = string.Empty;
        private object _potassium = string.Empty;
        private object _total_carbohydrates = string.Empty;
        private object _dietary_fiber = string.Empty;
        private object _sugars = string.Empty;
        private object _protein = string.Empty;
        private object _vitamin_A = string.Empty;
        private object _vitamin_C = string.Empty;


        private object _calcium = string.Empty;
        private object _iron = string.Empty;
        private object _thiamin = string.Empty;
        private object _riboflavin = string.Empty;
        private object _vitaminB6 = string.Empty;
        private object _vitaminB12 = string.Empty;
        private object _vitaminE = string.Empty;
        private object _folic_acid = string.Empty;

        private object _niacin = string.Empty;
        private object _magnesium = string.Empty;
        private object _phosphorus = string.Empty;
        private object _iodine = string.Empty;
        private object _zinc = string.Empty;
        private object _copper = string.Empty;
        private object _biotin = string.Empty;
        private object _pantothenic_acid = string.Empty;


        private object _vitaminD = string.Empty;


        #endregion

        #region "Data Members Properties"
        public object UFL_ID
        {
            get { return _UFL_ID; }
            set { _UFL_ID = value; }
        }
        public object ET_ID_FK
        {
            get { return _ET_ID_FK; }
            set { _ET_ID_FK = value; }
        }
        public object SR_ID_FK
        {
            get { return _SR_ID_FK; }
            set { _SR_ID_FK = value; }
        }
        public object fk_user_registration_Id
        {
            get { return _fk_user_registration_Id; }
            set { _fk_user_registration_Id = value; }
        }
        public object Search_Name
        {
            get { return _Search_Name; }
            set { _Search_Name = value; }
        }
        public object QUANTITY
        {
            get { return _QUANTITY; }
            set { _QUANTITY = value; }
        }
        public object CALORIES
        {
            get { return _CALORIES; }
            set { _CALORIES = value; }
        }
        public object FAT
        {
            get { return _FAT; }
            set { _FAT = value; }
        }
        public object CHOLESTROL
        {
            get { return _CHOLESTROL; }
            set { _CHOLESTROL = value; }
        }
        public object SODIUM
        {
            get { return _SODIUM; }
            set { _SODIUM = value; }
        }
        public object CARBOHYDRATES
        {
            get { return _CARBOHYDRATES; }
            set { _CARBOHYDRATES = value; }
        }
        public object FIBER
        {
            get { return _FIBER; }
            set { _FIBER = value; }
        }
        public object PROTIENS
        {
            get { return _PROTIENS; }
            set { _PROTIENS = value; }
        }
        public object SUGAR
        {
            get { return _SUGAR; }
            set { _SUGAR = value; }
        }
        public object UFL_DATE
        {
            get { return _UFL_DATE; }
            set { _UFL_DATE = value; }
        }

        public object UAF_ID
        {
            get { return _UAF_ID; }
            set { _UAF_ID = value; }
        }
        public object UFL_ID_FK
        {
            get { return _UFL_ID_FK; }
            set { _UFL_ID_FK = value; }
        }
        public object FOOD_NAME
        {
            get { return _FOOD_NAME; }
            set { _FOOD_NAME = value; }
        }
        public object UFA_DATE
        {
            get { return _UFA_DATE; }
            set { _UFA_DATE = value; }
        }
        public object ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public object ProcedureType
        {
            get { return _ProcedureType; }
            set { _ProcedureType = value; }
        }

        public object Product_Size
        {
            get { return _Product_Size; }
            set { _Product_Size = value; }
        }

        public object ETL_ID
        {
            get { return _ETL_ID; }
            set { _ETL_ID = value; }
        }
        public object fk_user_registration_id
        {
            get { return _fk_user_registration_id; }
            set { _fk_user_registration_id = value; }
        }
        public object ETL_DATE
        {
            get { return _ETL_DATE; }
            set { _ETL_DATE = value; }
        }
        public object EH_ID
        {
            get { return _EH_ID; }
            set { _EH_ID = value; }
        }
        public object EH_BREAKFAST
        {
            get { return _EH_BREAKFAST; }
            set { _EH_BREAKFAST = value; }
        }
        public object EH_LUNCH
        {
            get { return _EH_LUNCH; }
            set { _EH_LUNCH = value; }
        }
        public object EH_DINNER
        {
            get { return _EH_DINNER; }
            set { _EH_DINNER = value; }
        }
        public object EH_MORNINGSNACKS
        {
            get { return _EH_MORNINGSNACKS; }
            set { _EH_MORNINGSNACKS = value; }
        }
        public object EH_EVENINGSNACKS
        {
            get { return _EH_EVENINGSNACKS; }
            set { _EH_EVENINGSNACKS = value; }
        }
        public object EH_UNCLASSIFIED
        {
            get { return _EH_UNCLASSIFIED; }
            set { _EH_UNCLASSIFIED = value; }
        }

        public object EH_BREAKFAST_TIME
        {
            get { return _EH_BREAKFAST_TIME; }
            set { _EH_BREAKFAST_TIME = value; }
        }
        public object EH_LUNCH_TIME
        {
            get { return _EH_LUNCH_TIME; }
            set { _EH_LUNCH_TIME = value; }
        }
        public object EH_DINNER_TIME
        {
            get { return _EH_DINNER_TIME; }
            set { _EH_DINNER_TIME = value; }
        }
        public object EH_MORNSNACKS_TIME
        {
            get { return _EH_MORNSNACKS_TIME; }
            set { _EH_MORNSNACKS_TIME = value; }
        }
        public object EH_EVENSNACKS_TIME
        {
            get { return _EH_EVENSNACKS_TIME; }
            set { _EH_EVENSNACKS_TIME = value; }
        }

        public object EH_UNCLASSIFIED_TIME
        {
            get { return _EH_UNCLASSIFIED_TIME; }
            set { _EH_UNCLASSIFIED_TIME = value; }
        }


        public object presenttime
        {
            get { return _presenttime; }
            set { _presenttime = value; }
        }



        public object ES_ID
        {
            get { return _ES_ID; }
            set { _ES_ID = value; }
        }

        public object ES_DATE
        {
            get { return _ES_DATE; }
            set { _ES_DATE = value; }
        }

        public object ES_STATUS
        {
            get { return _ES_STATUS; }
            set { _ES_STATUS = value; }
        }




        public int Fk_MissionId
        {
            get { return _fk_mission_id; }
            set { _fk_mission_id = value; }
        }

        public int RequestType
        {
            get { return _request_type; }
            set { _request_type = value; }
        }

        #endregion


        #region custom food added here


        public object Brand_name
        {
            get { return _brand_name; }
            set { _brand_name = value; }
        }
        public object Serving_size
        {
            get { return _serving_size; }
            set { _serving_size = value; }
        }
        public object CaloriesCustom
        {
            get { return _calories; }
            set { _calories = value; }
        }
        public object CaloriesFromFat
        {
            get { return _calories_from_fat; }
            set { _calories_from_fat = value; }
        }
        public object Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public object TotalFat
        {
            get { return _total_fat; }
            set { _total_fat = value; }
        }



        public object SaturatedFat
        {
            get { return _saturated_fat; }
            set { _saturated_fat = value; }
        }
        public object TransFat
        {
            get { return _trans_fat; }
            set { _trans_fat = value; }
        }
        public object Cholestrol
        {
            get { return _cholestrol; }
            set { _cholestrol = value; }
        }
        public object Sodium
        {
            get { return _sodium; }
            set { _sodium = value; }
        }
        public object Potassium
        {
            get { return _potassium; }
            set { _potassium = value; }
        }




        public object TotalCarbohydrates
        {
            get { return _total_carbohydrates; }
            set { _total_carbohydrates = value; }
        }
        public object DietaryFiber
        {
            get { return _dietary_fiber; }
            set { _dietary_fiber = value; }
        }
        public object Sugars
        {
            get { return _sugars; }
            set { _sugars = value; }
        }
        public object Protein
        {
            get { return _protein; }
            set { _protein = value; }
        }
        public object Vitamin_A
        {
            get { return _vitamin_A; }
            set { _vitamin_A = value; }
        }
        public object Vitamin_C
        {
            get { return _vitamin_C; }
            set { _vitamin_C = value; }
        }




        public object Calcium
        {
            get { return _calcium; }
            set { _calcium = value; }
        }
        public object Iron
        {
            get { return _iron; }
            set { _iron = value; }
        }

        public object Thiamin
        {
            get { return _thiamin; }
            set { _thiamin = value; }
        }





        public object Riboflavin
        {
            get { return _riboflavin; }
            set { _riboflavin = value; }
        }
        public object VitaminB6
        {
            get { return _vitaminB6; }
            set { _vitaminB6 = value; }
        }
        public object VitaminB12
        {
            get { return _vitaminB12; }
            set { _vitaminB12 = value; }
        }
        public object VitaminE
        {
            get { return _vitaminE; }
            set { _vitaminE = value; }
        }





        public object FolicAcid
        {
            get { return _folic_acid; }
            set { _folic_acid = value; }
        }
        public object Niacin
        {
            get { return _niacin; }
            set { _niacin = value; }
        }
        public object Magnesium
        {
            get { return _magnesium; }
            set { _magnesium = value; }
        }
        public object Phosphorus
        {
            get { return _phosphorus; }
            set { _phosphorus = value; }
        }

        public object Iodine
        {
            get { return _iodine; }
            set { _iodine = value; }
        }


        public object Zinc
        {
            get { return _zinc; }
            set { _zinc = value; }
        }
        public object Copper
        {
            get { return _copper; }
            set { _copper = value; }
        }
        public object Biotin
        {
            get { return _biotin; }
            set { _biotin = value; }
        }
        public object Pantothenic
        {
            get { return _pantothenic_acid; }
            set { _pantothenic_acid = value; }
        }
        public object VitaminD
        {
            get { return _vitaminD; }
            set { _vitaminD = value; }
        }



        #endregion
    }
}
