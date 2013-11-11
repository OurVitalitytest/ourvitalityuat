using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALEREIMPACT.FRAMEWORK;
using System.Data;
using ALEREIMPACT.BAO;

namespace ALEREIMPACT.DAO
{
    public class UserOperationDAO
    {
        public static DataSet Login(UserOperationsBAO objNewUserBao)
        {
            IList<Parameters> parameterslist = new List<Parameters>();
            SQLHelper sqlhelper = new SQLHelper();

            parameterslist.Add(new Parameters()
            {
                TextName = "@login_email",
                TextValue = objNewUserBao.LoginWithEmail.ToString()
            });
            parameterslist.Add(new Parameters()
            {
                TextName = "@login_password",
                TextValue = objNewUserBao.LoginWithPassword.ToString()
            });
            return sqlhelper.getRecordsDS("[spLoginUser]", parameterslist);
        }
    }
}
