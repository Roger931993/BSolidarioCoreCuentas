using Core.Cuentas.Application.Interfaces.Infraestructure;
using Core.Cuentas.Infrastructure.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Cuentas.Infrastructure.Extensions
{
    public static class MemoryExtensions
    {
        public static IServiceCollection AddMemoryCache(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurar MemoryCache
            services.AddMemoryCache();
            // Registrar tus servicios
            services.AddSingleton<IMemoryCacheLocalService, MemoryCacheLocalService>();

            return services;
        }
    }
}
