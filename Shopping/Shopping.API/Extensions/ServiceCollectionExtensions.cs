using Microsoft.OpenApi.Models;
using Shopping.API.Data;

namespace Shopping.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });
            services.AddScoped<ProductContext>();
        }
    }
}
