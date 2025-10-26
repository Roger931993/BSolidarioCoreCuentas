using AutoMapper;
using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Application.DTOs.Base;
using Core.Cuentas.Application.Features.Cuenta.Queries;
using Core.Cuentas.Application.Interfaces.Base;
using Core.Cuentas.Application.Interfaces.Infraestructure;
using Core.Cuentas.Application.Interfaces.Persistence;
using Core.Cuentas.Domain.Common;
using Core.Cuentas.Domain.Entities;
using static Core.Cuentas.Model.Entity.EnumTypes;

namespace Core.Cuentas.Application.Features.Cuenta.Handlers
{
    public class GetCuentaQueryHandler : BaseCommand, IDecoradorRequestHandler<GetCuentaQuery, ResponseBase<GetCuentaResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public GetCuentaQueryHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<GetCuentaResponse>> Handle(GetCuentaQuery request, CancellationToken cancellationToken)
        {
            GetCuentaRequest RequestData = request.request.Request!;

            Guid IdTraking = (Guid)request.request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            GetCuentaResponse objResponse = new GetCuentaResponse();

            try
            {
                List<cuentaDto> objResult = new List<cuentaDto>();
                if (RequestData.TypeGetCuenta == TypeGetCuenta.None)
                {
                    List<cuenta> objSaved = _cuentaRespository.GetIncludesAsNoTraking<cuenta>().Where(x => x.cuenta_id == RequestData.cuenta_id)!.ToList();
                    objResponse.cuenta = _mapper.Map<List<cuentaDto>>(objSaved);
                }
                if (RequestData.TypeGetCuenta == TypeGetCuenta.ById)
                {
                    List<cuenta> objSaved = _cuentaRespository.GetIncludesAsNoTraking<cuenta>()!.ToList();
                    objResponse.cuenta = _mapper.Map<List<cuentaDto>>(objSaved);
                }
                if (RequestData.TypeGetCuenta == TypeGetCuenta.ByCliente)
                {
                    List<cuenta> objSaved = _cuentaRespository.GetIncludesAsNoTraking<cuenta>().Where(x => x.cliente_id == RequestData.cliente_id)!.ToList();
                    objResponse.cuenta = _mapper.Map<List<cuentaDto>>(objSaved);
                }
            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<GetCuentaResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
