using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using hshmedstats.Domain;
using hshmedstats.Persistence;
using hshmedstats.Application.Logging;
using System.Linq;

namespace hshmedstats.Web.Helpers
{
    public static class StartupHelper
    {
        public static async Task SeedDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                    var context = scope.ServiceProvider.GetRequiredService<HshDbContext>();

                    await DbSeed.SeedAsync(context, userManager, roleManager);
                }
                catch (Exception ex)
                {
                    Logger.LogError("Failed to seed the database");
                    Logger.LogError(ex.Message);
                }
            }
        }

        public static void InitLogger(this WebApplicationBuilder builder, bool isDevelopment = false)
        {
            var log = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration);

            if (!isDevelopment)
            {
                log.WriteTo.File(
                   @"D:\home\LogFiles\Application\myapp.txt",
                   //outputTemplate: "{Timestamp} {Message}{NewLine:1}{Exception:1}",
                   fileSizeLimitBytes: 1_000_000_00,
                   rollOnFileSizeLimit: true,
                   shared: true,
                   flushToDiskInterval: TimeSpan.FromSeconds(1));
            }
            else
            {
                log.WriteTo.Debug();
            }

            log.Filter.ByExcluding(c => c.Properties.Any(p => p.Value.ToString().Contains("css")
            || p.Value.ToString().Contains("lib")
            || p.Value.ToString().Contains("jpg")
            || p.Value.ToString().Contains("png")
            || p.Value.ToString().Contains("ico")
            || p.Value.ToString().Contains("fonts")
            || p.Value.ToString().Contains("images")
            || p.Value.ToString().Contains("js")));

            Log.Logger = log.CreateLogger();
        }
    }
}
