using System.Threading.Tasks;
using DormFinder.Web.Core.Emails;
using DormFinder.Web.Core.View;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Services;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace DormFinder.Web.Services
{
    public class InvitationService
    {
        private readonly ViewRenderService _renderService;
        private readonly UserTokenService _tokenService;
        private readonly IConfiguration _configuration;

        public InvitationService(
            ViewRenderService renderService,
            UserTokenService tokenService,
            IConfiguration configuration)
        {
            _renderService = renderService;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task Invite(User user, string role, string organization)
        {
            var token = _tokenService.CreateInvitationToken(user, role, organization);

            var domain = _configuration["App:Domain"];

            var model = new InviteUserModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Organization = organization,
                Url = $"{domain}/verify?token={token}"
            };

            var content = await _renderService.RenderHtmlAsync("Emails/Invite", model);

            var email = new Email("Email Verification for DormFinder", user.Email);
            email.Html = content;

            BackgroundJob.Enqueue<EmailService>(sender => sender.Send(email));
        }

        public async Task Forgot(User user, string organization)
        {
            var token = _tokenService.CreateResetPasswordToken(user);

            var domain = _configuration["App:Domain"];

            var model = new ForgotPasswordModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Organization = organization,
                Url = $"{domain}/account/reset-password?token={token}"
            };

            var content = await _renderService.RenderHtmlAsync("Emails/ForgotPassword", model);

            var email = new Email("NotiSphere account reset password request", user.Email);
            email.Html = content;

            BackgroundJob.Enqueue<EmailService>(sender => sender.Send(email));
        }
    }
}
