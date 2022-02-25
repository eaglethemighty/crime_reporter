using AutoMapper;
using PoliceService.Application.Functions.PoliceUnits;
using PoliceService.Application.Functions.PoliceUnits.Commands.CreatePoliceUnitCommand;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Mapper
{
    public class PoliceUnitMappingProfile : Profile
    {
        public PoliceUnitMappingProfile()
        {
            CreateMap<PoliceUnit, PoliceUnitReadDto>();
            CreateMap<CreatePoliceUnitCommand, PoliceUnit>().ReverseMap();
        }
    }
}
