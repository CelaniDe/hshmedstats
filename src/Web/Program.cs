using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace hshmedstats.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                // For azure logging.
                .WriteTo.File(
                    @"D:\home\LogFiles\Application\myapp.txt",
                    //outputTemplate: "{Timestamp} {Message}{NewLine:1}{Exception:1}",
                    fileSizeLimitBytes: 1_000_000,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1)
                )
                .Filter.ByExcluding(c => c.Properties.Any(p => p.Value.ToString().Contains("notificationHub")
                    || p.Value.ToString().Contains("css")
                    || p.Value.ToString().Contains("lib")
                    || p.Value.ToString().Contains("fonts")
                    || p.Value.ToString().Contains("images")
                    || p.Value.ToString().Contains("js")))
                .CreateLogger();

            Log.Information("Starting Web Application");

            var host = CreateHostBuilder(args).Build();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
