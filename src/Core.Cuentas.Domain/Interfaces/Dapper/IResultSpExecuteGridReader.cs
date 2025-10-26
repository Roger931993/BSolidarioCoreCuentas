using Dapper;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IResultSpExecuteGridReader
  {
    SqlMapper.GridReader ResultSp { get; }
    DynamicParameters Parameters { get; }
    void SetResultSp(SqlMapper.GridReader value);
    void SetParameters(DynamicParameters value);
  }
}
