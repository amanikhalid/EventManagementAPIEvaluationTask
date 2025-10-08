using EventManagementAPIEvaluationTask.Models;

namespace EventManagementAPIEvaluationTask.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsWithAttendeesAsync();
        Task<Event?> GetEventWithAttendeesByIdAsync(int id);
        Task<IEnumerable<Event>> FilterEventsAsync(string? location, DateTime? date, int? minAttendees);
    }
}
