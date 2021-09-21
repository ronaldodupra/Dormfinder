using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DormFinder.Web.Core.Configuration;
using DormFinder.Web.Core.Emails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DormFinder.Web
{
    public static class EmailServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new EmailConfiguration(configuration);

            services.AddScoped<IEmailSender>(serviceProvider =>
            {
                switch (config.Type)
                {
                    case "ses":
                        return new SESEmailSender(config.SesSender);

                    case "smtp":
                        return new SmtpEmailSender(
                            config.SmtpHost,
                            config.SmtpPort,
                            config.SmtpSender,
                            config.SmtpPassword,
                            config.SmtpDisplayName);

                    case "file":
                        return new FileEmailSender(config.FileDirectory);

                    case "null":
                        return new NullEmailSender();

                    default:
                        throw new Exception();
                }
            });

            services.AddScoped<EmailService>();

            return services;
        }
    }
}
