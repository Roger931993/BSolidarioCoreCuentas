using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Persistence.Contexts;
using Core.Cuentas.Persistence.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Cuentas.Persistence.Extensions
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddEFService(this IServiceCollection services, IConfiguration configuration)
        {
            #region SQL
            // Configura la conexión a la base de datos.
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Cuentas"));
            });
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Logs"));
            });
            #endregion
          

            // Configura la conexión a la base de datos.
            services.AddScoped<ICuentaRespository, CuentaRespository>();
            services.AddTransient<ILoggRepository, LoggRepository>();


            return services;
        }
    }
}
