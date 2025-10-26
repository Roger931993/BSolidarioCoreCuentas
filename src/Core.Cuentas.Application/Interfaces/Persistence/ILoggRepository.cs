using Core.Cuentas.Domain.Entities;
using Core.Cuentas.Domain.Models;

namespace Core.Cuentas.Application.Interfaces.Persistence
{
    public interface ILoggRepository
    {      
        Task<api_log_cuenta_header> SaveHeader(LoggingMdl model);
        Task<List<api_log_cuenta_detail>> SaveDetails(List<api_log_cuenta_detail> model);
    }
}
