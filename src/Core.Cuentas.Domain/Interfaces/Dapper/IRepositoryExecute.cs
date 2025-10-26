using Core.Cuentas.Domain.Common.Dapper;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
    public interface IRepositoryExecute<TDomainEntity> where TDomainEntity : EntityExecuteText
  {
    Task<int> ExecuteQueryIntReturn(TDomainEntity entity, int? commandTimeout = null, object param = null);
  }
}
