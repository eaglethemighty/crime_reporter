using MediatR;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.CreatePoliceUnitCommand
{
    public class CreatePoliceUnitCommand : IRequest<CreatePoliceUnitResponse>
    {
        public PoliceUnitRank Rank { get; set; }
    }
}
