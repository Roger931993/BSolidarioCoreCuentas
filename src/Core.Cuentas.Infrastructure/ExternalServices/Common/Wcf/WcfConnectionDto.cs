namespace Core.Cuentas.Infrastructure.ExternalServices.Common.Wcf
{
  public class WcfConnectionDto
  {
    public Dictionary<string, IWcfUrl>? Values { get; set; }
    public WcfConnectionDto(Dictionary<string, IWcfUrl>? values)
    {
      Values = values;
    }    
  }
}
