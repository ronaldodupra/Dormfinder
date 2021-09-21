using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DormFinder.Web.Auth;
using DormFinder.Web.Data;
using DormFinder.Web.Data.Configuration;
using DormFinder.Web.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DormFinder.Web
{
    public static class AuthenticationServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthenticationService(this IServiceCollection services, JwtConfiguration configuration)
        {
            services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<DormFinderContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
                {
                    //Set default Authentication Schema as Bearer
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    //options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration.Issuer,
                        ValidAudience = configuration.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Key)),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                })
                .AddFacebook(option =>
                {
                    // TODO: Move this to appsettings
                    option.AppId = "1270399699963917";
                    option.AppSecret = "b307038c38f0f4086c8fc3a244470604";
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "404550900242-birfkuiro19jsquv21k6u0kd8qtfpn6s.apps.googleusercontent.com";
                    options.ClientSecret = "v6tntm7wc-Bzit_wqO7Pf4O-";
                });

            services.AddAuthorization();

            services.AddSingleton<IAuthorizationPolicyProvider, AdminOnlyPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, AdminOnlyHandler>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            return services;
        }
    }
}
