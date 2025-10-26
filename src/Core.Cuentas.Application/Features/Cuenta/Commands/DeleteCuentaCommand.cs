using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cuentas.Application.Features.Cuenta.Commands
{
    public class DeleteCuentaCommand : RequestBase<DeleteCuentaRequest>, IRequest<ResponseBase<DeleteCuentaResponse>>
    {
    }

    public class DeleteCuentaRequest
    {
        public int cuenta_id { get; set; }
    }

    public class DeleteCuentaResponse
    {
        public cuentaDto? cuenta { get; set; }
    }
}
