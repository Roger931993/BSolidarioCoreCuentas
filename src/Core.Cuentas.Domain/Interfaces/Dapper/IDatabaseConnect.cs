using System.Data;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IDatabaseConnect
  {
    IDbConnection GetConnection(string coonectionName);
  }
}
