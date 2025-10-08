using EventManagementAPIEvaluationTask.Data;
using EventManagementAPIEvaluationTask.Interfaces;
using EventManagementAPIEvaluationTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementAPIEvaluationTask.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Event>> GetEventsWithAttendeesAsync()
        {
            return await _context.Events.Include(e => e.Attendees).ToListAsync();
        }

        public async Task<Event?> GetEventWithAttendeesByIdAsync(int id)
        {
            return await _context.Events.Include(e => e.Attendees)
                .FirstOrDefaultAsync(e => e.EventId == id);
        }

        public async Task<IEnumerable<Event>> FilterEventsAsync(string? location, DateTime? date, int? minAttendees)
        {
            var query = _context.Events.Include(e => e.Attendees).AsQueryable();

            if (!string.IsNullOrEmpty(location))
                query = query.Where(e => e.Location.Contains(location));

            if (date.HasValue)
                query = query.Where(e => e.Date.Date == date.Value.Date);

            if (minAttendees.HasValue)
                query = query.Where(e => e.Attendees.Count >= minAttendees.Value);

            return await query.ToListAsync();
        }
    }
}
