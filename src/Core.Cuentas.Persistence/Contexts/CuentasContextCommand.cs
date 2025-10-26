using Core.Cuentas.Domain.Interfaces.Dapper;
using Core.Cuentas.Persistence.Repositories.Dapper.Common;

namespace Core.Cuentas.Persistence.Contexts
{
    public class CuentasContextCommand : DbContextDapperCommon
    {
        public CuentasContextCommand(IDatabaseConnect options) : base(options.GetConnection("Cuentas"))
        {
        }
    }
}
