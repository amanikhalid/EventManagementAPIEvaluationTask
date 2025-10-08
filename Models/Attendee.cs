using System.ComponentModel.DataAnnotations;

namespace EventManagementAPIEvaluationTask.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required, MaxLength(80)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string? Phone { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public int EventId { get; set; }

        // Navigation
        public Event Event { get; set; }
    }
}
