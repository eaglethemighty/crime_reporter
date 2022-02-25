using AutoMapper;
using MediatR;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand
{
    public class AssignCrimeCommandHandler : IRequestHandler<AssignCrimeCommand, AssignCrimeCommandResponse>
    {
        private readonly IPoliceUnitRepository _policeUnitRepository;
        private readonly IMapper _mapper;

        public AssignCrimeCommandHandler(IPoliceUnitRepository policeUnitRepository, IMapper mapper)
        {
            _policeUnitRepository = policeUnitRepository ?? throw new ArgumentNullException(nameof(policeUnitRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AssignCrimeCommandResponse> Handle(AssignCrimeCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            PoliceUnit PoliceUnitFromRequest = _mapper.Map<PoliceUnit>(request);
            bool AssignResult = await _policeUnitRepository.TryAssignCrime(request.crimeAssignModel.unitId, request.crimeAssignModel.crimeId);
            if (!AssignResult)
            {
                return new AssignCrimeCommandResponse("Crime Could Not Have Been Assigned", false);
            }
            return new AssignCrimeCommandResponse(AssignResult? "Success" : null);
        }
    }
}
