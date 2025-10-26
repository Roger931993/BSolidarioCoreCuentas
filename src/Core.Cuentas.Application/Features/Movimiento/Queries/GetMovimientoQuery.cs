using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using MediatR;

namespace Core.Cuentas.Application.Features.Movimiento.Queries
{
    public record GetMovimientoQuery(RequestBase<GetMovimientoRequest> request) : IRequest<ResponseBase<GetMovimientoResponse>>;

    public class GetMovimientoRequest
    {
        public int? movimiento_id { get; set; }
        public int? cuenta_id { get; set; }
        public int? cliente_id { get; set; }

        public TypeGetMovimiento TypeGetMovimiento { get; set; }
    }

    public class GetMovimientoResponse
    {
        public List<movimientoDto>? movimiento { get; set; }
    }

    public enum TypeGetMovimiento
    {
        None,
        ById,        
        ByCuenta,
        ByCliente
    }
}
