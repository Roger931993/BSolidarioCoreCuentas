using Dapper;
using System.Data;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IResultSpExecuteDataTable
  {
    void SetResultSp(DataTable value);
    void SetParameters(DynamicParameters value);
  }
}
