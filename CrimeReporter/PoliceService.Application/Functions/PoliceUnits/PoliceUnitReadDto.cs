using PoliceService.Domain.Entities;

namespace PoliceService.Application.Functions.PoliceUnits
{
    public class PoliceUnitReadDto
    {
        public Guid Id { get; set; }
        public PoliceUnitRank Rank { get; set; }
        public List<Guid> AssignedEvents { get; set; }
    }
}
