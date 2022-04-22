using AutoMapper;
using MediatR;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Application.HttpClients;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand
{
    public class AssignCrimeCommandHandler : IRequestHandler<AssignCrimeCommand, AssignCrimeCommandResponse>
    {
        private readonly IHttpCrimeClient _httpClient;
        private readonly IPoliceUnitRepository _policeUnitRepository;
        private readonly IMapper _mapper;

        public AssignCrimeCommandHandler(IPoliceUnitRepository policeUnitRepository, IMapper mapper, IHttpCrimeClient client)
        {
            _policeUnitRepository = policeUnitRepository ?? throw new ArgumentNullException(nameof(policeUnitRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpClient = client;
        }

        public async Task<AssignCrimeCommandResponse> Handle(AssignCrimeCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            bool AssignHttpResult = await _httpClient.TryAssignUnit(request.crimeAssignModel);
            if (!AssignHttpResult)
            {
                return new AssignCrimeCommandResponse("Crime Could Not Have Been Assigned", false);
            }

            bool AssignResult = await _policeUnitRepository.TryAssignCrime(request.crimeAssignModel);
            if (!AssignResult)
            {
                return new AssignCrimeCommandResponse("Crime Could Not Have Been Assigned", false);
            }
            return new AssignCrimeCommandResponse(AssignResult? "Success" : null);
        }
    }
}
