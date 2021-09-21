using System;
using System.Linq;
using DormFinder.Web.Data;
using DormFinder.Web.Data.Seed;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DormFinder.Web.FunctionalTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
            {
                services
                    .AddAuthentication(opts =>
                    {
                        opts.DefaultAuthenticateScheme = TestAuthHandler.TestScheme;
                        opts.DefaultChallengeScheme = TestAuthHandler.TestScheme;
                    })
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(TestAuthHandler.TestScheme, null);

                ReplaceDbContextWithTesting(services);
                SeedDatabase(services);
            });
        }

        private void ReplaceDbContextWithTesting(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                t => t.ServiceType == typeof(DbContextOptions<DormFinderContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<DormFinderContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbTesting");
            });
        }

        private void SeedDatabase(IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();

            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<DormFinderContext>();
            var logger = scopedServices
                .GetRequiredService<ILogger<CustomWebApplicationFactory>>();

            context.Database.EnsureCreated();

            try
            {
                new DormFinderContextSeed().Seed(context).Wait();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the " +
                    "database with test messages. Error: {Message}", ex.Message);
            }
        }
    }
}
