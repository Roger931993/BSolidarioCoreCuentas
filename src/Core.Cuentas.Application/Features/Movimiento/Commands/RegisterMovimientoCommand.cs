using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using MediatR;

namespace Core.Cuentas.Application.Features.Movimiento.Commands
{
    public class RegisterMovimientoCommand : RequestBase<RegisterMovimientoRequest>, IRequest<ResponseBase<RegisterMovimientoResponse>>
    {
    }

    public class RegisterMovimientoRequest
    {
        public int? movimiento_id { get; set; }
        public int? cuenta_id { get; set; }
        public DateTime fecha_hora { get; set; }
        public string? tipo_movimiento { get; set; }
        public decimal? monto { get; set; }
        public string? naturaleza { get; set; }
        public decimal? saldo_resultante { get; set; }
        public string? motivo { get; set; }
        public string? referencia { get; set; }
        public string? estado_movimiento { get; set; }
        public int? estado { get; set; }
    }

    public class RegisterMovimientoResponse
    {
        public cuentaDto? cuenta { get; set; }
    }
}
