using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uwp_fitsense.dependencies;

namespace uwp_fitsense.services
{
    public sealed class LoginService : ILoginService
    {
        private static ILoginService instance;

        public static ILoginService Instance
        {
            get
            {
                if (instance == null) instance = new LoginService();
                return instance;
            }
            set { instance = value; }
        }


        private LoginService() { }

        public bool isLoggedIn()
        {
            return false;
        }
    }
}
