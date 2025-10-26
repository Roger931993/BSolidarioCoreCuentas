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
    public class DeleteCuentaCommandHandler : BaseCommand, IDecoradorRequestHandler<DeleteCuentaCommand, ResponseBase<DeleteCuentaResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public DeleteCuentaCommandHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<DeleteCuentaResponse>> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
        {
            DeleteCuentaRequest RequestData = request.Request!;
            Guid IdTraking = (Guid)request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            DeleteCuentaResponse objResponse = new DeleteCuentaResponse();
            try
            {
                cuenta objSaved = _cuentaRespository.GetIncludesAsNoTraking<cuenta>().FirstOrDefault(x => x.cuenta_id == RequestData.cuenta_id)!;
                if (objSaved != null)
                    await _cuentaRespository.DeleteLogic<cuenta>(RequestData.cuenta_id)!;
                objResponse.cuenta = _mapper.Map<cuentaDto>(objSaved);
            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<DeleteCuentaResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
