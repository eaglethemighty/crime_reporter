using AutoMapper;
using CrimeService.Models;

namespace CrimeService.Data.DTOs
{
    public class CrimeMappingProfile : Profile
    {
        public CrimeMappingProfile()
        {
            CreateMap<CrimeEventReadDto, CrimeEvent>().ReverseMap();
            CreateMap<CrimeEventCreateDto, CrimeEvent>().ReverseMap();
        }
    }
}
