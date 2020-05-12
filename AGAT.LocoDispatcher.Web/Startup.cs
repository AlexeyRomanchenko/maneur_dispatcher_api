using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using AGAT.LocoDispatcher.Business.Classes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            services.AddSwaggerService();
            services.AddTransient<RailsManager>();
            services.AddTransient<RoutesManager>();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"Started Configure with is Production mode:{env.IsProduction()}");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            string connectionString = "Data Source=testing.db";
            string basicConnectionString = "Data Source=192.168.111.211;User ID=web;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            ConnectionFacade.SetConnectionString(connectionString);
            app.UseSwaggerService();   
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
