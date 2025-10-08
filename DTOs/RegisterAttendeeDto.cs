namespace EventManagementAPIEvaluationTask.DTOs
{
    public class RegisterAttendeeDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int EventId { get; set; }
    }
}
