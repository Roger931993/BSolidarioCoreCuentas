using Core.Cuentas.Domain.Common.Dapper;
using Core.Cuentas.Domain.Interfaces.Dapper;

namespace Core.Cuentas.Persistence.Repositories.Dapper.Common
{
    public class RepositoryExecute<TDomainEntity> : IRepositoryExecute<TDomainEntity> where TDomainEntity : EntityExecuteText
  {
    public readonly DbContextDapperCommon _context;
    public RepositoryExecute(DbContextDapperCommon context)
    {
      _context = context;
    }
    public async Task<int> ExecuteQueryIntReturn(TDomainEntity entity, int? commandTimeout = null, object param = null)
    {
      return await _context.ExcecuteQueryTextReturnIntAsync(entity.SqlText, commandTimeout, param);
    }
  }
}
