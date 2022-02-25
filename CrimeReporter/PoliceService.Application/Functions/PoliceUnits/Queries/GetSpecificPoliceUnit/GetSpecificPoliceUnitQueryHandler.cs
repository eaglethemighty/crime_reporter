using AutoMapper;
using MediatR;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits.Queries.GetSpecificPoliceUnit
{
    public class GetSpecificPoliceUnitQueryHandler : IRequestHandler<GetSpecificPoliceUnitQuery, PoliceUnitReadDto>
    {
        private readonly IPoliceUnitRepository _policeUnitRepository;
        private readonly IMapper _mapper;
        public GetSpecificPoliceUnitQueryHandler(IPoliceUnitRepository policeUnitRepository, IMapper mapper)
        {
            _policeUnitRepository = policeUnitRepository ?? throw new ArgumentNullException(nameof(policeUnitRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PoliceUnitReadDto> Handle(GetSpecificPoliceUnitQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            PoliceUnit? PoliceUnitWithId = await _policeUnitRepository.GetByIdAsync(request.Id);
            if (PoliceUnitWithId is null)
            {
                Console.WriteLine();
                // throw error
            }
            return _mapper.Map<PoliceUnitReadDto>(PoliceUnitWithId);
        }
    }
}
