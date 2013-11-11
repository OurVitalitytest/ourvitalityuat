using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAO.Admin
{
  public   class AdminFoodCategoryBAO
  {
      #region "Data Members"
      private object _CAT_ID = string.Empty;
      private object _CAT_NAME = string.Empty;
      private object _CAT_IMAGE = string.Empty;
      private object _CAT_DATE = string.Empty;
      private object _CAT_DESCRIPTION = string.Empty;
      private object _SUBCAT1_ID = string.Empty;
      private object _CAT_ID_FK = string.Empty;
      private object _SUBCAT1_NAME = string.Empty;
      private object _SUBCAT1_IMAGE = string.Empty;
      private object _SUBCAT1_DATE = string.Empty;
      private object _SUBCAT1_DESCRIPTION = string.Empty;
      private object _SUBCAT2_ID = string.Empty;
      private object _SUBCAT1_ID_FK = string.Empty;
      private object _SUBCAT2_NAME = string.Empty;
      private object _SUBCAT2_IMAGE = string.Empty;
      private object _SUBCAT2_DATE = string.Empty;
      private object _SUBCAT2_DESCRIPTION = string.Empty;
      private object _ID= string.Empty;
      private object _ProcedureType = string.Empty;
      #endregion

      #region "Data Members Properties"
      public object CAT_ID
      {
          get { return _CAT_ID; }
          set { _CAT_ID = value; }
      }
      public object CAT_NAME
      {
          get { return _CAT_NAME; }
          set { _CAT_NAME = value; }
      }
      public object CAT_IMAGE
      {
          get { return _CAT_IMAGE; }
          set { _CAT_IMAGE = value; }
      }
      public object CAT_DATE
      {
          get { return _CAT_DATE; }
          set { _CAT_DATE = value; }
      }
      public object CAT_DESCRIPTION
      {
          get { return _CAT_DESCRIPTION; }
          set { _CAT_DESCRIPTION = value; }
      }
      public object SUBCAT1_ID
      {
          get { return _SUBCAT1_ID; }
          set { _SUBCAT1_ID = value; }
      }
      public object CAT_ID_FK 
      {
          get { return _CAT_ID_FK; }
          set { _CAT_ID_FK = value; }
      }
      public object SUBCAT1_NAME
      {
          get { return _SUBCAT1_NAME; }
          set { _SUBCAT1_NAME = value; }
      }
      public object SUBCAT1_IMAGE
      {
          get { return _SUBCAT1_IMAGE; }
          set { _SUBCAT1_IMAGE = value; }
      }
      public object SUBCAT1_DATE
      {
          get { return _SUBCAT1_DATE; }
          set { _SUBCAT1_DATE = value; }
      }
      public object SUBCAT1_DESCRIPTION
      {
          get { return _SUBCAT1_DESCRIPTION; }
          set { _SUBCAT1_DESCRIPTION = value; }
      }
      public object SUBCAT2_ID
      {
          get { return _SUBCAT2_ID; }
          set { _SUBCAT2_ID = value; }
      }
      public object SUBCAT1_ID_FK
      {
          get { return _SUBCAT1_ID_FK; }
          set { _SUBCAT1_ID_FK = value; }
      }
      public object SUBCAT2_NAME
      {
          get { return _SUBCAT2_NAME; }
          set { _SUBCAT2_NAME = value; }
      }
      public object SUBCAT2_IMAGE
      {
          get { return _SUBCAT2_IMAGE; }
          set { _SUBCAT2_IMAGE = value; }
      }
      public object SUBCAT2_DATE
      {
          get { return _SUBCAT2_DATE; }
          set { _SUBCAT2_DATE = value; }
      }
      public object SUBCAT2_DESCRIPTION
      {
          get { return _SUBCAT2_DESCRIPTION; }
          set { _SUBCAT2_DESCRIPTION = value; }
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
      #endregion
  }
}
