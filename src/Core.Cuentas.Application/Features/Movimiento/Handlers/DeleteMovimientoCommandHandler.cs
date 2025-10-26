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
    public class DeleteMovimientoCommandHandler : BaseCommand, IDecoradorRequestHandler<DeleteMovimientoCommand, ResponseBase<DeleteMovimientoResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public DeleteMovimientoCommandHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<DeleteMovimientoResponse>> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            DeleteMovimientoRequest RequestData = request.Request!;
            Guid IdTraking = (Guid)request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            DeleteMovimientoResponse objResponse = new DeleteMovimientoResponse();
            try
            {
                movimiento objSaved = _cuentaRespository.GetIncludesAsNoTraking<movimiento>().FirstOrDefault(x => x.movimiento_id == RequestData.movimiento_id)!;
                if (objSaved != null)
                    await _cuentaRespository.DeleteLogic<movimiento>(RequestData.movimiento_id)!;
                objResponse.movimiento = _mapper.Map<movimientoDto>(objSaved);
            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<DeleteMovimientoResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
