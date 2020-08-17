using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AGAT.LocoDispatcher.Business.Classes;
using AGAT.LocoDispatcher.Business.Classes.Managers;
using Microsoft.Extensions.Logging;

namespace AGAT.LocoDispatcher.Web
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200", "http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader());
            });
            //services.AddSignalR(options =>
            //{
            //    options.EnableDetailedErrors = true;
            //});
            //services.AddControllers(options => 
            //{
            //    options.EnableEndpoints = true;
            //});
            services.AddMvc();
            services.AddSwaggerService();
            services.AddTransient<RailsManager>();
            services.AddTransient<RoutesManager>();
            services.AddTransient<PointManager>();
            services.AddTransient<CarriageManager>();
            services.AddTransient<AssignmentManager>();
        }

       public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            ConnectionFacade.SetConnectionString(
                _configuration.GetConnectionString("MySqliteDatabase"), 
                _configuration.GetConnectionString("AsusDatabase"));
            app.UseSwaggerService();   
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(route =>
            //{
            //    route.MapHub<ConnectionHub>("/chat");
            //    route.MapControllers();

            //});
        }

    }
}
