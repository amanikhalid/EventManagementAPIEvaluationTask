namespace EventManagementAPIEvaluationTask.DTOs
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }

        public List<AttendeeDto> Attendees { get; set; }
    }
}
