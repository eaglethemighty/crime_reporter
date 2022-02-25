using PoliceService.Domain.Entities;

namespace PoliceService.Application.Contracts.Persistence
{
    public interface IPoliceUnitRepository : IAsyncRepository<PoliceUnit>
    {
        public Task<bool> TryAssignCrime(string unitId, Guid crimeId);
    }
}
