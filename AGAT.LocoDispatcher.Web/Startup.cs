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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader());
            });
            services.AddControllers(options => 
            {
                options.EnableEndpointRouting = true;
            });
            services.AddSwaggerService();
            services.AddTransient<RailsManager>();
            services.AddTransient<RoutesManager>();
            services.AddTransient<PointManager>();
        }

       public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation($"Started Configure with is Production mode:{env.IsProduction()}");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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
            app.UseEndpoints(route =>
            {
                route.MapControllers();
            });
        }

    }
}
