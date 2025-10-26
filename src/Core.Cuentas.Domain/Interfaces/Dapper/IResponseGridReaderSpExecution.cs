using Core.Cuentas.Domain.Common.Dapper;
using Dapper;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
    public interface IResponseGridReaderSpExecution<TDomainResponse> where TDomainResponse : EntitySp
  {
    TDomainResponse EntityDomainResponse { get; }
    SqlMapper.GridReader GridReaderResult { get; }
    void SetGridReader(SqlMapper.GridReader dataset);
    void SetEntity(TDomainResponse entity);
  }
}
