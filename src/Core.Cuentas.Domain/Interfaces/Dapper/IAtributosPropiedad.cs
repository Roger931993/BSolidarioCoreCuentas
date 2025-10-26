using System.Data;

namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IAtributosPropiedad
  {
    string NombreCampo { get; }
    string TipoDato { get; }
    bool PrimaryKey { get; }
    bool ForeingKey { get; }
    string NombreCampoClase { get; }
    object ValueCampo { get; set; }
    DbType? DbValueType { get; }
    string CustomDbType { get; }
    ParameterDirection? Direction { get; }
  }
}
