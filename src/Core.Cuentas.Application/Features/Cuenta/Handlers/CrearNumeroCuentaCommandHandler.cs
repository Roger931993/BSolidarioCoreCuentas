using AutoMapper;
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
    internal class CrearNumeroCuentaCommandHandler : BaseCommand, IDecoradorRequestHandler<CrearNumeroCuentaCommand, ResponseBase<CrearNumeroCuentaResponse>>
    {
        private readonly ICuentaRespository _cuentaRespository;

        public CrearNumeroCuentaCommandHandler(IErrorCatalogException errorCatalogException, IRedisCache redisCache, IMemoryCacheLocalService memoryCacheLocalService, IMapper mapper, ICuentaRespository cuentaRespository) : base(errorCatalogException, redisCache, memoryCacheLocalService, mapper)
        {
            this._cuentaRespository = cuentaRespository;
        }

        public async Task<ResponseBase<CrearNumeroCuentaResponse>> Handle(CrearNumeroCuentaCommand request, CancellationToken cancellationToken)
        {
            CrearNumeroCuentaRequest RequestData = request.Request!;
            Guid IdTraking = (Guid)request.IdTraking!;
            DataCacheLocal cachelocal = await _memoryCacheLocalService.GetCachedData(IdTraking.ToString());
            CrearNumeroCuentaResponse objResponse = new CrearNumeroCuentaResponse();
            try
            {
                secuencial objsecuencial = _cuentaRespository.GetIncludesAsNoTraking<secuencial>().FirstOrDefault(x => x.descripcion == RequestData.producto_id.ToString())!;
                int secuencial_reservado = objsecuencial.secuencial_id;
                objsecuencial.secuencial_id++;
                await _cuentaRespository.Update(objsecuencial.secuencial_id, objsecuencial);

                string numero_cuenta = $"{RequestData.banco}0{RequestData.agencia_id}{RequestData.producto_id}{1}{DateTime.Now.Year:D2}{secuencial_reservado:D6}"; ;

                objResponse.numero_cuenta = numero_cuenta;

            }
            catch (Exception ex)
            {
                await AddLogError(RequestData, 500, ex, cachelocal);
                return await ErrorResponseEx<CrearNumeroCuentaResponse>(IdTraking, ex, (int)TypeError.InternalError, Status: 500);
            }
            return await OkResponse(objResponse);
        }
    }
}
