using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AGAT.LocoDispatcher.Web
{
    public static class SwaggerService
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(e =>
            {
                e.SwaggerDoc("v2", new OpenApiInfo { Title = "Back end documentation API", Version = "v2" });
            });
        }

        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(e => {
                e.SwaggerEndpoint("/swagger/v2/swagger.json", "Back end documentation API");
                e.RoutePrefix = "docs";
            });
        }
    }
}
