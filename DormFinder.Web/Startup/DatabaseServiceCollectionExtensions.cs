using DormFinder.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DormFinder.Web
{
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DormFinderContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("dormfinder"));
            });

            return services;
        }
    }
}
