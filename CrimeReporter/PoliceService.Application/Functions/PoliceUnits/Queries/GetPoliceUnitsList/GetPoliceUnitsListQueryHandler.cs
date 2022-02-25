using AutoMapper;
using MediatR;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits.Queries.GetPoliceUnitsList
{

    public class GetPoliceUnitsListQueryHandler : IRequestHandler<GetPoliceUnitsListQuery, List<PoliceUnitReadDto>>
    {
        private readonly IPoliceUnitRepository _policeUnitRepository;
        private readonly IMapper _mapper;
        public GetPoliceUnitsListQueryHandler(IPoliceUnitRepository policeUnitRepository, IMapper mapper)
        {
            _policeUnitRepository = policeUnitRepository ?? throw new ArgumentNullException(nameof(policeUnitRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<PoliceUnitReadDto>> Handle(GetPoliceUnitsListQuery request, CancellationToken cancellationToken)
        {
            var AllPoliceUnits = await _policeUnitRepository.GetAllAsync();
            return _mapper.Map<List<PoliceUnitReadDto>>(AllPoliceUnits);
        }
    }
}
