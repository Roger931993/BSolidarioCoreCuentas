using System.Data;

namespace Core.Cuentas.Domain.Common.Dapper
{
  public abstract class EntitySp
  {
    [SpParametersCommon("Retorno", DbType.Int32, ParameterDirection.ReturnValue, null)]
    public virtual int Retorno { get; protected set; } = 0;
  }
}
