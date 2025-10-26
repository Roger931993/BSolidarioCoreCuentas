using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using MediatR;

namespace Core.Cuentas.Application.Features.Cuenta.Commands
{
    public class RegisterCuentaCommand : RequestBase<RegisterCuentaRequest>, IRequest<ResponseBase<RegisterCuentaResponse>>
    {
    }

    public class RegisterCuentaRequest
    {
        public int? cuenta_id { get; set; }
        public string? numero_cuenta { get; set; }
        public int? cliente_id { get; set; }
        public int? producto_id { get; set; }
        public int? agencia_id { get; set; }
        public string? moneda { get; set; }
        public string? tipo_cuenta { get; set; }
        public DateTime? fecha_apertura { get; set; }
        public DateTime? fecha_cierre { get; set; }
        public decimal? saldo_actual { get; set; }
        public decimal? saldo_disponible { get; set; }
        public decimal? tasa_interes { get; set; }
        public DateTime? fecha_ultima_transaccion { get; set; }
        public string? usuario_creacion { get; set; }
        public int? estado { get; set; }
    }

    public class RegisterCuentaResponse
    {
        public cuentaDto? cuenta { get; set; }
    }
}
