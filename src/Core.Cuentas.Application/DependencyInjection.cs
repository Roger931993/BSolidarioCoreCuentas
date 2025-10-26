using Core.Cuentas.Application.Common;
using Core.Cuentas.Application.Interfaces;
using Core.Cuentas.Application.Interfaces.Base;
using Core.Cuentas.Application.Mappings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Cuentas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApplicationMappingProfile));

            services.AddScoped<IErrorCatalogException, ErrorCatalogException>();

            services.AddMediatR(gfc => gfc.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<IPermissionService, PermissionService>();

            return services;
        }
    }
}
