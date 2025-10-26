using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Domain.Interfaces.Dapper;
using Core.Cuentas.Persistence.Contexts;
using Core.Cuentas.Persistence.Repositories.Dapper.Common;

namespace Core.Cuentas.Persistence.Repositories.Dapper
{
    public class UnitOfWorkCuentas : UnitOfWork, IUnitOfWorkStamp
    {
        private readonly IDatabaseConnect _options;
        public UnitOfWorkCuentas(CuentasContextCommand contextDapper, IDatabaseConnect options) : base(contextDapper)
        {
            _options = options;
        }
    }
}
