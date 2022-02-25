using MediatR;
using PoliceService.Application.Functions.PoliceUnits;

namespace PoliceService.Application.Functions.PoliceUnits.Queries.GetSpecificPoliceUnit
{
    public class GetSpecificPoliceUnitQuery : IRequest<PoliceUnitReadDto>
    {
        public string Id { get; set; }
    }
}
