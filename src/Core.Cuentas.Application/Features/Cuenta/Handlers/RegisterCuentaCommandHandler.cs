using AutoMapper;
using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.Features.Cuenta.Commands;
using Core.Cuentas.Application.Interfaces.Base;
using Core.Cuentas.Application.Interfaces.Infraestructure;
using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Domain.Common;
using Core.Cuentas.Domain.Entities;
using static Core.Cuentas.Model.Entity.EnumTypes;

namespace Core.Cuentas.Application.Features.Cuenta.Handlers
{
    public class RegisterCuentaCommandHandler : BaseCommand, IDecoradorRequestHandler<RegisterCuentaCommand, ResponseBase<RegisterCuentaResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public RegisterCuentaCommandHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<RegisterCuentaResponse>> Handle(RegisterCuentaCommand request, CancellationToken cancellationToken)
        {
             RegisterCuentaRequest RequestData = request.Request!;
            Guid IdTraking = (Guid)request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            RegisterCuentaResponse objResponse = new RegisterCuentaResponse();
            try
            {
                cuenta objSaved = _cuentaRespository.GetIncludesAsNoTraking<cuenta>().FirstOrDefault(x => x.cuenta_id == RequestData.cuenta_id)!;
                if (objSaved == null)
                {
                    cuenta objNew = new cuenta()
                    {
                        agencia_id = RequestData.agencia_id,
                        cliente_id = RequestData.cliente_id,
                        fecha_apertura = RequestData.fecha_apertura,
                        fecha_cierre = RequestData.fecha_cierre,
                        fecha_ultima_transaccion = RequestData.fecha_ultima_transaccion,
                        moneda = RequestData.moneda,
                        numero_cuenta = RequestData.numero_cuenta,
                        producto_id = RequestData.producto_id,
                        saldo_actual = 0M,
                        saldo_disponible = 0M,
                        tasa_interes = RequestData.tasa_interes,
                        tipo_cuenta = RequestData.tipo_cuenta,
                        usuario_creacion = RequestData.usuario_creacion,
                        estado = (int)TypeStatus.Active,
                    };
                    objNew = await _cuentaRespository.Save(objNew);
                    objResponse.cuenta = _mapper.Map<cuentaDto>(objNew);
                }
                else
                {
                    //List<string> camposForzarModificacion = new List<string>();
                    //camposForzarModificacion.Add("strategy_framework_country_id");
                    //camposForzarModificacion.Add("value");

                    objSaved.fecha_cierre =  RequestData.fecha_cierre;
                    objSaved.fecha_ultima_transaccion = RequestData.fecha_ultima_transaccion;
                    objSaved.saldo_actual = RequestData.saldo_actual;
                    objSaved.saldo_disponible = RequestData.saldo_disponible;
                    objSaved.tasa_interes = RequestData.tasa_interes;                   
                    objSaved.estado = RequestData.estado;

                    objSaved = await _cuentaRespository.Update(objSaved.cuenta_id, objSaved);
                    objResponse.cuenta = _mapper.Map<cuentaDto>(objSaved);
                }
            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<RegisterCuentaResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
