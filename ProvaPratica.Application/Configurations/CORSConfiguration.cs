using Microsoft.Extensions.DependencyInjection;

namespace ProvaPratica.Application.Configurations
{
    public static class CORSConfiguration
    {
        public static IServiceCollection ConfigureCORS(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("AllowCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

            });
            return serviceCollection;
        }
    }
}
