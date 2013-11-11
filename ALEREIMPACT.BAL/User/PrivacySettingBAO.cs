using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAL.User
{
  public class PrivacySettingBAO
  {
      #region "data memebers"
      private object _UN_ID = string.Empty;
      private object _PS_ID_FK = string.Empty;
      private object _fk_user_registration_id = string.Empty;
      private object _UN_NOTIFICATION_DAILY = string.Empty;
      private object _UN_NOTIFICATION_WEEKLY = string.Empty;
      private object _UN_NOTIFICATION_MONTHLY = string.Empty;
      private object _UN_NOTIFICATION_OFF = string.Empty;

      private object _UPS_ID = string.Empty;
      private object _UPS_YOU = string.Empty;
      private object _UPS_FRIENDS = string.Empty;
      private object _UPS_ANYONE = string.Empty;
      private object _UNM_ID_FK = string.Empty;
      private object _ProcedureType = string.Empty;

      #endregion

      #region "data member properties"
      public object UN_ID
      {
          get { return _UN_ID; }
          set { _UN_ID = value; }
      }

      public object PS_ID_FK
      {
          get { return _PS_ID_FK; }
          set { _PS_ID_FK = value; }
      }
      public object fk_user_registration_id
      {
          get { return _fk_user_registration_id; }
          set { _fk_user_registration_id = value; }
      }
      public object UN_NOTIFICATION_DAILY
      {
          get { return _UN_NOTIFICATION_DAILY; }
          set { _UN_NOTIFICATION_DAILY = value; }
      }

      public object UN_NOTIFICATION_WEEKLY
      {
          get { return _UN_NOTIFICATION_WEEKLY; }
          set { _UN_NOTIFICATION_WEEKLY = value; }
      }
      public object UN_NOTIFICATION_MONTHLY
      {
          get { return _UN_NOTIFICATION_MONTHLY; }
          set { _UN_NOTIFICATION_MONTHLY = value; }
      }
      public object UN_NOTIFICATION_OFF
      {
          get { return _UN_NOTIFICATION_OFF; }
          set { _UN_NOTIFICATION_OFF = value; }
      }



      public object UPS_ID
      {
          get { return _UPS_ID; }
          set { _UPS_ID = value; }
      }
      public object UPS_YOU
      {
          get { return _UPS_YOU; }
          set { _UPS_YOU = value; }
      }
      public object UPS_FRIENDS
      {
          get { return _UPS_FRIENDS; }
          set { _UPS_FRIENDS = value; }
      }
      public object UPS_ANYONE
      {
          get { return _UPS_ANYONE; }
          set { _UPS_ANYONE = value; }
      }
      public object UNM_ID_FK
      {
          get { return _UNM_ID_FK; }
          set { _UNM_ID_FK = value; }
      }
      public object ProcedureType
      {
          get { return _ProcedureType; }
          set { _ProcedureType = value; }
      }
      #endregion
  }
}
