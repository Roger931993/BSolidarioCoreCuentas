using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cuentas.Application.Features.Movimiento.Commands
{
    public class DeleteMovimientoCommand : RequestBase<DeleteMovimientoRequest>, IRequest<ResponseBase<DeleteMovimientoResponse>>
    {
    }

    public class DeleteMovimientoRequest
    {
        public int movimiento_id { get; set; }
    }

    public class DeleteMovimientoResponse
    {
        public movimientoDto? movimiento { get; set; }
    }
}
