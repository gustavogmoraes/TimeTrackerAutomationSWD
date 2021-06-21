using System.Net;
using AutomationBase.Infrastructure.Builders;
using AutomationBase.Infrastructure.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TimeTrackerAutomationSWD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChromeDriverHelper.CheckUpdateChromeDriver();
            
            var chromeDriver = new ChromeDriverBuilder()
                .AllowRunningInsecureContent()
                .DisablePopupBlocking()
                .WithLanguage(ChromeDriverLanguage.English)
                .Build();

            Runner.Driver = chromeDriver;

            // Start API
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opt => opt.Listen(IPAddress.Any, 5000));
                });
    }
}