using DormFinder.Web.Auth;
using DormFinder.Web.Billings.Utilities.Services;
using DormFinder.Web.Buildings.Services;
using DormFinder.Web.Charges.Services;
using DormFinder.Web.Core.View;
using DormFinder.Web.Data.Configuration;
using DormFinder.Web.Rooms.Service;
using DormFinder.Web.Services;
using DormFinder.Web.Services.Intefaces;
using DormFinder.Web.Services.Services;
using DormFinder.Web.Users.Service;
using HashidsNet;
using Microsoft.Extensions.DependencyInjection;

namespace DormFinder.Web
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            //Repositories
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IBedspaceRepository, BedspaceRepository>();
            services.AddTransient<IChargeRepository, ChargeRepository>();
            services.AddTransient<IChargeTypeRepository, ChargeTypeRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IOptionsRepository, OptionsRepository>();
            services.AddTransient<IFileEntryRepository, FileEntryRepository>();

            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<IInclusionRepository, InclusionRepository>();
            services.AddTransient<IRoomTypeRepository, RoomTypeRepository>();
            services.AddTransient<IRoomInclusionRepository, RoomInclusionRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IRoomPicRepository, RoomPicRepository>();
            services.AddTransient<ITenantRepository, TenantRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUtilityRepository, UtilityRepository>();

            services.AddTransient<IOrganizationRepository, OrganizationRepository>();

            services.AddTransient<IHomeRepository, HomeRepository>();
            services.AddTransient<IDashboardRepository, DashboardRepository>();

            services.AddTransient<IBillingPeriodRepository, BillingPeriodRepository>();

            services.AddScoped<LoginService>();
            services.AddScoped<JwtConfiguration>();
            services.AddScoped<BuildingService>();
            services.AddScoped<ChargeService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<AccountService>();
            services.AddScoped<UserTokenService>();
            services.AddScoped<TokenService>();
            services.AddScoped<UserService>();
            services.AddScoped<UtilityService>();

            services.AddScoped<RoomService>();
            services.AddScoped<GenerateDefaultImageService>();

            services.AddScoped<InvitationService>();
            services.AddScoped<InquiryService>();
            services.AddScoped<ViewRenderService>();

            services.AddScoped<BillingPeriodService>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<IHashids>(services => new Hashids("secret"));

            return services;
        }
    }
}
