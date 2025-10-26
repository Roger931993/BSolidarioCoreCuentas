using Core.Cuentas.API.Filters;
using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.Features.Cuenta.Commands;
using Core.Cuentas.Application.Features.Cuenta.Queries;
using Core.Cuentas.Application.Interfaces.Infraestructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.Cuentas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : CommonController
    {
        public CuentasController(IMediator mediator, IMemoryCacheLocalService memoryCacheLocalService, IRedisCache redisCache) : base(mediator, memoryCacheLocalService, redisCache)
        {
        }

        /// <summary>
        /// Obtener todos los cuentas
        /// </summary>
        /// <remarks>
        /// Permiso: CuentasController-GetAllQuery
        /// <br/>
        /// Descripcion: Obtener todos los cuentas
        /// </remarks>    
        [HttpGet()]
        [Permission("CuentasController-GetAllQuery")]
        [ProducesResponseType(typeof(GetCuentaResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCuentaResponse>> GetAllQuery()
        {
            RequestBase<GetCuentaRequest> request = new RequestBase<GetCuentaRequest>()
            {
                Request = new GetCuentaRequest()
                {
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetCuentaResponse> objResponse = await _mediator.Send(new GetCuentaQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Obtener cuenta por id
        /// </summary>
        /// <remarks>
        /// Permiso: CuentasController-GetById
        /// <br/>
        /// Descripcion: Obtener cuenta por id
        /// </remarks>    
        [HttpGet("id/{id}")]
        [Permission("CuentasController-GetById")]
        [ProducesResponseType(typeof(GetCuentaResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCuentaResponse>> GetById(int id)
        {
            RequestBase<GetCuentaRequest> request = new RequestBase<GetCuentaRequest>()
            {
                Request = new GetCuentaRequest()
                {
                    cuenta_id = id,
                    TypeGetCuenta = TypeGetCuenta.ById
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetCuentaResponse> objResponse = await _mediator.Send(new GetCuentaQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Obtener cuenta por id
        /// </summary>
        /// <remarks>
        /// Permiso: CuentasController-GetById
        /// <br/>
        /// Descripcion: Obtener cuenta por id
        /// </remarks>    
        [HttpGet("cliente/{id}")]
        [Permission("CuentasController-GetByClienteId")]
        [ProducesResponseType(typeof(GetCuentaResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCuentaResponse>> GetByClienteId(int id)
        {
            RequestBase<GetCuentaRequest> request = new RequestBase<GetCuentaRequest>()
            {
                Request = new GetCuentaRequest()
                {
                    cliente_id = id,
                    TypeGetCuenta = TypeGetCuenta.ByCliente
                }
            };
            await CreateDataCacheLocal(HttpContext, request);
            ResponseBase<GetCuentaResponse> objResponse = await _mediator.Send(new GetCuentaQuery(request));
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Registrar cliente
        /// </summary>
        /// <remarks>
        /// Permiso: CuentasController-Register
        /// <br/>
        /// Descripcion: Registrar cliente
        /// </remarks>    
        [HttpPost("registrar")]
        [Authorize]
        [Permission("CuentasController-Register")]
        [ProducesResponseType(typeof(RegisterCuentaResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RegisterCuentaResponse>> Register([FromBody] RegisterCuentaRequest data)
        {
            RegisterCuentaCommand command = new RegisterCuentaCommand()
            {
                Request = data
            };
            await CreateDataCacheLocal(HttpContext, command);
            ResponseBase<RegisterCuentaResponse> objResponse = await _mediator.Send(command);
            return OkUrban(objResponse);
        }


        /// <summary>
        /// Registrar cliente
        /// </summary>
        /// <remarks>
        /// Permiso: CuentasController-GenerarNumeroCuenta
        /// <br/>
        /// Descripcion: Registrar cliente
        /// </remarks>    
        [HttpPost("generar-numero-cuenta")]
        [Authorize]
        [Permission("CuentasController-GenerarNumeroCuenta")]
        [ProducesResponseType(typeof(CrearNumeroCuentaResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CrearNumeroCuentaResponse>> GenerarNumeroCuenta([FromBody] CrearNumeroCuentaRequest data)
        {
            CrearNumeroCuentaCommand command = new CrearNumeroCuentaCommand()
            {
                Request = data
            };
            await CreateDataCacheLocal(HttpContext, command);
            ResponseBase<CrearNumeroCuentaResponse> objResponse = await _mediator.Send(command);
            return OkUrban(objResponse);
        }

        /// <summary>
        /// Eliminar cliente
        /// </summary>
        /// <remarks>
        /// Permiso: CuentasController-Delete
        /// <br/>
        /// Descripcion: Eliminar cliente
        /// </remarks>    
        [HttpDelete("{id}")]
        [Authorize]
        [Permission("CuentasController-Delete")]
        [ProducesResponseType(typeof(DeleteCuentaResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<DeleteCuentaResponse>> Delete(int id)
        {
            DeleteCuentaCommand command = new DeleteCuentaCommand()
            {
                Request = new DeleteCuentaRequest()
                {
                    cuenta_id = id
                }
            };
            await CreateDataCacheLocal(HttpContext, command);
            ResponseBase<DeleteCuentaResponse> objResponse = await _mediator.Send(command);
            return OkUrban(objResponse);
        }
    }
}
