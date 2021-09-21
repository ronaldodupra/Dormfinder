using DormFinder.Web.Core.Hashids;
using DormFinder.Web.Data.Configuration;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DormFinder.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new HashidsJsonConverter());
                });

            services.AddAuthenticationService(new JwtConfiguration(Configuration));
            services.AddDatabase(Configuration);
            services.AddMemoryCache();
            services.AddDomainServices();
            services.AddFilesystem(Configuration);
            services.AddHangfireService(Configuration);
            services.AddEmailService(Configuration);
            services.AddAutoMapper();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseReDoc(a => a.SpecUrl = "/swagger/v1/swagger.json");
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Only redirect to front-end assets if request url doesn't start with "/api"
            app.MapWhen(
                x => !x.Request.Path.Value.StartsWith("/api"),
                builder => builder.UseSpa(spa => { }));

            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
