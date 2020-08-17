using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

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

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>()
            .UseKestrel(options =>
            {
                options.Limits.MaxConcurrentConnections = 100;
                options.Limits.MaxRequestBodySize = 10 * 1024;
                options.Listen(IPAddress.Loopback, 5000);
            })
            ;
    }
}