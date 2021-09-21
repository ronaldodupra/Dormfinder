using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace DormFinder.Web.Core.Emails
{
    public class SESEmailSender : IEmailSender
    {
        private readonly string senderAddress;

        private readonly string configSet = "ConfigSet";

        public SESEmailSender(string senderAddress)
        {
            this.senderAddress = senderAddress;
        }

        public async Task Send(Email email)
        {
            var message = new Message()
            {
                Subject = new Content(email.Subject),
                Body = new Body()
            };

            if (!string.IsNullOrEmpty(email.Html))
            {
                message.Body.Html = new Content
                {
                    Charset = "UTF-8",
                    Data = email.Html
                };
            }

            if (!string.IsNullOrEmpty(email.Text))
            {
                message.Body.Text = new Content
                {
                    Charset = "UTF-8",
                    Data = email.Text
                };
            }

            var request = new SendEmailRequest
            {
                Source = this.senderAddress,
                Destination = new Destination
                {
                    ToAddresses = email.Recipients.ToList()
                },
                Message = message
            };

            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1))
            {
                await client.SendEmailAsync(request);
            }
        }
    }
}
