namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IAtributoEntidad
  {
    string Esquema { get; }
    string NombreTable { get; }
    IList<IAtributosPropiedad> ListaDetallesAtributos { get; }
  }
}
