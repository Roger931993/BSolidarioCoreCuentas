using AutoMapper;
using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.Features.Movimiento.Queries;
using Core.Cuentas.Application.Interfaces.Base;
using Core.Cuentas.Application.Interfaces.Infraestructure;
using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Domain.Common;
using Core.Cuentas.Domain.Entities;
using static Core.Cuentas.Model.Entity.EnumTypes;

namespace Core.Cuentas.Application.Features.Movimiento.Handlers
{
    public class GetMovimientoQueryHandler : BaseCommand, IDecoradorRequestHandler<GetMovimientoQuery, ResponseBase<GetMovimientoResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public GetMovimientoQueryHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<GetMovimientoResponse>> Handle(GetMovimientoQuery request, CancellationToken cancellationToken)
        {
            GetMovimientoRequest RequestData = request.request.Request!;

            Guid IdTraking = (Guid)request.request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            GetMovimientoResponse objResponse = new GetMovimientoResponse();

            try
            {
                List<movimientoDto> objResult = new List<movimientoDto>();
                if (RequestData.TypeGetMovimiento == TypeGetMovimiento.None)
                {
                    List<movimiento> objSaved = _cuentaRespository.GetIncludesAsNoTraking<movimiento>()!.ToList();                    
                    objResponse.movimiento = _mapper.Map<List<movimientoDto>>(objSaved);
                }
                if (RequestData.TypeGetMovimiento == TypeGetMovimiento.ById)
                {
                    List<movimiento> objSaved = _cuentaRespository.GetIncludesAsNoTraking<movimiento>(x=>x.cuenta!).Where(x => x.movimiento_id == RequestData.movimiento_id)!.ToList();
                    objResponse.movimiento = _mapper.Map<List<movimientoDto>>(objSaved);
                }
                if (RequestData.TypeGetMovimiento == TypeGetMovimiento.ByCuenta)
                {
                    List<movimiento> objSaved = _cuentaRespository.GetIncludesAsNoTraking<movimiento>(x => x.cuenta!).Where(x => x.cuenta_id == RequestData.cuenta_id)!.ToList();
                    objResponse.movimiento = _mapper.Map<List<movimientoDto>>(objSaved);
                }
                if (RequestData.TypeGetMovimiento == TypeGetMovimiento.ByCliente)
                {
                    List<movimiento> objSaved = _cuentaRespository.GetIncludesAsNoTraking<movimiento>(x => x.cuenta!).Where(x => x.cuenta != null && x.cuenta.cliente_id == RequestData.cliente_id)!.ToList();
                    objResponse.movimiento = _mapper.Map<List<movimientoDto>>(objSaved);
                }
            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<GetMovimientoResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
