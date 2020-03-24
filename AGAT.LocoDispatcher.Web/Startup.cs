using AGAT.LocoDispatcher.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using AGAT.LocoDispatcher.Business.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Auth.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = Auth.CLIENT,
                        ValidateLifetime = true,

                        IssuerSigningKey = Auth.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddControllers(options => 
            {
                options.EnableEndpointRouting = true;
            });
            services.AddSingleton<TestDI, TestDI>();
            services.AddSingleton<RailsManager>();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            string ConnectionString = _configuration.GetConnectionString("MyDatabase");
            ConnectionFacade.SetConnectionString(ConnectionString);
            
            app.UseAuthentication();
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
