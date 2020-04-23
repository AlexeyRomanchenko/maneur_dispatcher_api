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
using AGAT.LocoDispatcher.Business.Classes.Managers;
using Microsoft.OpenApi.Models;

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
            services.AddCors();
            services.AddControllers(options => 
            {
                options.EnableEndpointRouting = true;
            });
            services.AddSwaggerGen(e=> 
            {
                e.SwaggerDoc("v2", new OpenApiInfo {Title= "Back end documentation API", Version = "v2" });
            });
            services.AddTransient<RailsManager>();
            services.AddTransient<RoutesManager>();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            string ConnectionString = _configuration.GetConnectionString("MySqliteDatabase");
            string basicConnectionString = _configuration.GetConnectionString("AsusDatabase");
            ConnectionFacade.SetConnectionString(ConnectionString);
            app.UseSwagger();
            app.UseSwaggerUI(e=> {
                e.SwaggerEndpoint("/swagger/v2/swagger.json", "Back end documentation API");
                e.RoutePrefix = "docs";
            });           
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseAuthorization();
            app.UseEndpoints(route =>
            {
                route.MapControllers();
            });
        }

    }
}
