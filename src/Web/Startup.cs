using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using hshmedstats.Persistence;
using hshmedstats.Application;
using hshmedstats.Application.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using hshmedstats.Application.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace hshmedstats.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _Environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
            

            services.AddCore();
            
       
            services.AddAutoMapper(typeof(PatientProfile), typeof(hshmedstats.Application.DependacyInjection));
            services.AddHttpContextAccessor();
            services.AddControllersWithViews(options =>
            {
                options.MaxModelBindingCollectionSize = int.MaxValue;
            }).AddRazorRuntimeCompilation();


            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
               {
                   var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                   if (_Environment.IsDevelopment())
                   {
                       opt.RequireHttpsMetadata = false;
                   }
                   opt.SaveToken = true;
                   opt.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                   };
               });

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory scopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
                endpoints.MapControllerRoute(
                    name: "PriceCatalogue",
                    pattern: "{controller}/{action}/{currency:int}/{dealtype:int}");
            });
        }
    }
}
