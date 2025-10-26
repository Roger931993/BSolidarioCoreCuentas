using Dapper;
using System.Data;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IResultSpExecuteDataSet
  {
    DataSet ResultSp { get; }
    DynamicParameters Parameters { get; }
    void SetResultSp(DataSet value);
    void SetParameters(DynamicParameters value);
  }
}
