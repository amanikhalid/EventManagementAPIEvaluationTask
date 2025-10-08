using EventManagementAPIEvaluationTask.DTOs;

namespace EventManagementAPIEvaluationTask.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllEventsAsync();
        Task<EventDto?> GetEventByIdAsync(int id);
        Task<EventDto> CreateEventAsync(CreateEventDto dto);
    }
}
