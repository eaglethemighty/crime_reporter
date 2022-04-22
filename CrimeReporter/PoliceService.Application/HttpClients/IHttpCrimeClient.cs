using PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand;

namespace PoliceService.Application.HttpClients
{
    public interface IHttpCrimeClient
    {
        public Task<bool> TryAssignUnit(CrimeAssignViewModel model);
    }
}