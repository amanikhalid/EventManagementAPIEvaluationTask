using EventManagementAPIEvaluationTask.Models;

namespace EventManagementAPIEvaluationTask.Interfaces
{
    public interface IAttendeeRepository : IGenericRepository<Attendee>
    {
        Task<IEnumerable<Attendee>> GetAttendeesByEventIdAsync(int eventId);
        Task<bool> IsEmailRegisteredAsync(string email, int eventId);
        Task<int> GetAttendeeCountAsync(int eventId);
    }
}
