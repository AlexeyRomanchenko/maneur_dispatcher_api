using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AGAT.LocoDispatcher.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestDI, TestDI>();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
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
