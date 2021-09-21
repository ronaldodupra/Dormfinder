using System.Threading.Tasks;

namespace DormFinder.Web.Core.Emails
{
    public class NullEmailSender : IEmailSender
    {
        public Task Send(Email email)
        {
            return Task.CompletedTask;
        }
    }
}
