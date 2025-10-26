using AutoMapper;
using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.Features.Movimiento.Commands;
using Core.Cuentas.Application.Interfaces.Base;
using Core.Cuentas.Application.Interfaces.Infraestructure;
using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Domain.Common;
using Core.Cuentas.Domain.Entities;
using static Core.Cuentas.Model.Entity.EnumTypes;

namespace Core.Cuentas.Application.Features.Movimiento.Handlers
{
    public class RegisterMovimientoCommandHandler : BaseCommand, IDecoradorRequestHandler<RegisterMovimientoCommand, ResponseBase<RegisterMovimientoResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public RegisterMovimientoCommandHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<RegisterMovimientoResponse>> Handle(RegisterMovimientoCommand request, CancellationToken cancellationToken)
        {
            RegisterMovimientoRequest RequestData = request.Request!;
            Guid IdTraking = (Guid)request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            RegisterMovimientoResponse objResponse = new RegisterMovimientoResponse();
            try
            {
                movimiento objSaved = _cuentaRespository.GetIncludesAsNoTraking<movimiento>().FirstOrDefault(x => x.movimiento_id == RequestData.movimiento_id)!;
                if (objSaved == null)
                {
                    movimiento objNew = new movimiento()
                    {
                       cuenta_id = RequestData.cuenta_id,
                       estado_movimiento = RequestData.estado_movimiento,
                       fecha_hora = RequestData.fecha_hora,
                       naturaleza = RequestData.naturaleza,
                       referencia = RequestData.referencia,
                       saldo_resultante = RequestData.saldo_resultante,
                       tipo_movimiento = RequestData.tipo_movimiento,
                       monto = RequestData.monto,
                       motivo = RequestData.motivo,                       
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

                    objSaved.estado_movimiento = RequestData.estado_movimiento;
                    objSaved.motivo = RequestData.motivo;                   
                    objSaved.estado = RequestData.estado;

                    objSaved = await _cuentaRespository.Update(objSaved.movimiento_id, objSaved);
                    objResponse.cuenta = _mapper.Map<cuentaDto>(objSaved);
                }
            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<RegisterMovimientoResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
