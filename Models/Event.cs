using EventManagementAPIEvaluationTask.Models;
using System.ComponentModel.DataAnnotations;

namespace EventManagementAPIEvaluationTask.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }

        [Range(10, 500)]
        public int MaxAttendees { get; set; }

        // Navigation
        public ICollection<Attendee> Attendees { get; set; }
    }
}
