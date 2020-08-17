using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AGAT.LocoDispatcher.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseKestrel(options =>
            {
            options.Limits.MaxConcurrentConnections = 100;
            options.Limits.MaxRequestBodySize = 10 * 1024;
            options.Listen(IPAddress.Loopback, 5000);
        })
            ;
    }
}
