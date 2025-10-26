using Core.Cuentas.Domain.Common.Dapper;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
    public interface IUnitOfWork
  {
    IRepositoryCommand<TDomainEntity> RepositoryCommand<TDomainEntity>() where TDomainEntity : Entity;


    IRepositoryProcedures<TDomainEntity> RepositoryProcedure<TDomainEntity>() where TDomainEntity : EntitySp;
    void CommitTransaction();
    void RollBackTransaction();

    void BeginTransaccion();
  }
}
