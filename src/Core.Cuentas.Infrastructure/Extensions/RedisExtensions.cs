using Core.Cuentas.Application.Interfaces.Infraestructure;
using Core.Cuentas.Infrastructure.Caching.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Cuentas.Infrastructure.Extensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("Redis").GetValue<string>("ConnectionString");
            });
            services.AddTransient<IRedisCache, RedisCache>();

            return services;
        }
    }
}
