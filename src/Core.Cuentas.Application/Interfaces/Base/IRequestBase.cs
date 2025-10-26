using Core.Cuentas.Application.DTOs.Base;

namespace Core.Cuentas.Application.Interfaces.Base
{
    public interface IRequestBase
    {
        Guid? IdTraking { get; set; }
        InfoSessionDto? InfoSession { get; set; }
    }
}
