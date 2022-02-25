using PoliceService.Application.Functions.PoliceUnits.Commands.AssignCrimeCommand;
using PoliceService.Domain.Entities;

namespace PoliceService.Application.Contracts.Persistence
{
    public interface IPoliceUnitRepository : IAsyncRepository<PoliceUnit>
    {
        public Task<bool> TryAssignCrime(CrimeAssignViewModel model);
    }
}
