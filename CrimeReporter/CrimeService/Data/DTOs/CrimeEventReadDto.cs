using CrimeService.Models;

namespace CrimeService.Data.DTOs
{
    public class CrimeEventReadDto
    {
        public Guid Id { get; set; }
        public CrimeEventType EventType { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ReporterEmail { get; set; }
        public CrimeStatus Status { get; set; } = CrimeStatus.Waiting;
        public string LawEnforcement { get; set; }
    }
}
