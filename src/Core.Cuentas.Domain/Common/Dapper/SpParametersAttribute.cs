using System.Data;

namespace Core.Cuentas.Domain.Common.Dapper
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class SpParametersAttribute : Attribute
  {
    public string ParamName { get; }
    public DbType DbType { get; }
    public ParameterDirection Direction { get; }
    public SpParametersAttribute(string paramName, DbType dbType, ParameterDirection direction)
    {
      ParamName = paramName;
      DbType = dbType;
      Direction = direction;
    }
  }
}
