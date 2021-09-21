using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Emails;
using DormFinder.Web.Core.View;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Models;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace DormFinder.Web.Services.Services
{
    public class InquiryService
    {
        private readonly ViewRenderService _renderService;
        private readonly IConfiguration _configuration;

        public InquiryService(ViewRenderService renderService, IConfiguration configuration)
        {
            _renderService = renderService;
            _configuration = configuration;
        }

        public async Task InquiryNotification(IEnumerable<User> users, InquiryModel inquiry)
        {
            var domain = _configuration["App:Domain"];

            var model = new InquiryModel
            {
                InquiryFullName = inquiry.InquiryFullName,
                Address = inquiry.Address,
                CreatedAt = inquiry.CreatedAt,
                BuildingName = inquiry.BuildingName,
                Email = inquiry.Email,
                Number = inquiry.Number,
                Message = inquiry.Message,
                RoomName = inquiry.RoomName
            };

            var content = await _renderService.RenderHtmlAsync("Emails/Inquiry", model);

            var email = new Email("Email Verification for DormFinder", users.Select(t => t.Email).ToList());
            email.Html = content;

            BackgroundJob.Enqueue<EmailService>(sender => sender.Send(email));
        }
    }
}
