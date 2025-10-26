#region References
using AutoMapper;
using Core.Cuentas.Application.DTOs;
using Core.Cuentas.Domain.Entities;
#endregion


namespace Core.Cuentas.Application.Mappings
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<cuenta, cuentaDto>();            
                        
            
        }
    }
}
