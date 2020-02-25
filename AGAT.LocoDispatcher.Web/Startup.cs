using AGAT.LocoDispatcher.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace AGAT.LocoDispatcher.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => 
            {
                options.EnableEndpointRouting = true;
            });
            services.AddSingleton<TestDI, TestDI>();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(route =>
            {
                route.MapControllers();
            });
            app.Map("/test", Test);
        }

        private void Test(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                TestDI test = context.RequestServices.GetService<TestDI>();
                await context.Response.WriteAsync(test.Make().ToString());
            });
        }
    }
}
