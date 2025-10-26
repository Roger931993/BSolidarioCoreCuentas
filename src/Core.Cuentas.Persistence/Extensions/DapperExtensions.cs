using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Domain.Interfaces.Dapper;
using Core.Cuentas.Persistence.Contexts;
using Core.Cuentas.Persistence.Repositories.Dapper;
using Core.Cuentas.Persistence.Repositories.Dapper.Common;
using Marken.DataAccess.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Cuentas.Persistence.Extensions
{
    public static class DapperExtensions
    {
        public static IServiceCollection AddDapperService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseConnect, DatabaseConnectSql>();
            services.AddScoped(typeof(IRepositoryCommand<>), typeof(RepositoryCommand<>));
            services.AddScoped(typeof(IRepositoryProcedures<>), typeof(RepositoryProcedures<>));
            services.AddScoped(typeof(IRepositoryExecute<>), typeof(RepositoryExecute<>));

            services.AddDbContextDapper<CuentasContextCommand>(options => options.ConnectionString = configuration.GetConnectionString("Cuentas")!);
            services.AddScoped(typeof(IUnitOfWorkStamp), typeof(UnitOfWorkCuentas));           


            return services;
        }

        public static IServiceCollection AddDbContextDapper<TContext>(this IServiceCollection services, Action<DbContextDapperOptions> optionAction, ServiceLifetime contextLifeTime = ServiceLifetime.Scoped, ServiceLifetime optionLifeTime = ServiceLifetime.Scoped) where TContext : class, IDbContextDapperCommon
        {
            if (optionAction == null)
            {
                throw new ArgumentNullException("optionsAction");
            }
            DbContextDapperOptions options = new DbContextDapperOptions();
            optionAction(options);
            if (string.IsNullOrEmpty(options.ConnectionString))
            {
                throw new ArgumentException("Connectionstring is empty");
            }

            services.Add(new ServiceDescriptor(typeof(TContext), typeof(TContext), contextLifeTime));
            services.Add(new ServiceDescriptor(typeof(DbContextDapperOptions), (IServiceProvider provider) => options, optionLifeTime));
            return services;
        }
    }
}
