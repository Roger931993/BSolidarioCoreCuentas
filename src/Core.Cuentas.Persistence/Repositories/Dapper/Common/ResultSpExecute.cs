using Core.Cuentas.Domain.Interfaces.Dapper;
using Dapper;

namespace Core.Cuentas.Persistence.Repositories.Dapper.Common
{
    public class ResultSpExecute : IResultSpExecute
  {
    public int ResultSp { get; private set; }
    public DynamicParameters Parameters { get; private set; }
    public void SetResultSp(int value)
    {
      ResultSp = value;
    }
    public void SetParameters(DynamicParameters value)
    {
      Parameters = value;
    }
  }
}
