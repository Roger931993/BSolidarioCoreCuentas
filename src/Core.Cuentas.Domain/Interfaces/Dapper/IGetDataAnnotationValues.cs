namespace Core.Cuentas.Domain.Interfaces.Dapper
{
  public interface IGetDataAnnotationValues<TEntidad> : IAtributoEntidad where TEntidad : class
  {
    bool HasDataEntity { get; }
    string ErrorMessageRecoverDataValues { get; }
    void GetDataAnnotationValues();
    void GetSpDataAnnotationValues();
  }
}
