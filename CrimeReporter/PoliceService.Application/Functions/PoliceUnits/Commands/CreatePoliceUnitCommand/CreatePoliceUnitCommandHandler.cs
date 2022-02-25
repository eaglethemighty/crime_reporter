using AutoMapper;
using MediatR;
using PoliceService.Application.Contracts.Persistence;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.CreatePoliceUnitCommand
{
    public class CreatePoliceUnitCommandHandler : IRequestHandler<CreatePoliceUnitCommand, CreatePoliceUnitResponse>
    {
        private readonly IAsyncRepository<PoliceUnit> _policeUnitRepository;
        private readonly IMapper _mapper;

        public CreatePoliceUnitCommandHandler(IAsyncRepository<PoliceUnit> policeUnitRepository, IMapper mapper)
        {
            _policeUnitRepository = policeUnitRepository ?? throw new ArgumentNullException(nameof(policeUnitRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        async Task<CreatePoliceUnitResponse> IRequestHandler<CreatePoliceUnitCommand, CreatePoliceUnitResponse>.Handle(CreatePoliceUnitCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var Validator = new CreatePoliceUnitValidator();
            var ValidationResult = Validator.Validate(request);
            if (!ValidationResult.IsValid) return new CreatePoliceUnitResponse(ValidationResult);

            PoliceUnit PoliceUnitFromRequest = _mapper.Map<PoliceUnit>(request);
            await _policeUnitRepository.AddAsync(PoliceUnitFromRequest);
            if (!await _policeUnitRepository.SaveAsync())
            {
                throw new Exception("Saving police in the database failed. Check connection with the database.");
            }
            return new CreatePoliceUnitResponse(PoliceUnitFromRequest.Id);
        }
    }
}
 