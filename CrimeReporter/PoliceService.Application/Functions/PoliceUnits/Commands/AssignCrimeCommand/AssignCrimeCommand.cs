using MediatR;

namespace PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand
{
    public class AssignCrimeCommand : IRequest<AssignCrimeCommandResponse>
    {
        public CrimeAssignViewModel crimeAssignModel { get; set; }
    }
}
