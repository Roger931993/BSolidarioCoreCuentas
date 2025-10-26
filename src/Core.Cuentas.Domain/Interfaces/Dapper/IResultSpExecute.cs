using Dapper;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IResultSpExecute
  {
    int ResultSp { get; }
    DynamicParameters Parameters { get; }
    void SetResultSp(int value);
    void SetParameters(DynamicParameters value);
  }
}
