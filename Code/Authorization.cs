using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace DataScrambler.Code
{
    class Authorization
    { 
        public Authorization()
        {

        }

        [DllImport("advapi32.dll")]
        public static extern int LogonUser(String _UserName,
            String _Domain,
            String _Password,
            int _LogonType,
            int _LogonProvider,
            ref IntPtr _phToken);

        public static bool Authenticate(string _user, string _pswd, string _domain)
        {
            IntPtr token = IntPtr.Zero;
            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_INTERACTIVE = 2;

            if (LogonUser(_user, _domain, _pswd, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                return true;
            }
            else
            {
                throw (new Exception("Login Failed."));
            }
        }
    }
}
