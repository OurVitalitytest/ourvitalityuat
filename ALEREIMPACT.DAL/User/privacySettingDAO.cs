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
   public class privacySettingDAO
    {


         public static Int32 InserttblUserPrivacySetting(PrivacySettingBAO objPrivacySettingBAO)
        {
            int returnValue = 0;
            try
            {

                IList<Parameters> parametersList = new List<Parameters>();
                SQLHelper sQLHelper = new SQLHelper();

                parametersList.Add(new Parameters()
                {
                    TextName = "@UPS_ID",
                    TextValue = Convert.ToInt32(objPrivacySettingBAO.UPS_ID).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@PS_ID_FK",
                    TextValue = Convert.ToInt32(objPrivacySettingBAO.PS_ID_FK).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@fk_user_registration_id",
                    TextValue = Convert.ToInt32(objPrivacySettingBAO.fk_user_registration_id).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UPS_YOU",
                    TextValue = (objPrivacySettingBAO.UPS_YOU).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UPS_FRIENDS",
                    TextValue = (objPrivacySettingBAO.UPS_FRIENDS).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@UPS_ANYONE",
                    TextValue = (objPrivacySettingBAO.UPS_ANYONE).ToString()
                });
                parametersList.Add(new Parameters()
                {
                    TextName = "@ProcedureType",
                    TextValue = (objPrivacySettingBAO.ProcedureType).ToString()
                });
                returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserPrivacySetting", parametersList);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return returnValue;
        }

         public static Int32 InserttblUserNotification(PrivacySettingBAO objPrivacySettingBAO)
         {
             int returnValue = 0;
             try
             {

                 IList<Parameters> parametersList = new List<Parameters>();
                 SQLHelper sQLHelper = new SQLHelper();

                 parametersList.Add(new Parameters()
                 {
                     TextName = "@UN_ID",
                     TextValue = Convert.ToInt32(objPrivacySettingBAO.UN_ID).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@UNM_ID_FK",
                     TextValue = Convert.ToInt32(objPrivacySettingBAO.UNM_ID_FK).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@fk_user_registration_id",
                     TextValue = Convert.ToInt32(objPrivacySettingBAO.fk_user_registration_id).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@UN_NOTIFICATION_DAILY",
                     TextValue = (objPrivacySettingBAO.UN_NOTIFICATION_DAILY).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@UN_NOTIFICATION_WEEKLY",
                     TextValue = (objPrivacySettingBAO.UN_NOTIFICATION_WEEKLY).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@UN_NOTIFICATION_MONTHLY",
                     TextValue = (objPrivacySettingBAO.UN_NOTIFICATION_MONTHLY).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@UN_NOTIFICATION_OFF",
                     TextValue = (objPrivacySettingBAO.UN_NOTIFICATION_OFF).ToString()
                 });
                 parametersList.Add(new Parameters()
                 {
                     TextName = "@ProcedureType",
                     TextValue = (objPrivacySettingBAO.ProcedureType).ToString()
                 });
                 returnValue = sQLHelper.ExecuteNonQuery("spInserttblUserNotification", parametersList);
             }
             catch (Exception ex)
             {
                 ex.ToString();
             }
             return returnValue;
         }


    }
}

