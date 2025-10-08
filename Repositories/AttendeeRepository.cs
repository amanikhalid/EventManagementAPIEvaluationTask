using EventManagementAPIEvaluationTask.Data;
using EventManagementAPIEvaluationTask.Interfaces;
using EventManagementAPIEvaluationTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPIEvaluationTask.Repositories
{
    public class AttendeeRepository : GenericRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Attendee>> GetAttendeesByEventIdAsync(int eventId)
        {
            return await _context.Attendees
                .Where(a => a.EventId == eventId)
                .ToListAsync();
        }

        public async Task<bool> IsEmailRegisteredAsync(string email, int eventId)
        {
            return await _context.Attendees.AnyAsync(a => a.Email == email && a.EventId == eventId);
        }

        public async Task<int> GetAttendeeCountAsync(int eventId)
        {
            return await _context.Attendees.CountAsync(a => a.EventId == eventId);
        }
    }
}
