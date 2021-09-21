using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }

        public static LoginException CredentialsMismatch() =>
            new LoginException("CredentialsMismatch");

        public static LoginException AccountDeactivated() =>
            new LoginException("AccountDeactivated");
    }
}
