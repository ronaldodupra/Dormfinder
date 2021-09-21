using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Models.Response
{
    public class SignupResponse
    {
        public SignupResponse(string token, string userName, string email)
        {
            Token = token;
            UserName = userName;
            Email = email;
        }

        public string Token { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }
    }
}
