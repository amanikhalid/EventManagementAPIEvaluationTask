using EventManagementAPIEvaluationTask.DTOs;
using EventManagementAPIEvaluationTask.Interfaces;

namespace EventManagementAPIEvaluationTask.Services
{
    public interface IEventReportService
    {
        Task<IEnumerable<EventReportDto>> GetUpcomingEventsAsync();
    }

    public class EventReportService : IEventReportService
    {
        private readonly IEventRepository _eventRepo;
        private readonly IAttendeeRepository _attendeeRepo;
        private readonly IWeatherService _weather;

        public EventReportService(
            IEventRepository eventRepo,
            IAttendeeRepository attendeeRepo,
            IWeatherService weather)
        {
            _eventRepo = eventRepo;
            _attendeeRepo = attendeeRepo;
            _weather = weather;
        }

        public async Task<IEnumerable<EventReportDto>> GetUpcomingEventsAsync()
        {
            var fromDate = DateTime.UtcNow;
            var toDate = fromDate.AddDays(30);

            var events = await _eventRepo.FindAsync(e => e.Date >= fromDate && e.Date <= toDate);
            var reports = new List<EventReportDto>();

            foreach (var ev in events)
            {
                var attendeeCount = await _attendeeRepo.GetAttendeeCountAsync(ev.EventId);
                var weather = await _weather.GetWeatherForecastAsync(ev.Location, ev.Date);

                reports.Add(new EventReportDto
                {
                    Title = ev.Title,
                    Date = ev.Date,
                    Location = ev.Location,
                    AttendeeCount = attendeeCount,
                    WeatherForecast = weather
                });
            }

            return reports;
        }
    }
}
