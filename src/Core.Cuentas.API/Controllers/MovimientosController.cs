using Core.Cuentas.API.Filters;
using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.Features.Movimiento.Commands;
using Core.Cuentas.Application.Features.Movimiento.Queries;
using Core.Cuentas.Application.Interfaces.Infraestructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.Cuentas.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : CommonController
    {
        public MovimientosController(IMediator mediator, IMemoryCacheLocalService memoryCacheLocalService, IRedisCache redisCache) : base(mediator, memoryCacheLocalService, redisCache)
        {
        }

        /// <summary>
        /// Obtener todos los movimientos
        /// </summary>
        /// <remarks>
        /// Permiso: MovimientosController-GetAllQuery
        /// <br/>
        /// Descripcion: Obtener todos los movimientos
        /// </remarks>    
        [HttpGet()]
        [Permission("MovimientosController-GetAllQuery")]
        [ProducesResponseType(typeof(GetMovimientoResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMovimientoResponse>> GetAllQuery()
        {
            RequestBase<GetMovimientoRequest> request = new RequestBase<GetMovimientoRequest>()
            {
                Request = new GetMovimientoRequest()
                {
                    TypeGetMovimiento = TypeGetMovimiento.None
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetMovimientoResponse> objResponse = await _mediator.Send(new GetMovimientoQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Obtener movimientos por id
        /// </summary>
        /// <remarks>
        /// Permiso: MovimientosController-GetById
        /// <br/>
        /// Descripcion: Obtener movimientos por id
        /// </remarks>    
        [HttpGet("id/{id}")]
        [Permission("MovimientosController-GetById")]
        [ProducesResponseType(typeof(GetMovimientoResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMovimientoResponse>> GetById(int id)
        {
            RequestBase<GetMovimientoRequest> request = new RequestBase<GetMovimientoRequest>()
            {
                Request = new GetMovimientoRequest()
                {
                    movimiento_id = id,
                    TypeGetMovimiento = TypeGetMovimiento.ById
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetMovimientoResponse> objResponse = await _mediator.Send(new GetMovimientoQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Obtener movimientos por id cuenta
        /// </summary>
        /// <remarks>
        /// Permiso: MovimientosController-GetById
        /// <br/>
        /// Descripcion: Obtener movimientos por id cuenta
        /// </remarks>    
        [HttpGet("cuenta/{id}")]
        [Permission("MovimientosController-GetByCuentaId")]
        [ProducesResponseType(typeof(GetMovimientoResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMovimientoResponse>> GetByCuentaId(int id)
        {
            RequestBase<GetMovimientoRequest> request = new RequestBase<GetMovimientoRequest>()
            {
                Request = new GetMovimientoRequest()
                {
                    cuenta_id = id,
                    TypeGetMovimiento = TypeGetMovimiento.ByCuenta
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetMovimientoResponse> objResponse = await _mediator.Send(new GetMovimientoQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Obtener movimientos por id cuenta
        /// </summary>
        /// <remarks>
        /// Permiso: MovimientosController-GetById
        /// <br/>
        /// Descripcion: Obtener movimientos por id cuenta
        /// </remarks>    
        [HttpGet("cliente/{id}")]
        [Permission("MovimientosController-GetByClienteId")]
        [ProducesResponseType(typeof(GetMovimientoResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetMovimientoResponse>> GetByClienteId(int id)
        {
            RequestBase<GetMovimientoRequest> request = new RequestBase<GetMovimientoRequest>()
            {
                Request = new GetMovimientoRequest()
                {
                    cliente_id = id,
                    TypeGetMovimiento = TypeGetMovimiento.ByCliente
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetMovimientoResponse> objResponse = await _mediator.Send(new GetMovimientoQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Registrar cliente
        /// </summary>
        /// <remarks>
        /// Permiso: MovimientosController-Register
        /// <br/>
        /// Descripcion: Registrar cliente
        /// </remarks>    
        [HttpPost("registrar")]
        [Authorize]
        [Permission("MovimientosController-Register")]
        [ProducesResponseType(typeof(RegisterMovimientoResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RegisterMovimientoResponse>> Register([FromBody] RegisterMovimientoRequest data)
        {
            RegisterMovimientoCommand command = new RegisterMovimientoCommand()
            {
                Request = data
            };
            await CreateDataCacheLocal(HttpContext, command);
            ResponseBase<RegisterMovimientoResponse> objResponse = await _mediator.Send(command);
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Eliminar cliente
        /// </summary>
        /// <remarks>
        /// Permiso: MovimientosController-Delete
        /// <br/>
        /// Descripcion: Eliminar cliente
        /// </remarks>    
        [HttpDelete("{id}")]
        [Authorize]
        [Permission("MovimientosController-Delete")]
        [ProducesResponseType(typeof(DeleteMovimientoResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DeleteMovimientoResponse>> Delete(int id)
        {
            DeleteMovimientoCommand command = new DeleteMovimientoCommand()
            {
                Request = new DeleteMovimientoRequest()
                {
                    movimiento_id = id
                }
            };
            await CreateDataCacheLocal(HttpContext, command);
            ResponseBase<DeleteMovimientoResponse> objResponse = await _mediator.Send(command);
            return OkUrban(objResponse);
        }
    }
}
