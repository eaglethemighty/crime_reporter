using PoliceService.Domain.Common;

namespace PoliceService.Domain.Entities
{
    public class PoliceUnit : AuditableEntity
    {
        public string Id { get; set; }
        public PoliceUnitRank Rank { get; set; }
        public List<Guid> AssignedEvents { get; set; }
    }
    public enum PoliceUnitRank
    {
        Local,
        Sheriff,
        Homeland
    }
}
