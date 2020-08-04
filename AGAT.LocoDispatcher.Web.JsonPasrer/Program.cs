using AGAT.LocoDispatcher.Web.JsonPasrer.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AGAT.LocoDispatcher.Web.JsonPasrer
{
    public class Program
    {
        private static string loggerPath;
        public static void Main(string[] args)
        {
            loggerPath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("PathToLogger").Value;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging((context, e) => {
                        e.ClearProviders();
                        e.SetMinimumLevel(LogLevel.Information);
                        e.AddProvider(new FileLoggerProvider($"{loggerPath}\\log.txt"));
                        e.AddConsole();
                        });
                });
    }
}
