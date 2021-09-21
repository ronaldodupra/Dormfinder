using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Models
{
    public class ForgotPasswordModel
    {
        public string Inviter { get; set; }

        public string FullName { get; set; }

        public string Organization { get; set; }

        public string Url { get; set; }

        public string Token { get; set; }
    }
}
