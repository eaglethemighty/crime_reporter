using CrimeService.Models;
using System.ComponentModel.DataAnnotations;

namespace CrimeService.Data.DTOs
{
    public class CrimeEventCreateDto
    {
        public CrimeEventType EventType { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string Location { get; set; }
        [EmailAddress]
        public string ReporterEmail { get; set; }
        public CrimeStatus Status { get; set; } = CrimeStatus.Waiting;
    }
}
