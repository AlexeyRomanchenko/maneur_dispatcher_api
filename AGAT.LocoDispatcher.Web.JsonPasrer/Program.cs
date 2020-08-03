using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AGAT.LocoDispatcher.Web.JsonPasrer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging((context, e) => {
                        e.ClearProviders();
                        e.SetMinimumLevel(LogLevel.Information);
                        e.AddFile(x => { x.BasePath = @"C:\json"; });
                        e.AddConsole();
                        });
                });
    }
}
