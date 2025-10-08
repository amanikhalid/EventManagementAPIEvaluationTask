namespace EventManagementAPIEvaluationTask.DTOs
{
    public class EventReportDto
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int AttendeeCount { get; set; }
        public string? WeatherForecast { get; set; }
    }
}
