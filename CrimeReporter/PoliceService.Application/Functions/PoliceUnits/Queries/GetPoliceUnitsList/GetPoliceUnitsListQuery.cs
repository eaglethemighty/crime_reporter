using MediatR;

namespace PoliceService.Application.Functions.PoliceUnits.Queries.GetPoliceUnitsList
{
    public class GetPoliceUnitsListQuery : IRequest<List<PoliceUnitReadDto>>
    {
    }
}
