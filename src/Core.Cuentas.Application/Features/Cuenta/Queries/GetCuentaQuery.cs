using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using MediatR;

namespace Core.Cuentas.Application.Features.Cuenta.Queries
{
    public record GetCuentaQuery(RequestBase<GetCuentaRequest> request) : IRequest<ResponseBase<GetCuentaResponse>>;

    public class GetCuentaRequest
    {
        public int? cuenta_id { get; set; }
        public int? cliente_id { get; set; }

        public TypeGetCuenta TypeGetCuenta { get; set; }
    }

    public class GetCuentaResponse
    {
        public List<cuentaDto>? cuenta { get; set; }
    }

    public enum TypeGetCuenta
    {
        None,
        ById,        
        ByCliente
    }
}
