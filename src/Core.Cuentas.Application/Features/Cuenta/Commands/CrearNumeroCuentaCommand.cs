using Core.Cuentas.Application.DTOs.Base;
using MediatR;

namespace Core.Cuentas.Application.Features.Cuenta.Commands
{
    public class CrearNumeroCuentaCommand : RequestBase<CrearNumeroCuentaRequest>, IRequest<ResponseBase<CrearNumeroCuentaResponse>>
    {
    }

    public class CrearNumeroCuentaRequest
    {
        public int? agencia_id { get; set; }
        public string? banco { get; set; } //123
        public int? producto_id { get; set; } //1
    }

    public class CrearNumeroCuentaResponse
    {
        public string? numero_cuenta { get; set; }
    }

}
