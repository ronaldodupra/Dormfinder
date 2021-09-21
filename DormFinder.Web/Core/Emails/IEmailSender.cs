using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormFinder.Web.Core.Emails
{
    public interface IEmailSender
    {
        Task Send(Email email);
    }
}
