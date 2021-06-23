using Microsoft.Extensions.DependencyInjection;
using ProvaPratica.Application.Interfaces.Repositories;
using ProvaPratica.Application.Interfaces.Services;
using ProvaPratica.Application.Repositories;
using ProvaPratica.Application.Services;

namespace ProvaPratica.Application.Configurations
{
    public static class DependencyInjectionConfiguration
    {        
        public static IServiceCollection ConfigureDependency(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddTransient<IConvenioService, ConvenioService>();
            services.AddTransient<IConvenioRepository, ConvenioRepository>();

            return services;
        }
    }
}
