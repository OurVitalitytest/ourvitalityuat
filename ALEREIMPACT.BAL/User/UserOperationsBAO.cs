using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALEREIMPACT.BAO
{
    public class UserOperationsBAO
    {
        private string login_with_email = string.Empty;
        private string login_with_password = string.Empty;

        public string LoginWithEmail
        {
            get { return login_with_email; }
            set { login_with_email = value; }
        }
        public string LoginWithPassword
        {
            get { return login_with_password; }
            set { login_with_password = value; }
        }
    }
}
