using System.ComponentModel.DataAnnotations;

namespace CrimeService.Models
{
    public class CrimeEvent
    {
        public Guid Id { get; set; }
        public CrimeEventType EventType { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string Location { get; set; }
        [EmailAddress]
        public string ReporterEmail { get; set; }
        public CrimeStatus Status { get; set; } = CrimeStatus.Waiting;
        public string LawEnforcementId { get; set; } = "";
    }
    public enum CrimeEventType
    {
        Burglary,
        Murder,
        Mugging
    }
    public enum CrimeStatus
    {
        Waiting, Finished, Declined
    }
}
