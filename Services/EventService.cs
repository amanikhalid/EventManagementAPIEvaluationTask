using AutoMapper;
using EventManagementAPIEvaluationTask.DTOs;
using EventManagementAPIEvaluationTask.Interfaces;
using EventManagementAPIEvaluationTask.Models;

namespace EventManagementAPIEvaluationTask.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepo, IMapper mapper)
        {
            _eventRepo = eventRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            var events = await _eventRepo.GetEventsWithAttendeesAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            var ev = await _eventRepo.GetEventWithAttendeesByIdAsync(id);
            return ev == null ? null : _mapper.Map<EventDto>(ev);
        }

        public async Task<EventDto> CreateEventAsync(CreateEventDto dto)
        {
            // Validation: Event date must be in the future
            if (dto.Date < DateTime.UtcNow)
                throw new ArgumentException("Event date must be in the future.");

            var entity = _mapper.Map<Event>(dto);
            await _eventRepo.AddAsync(entity);
            return _mapper.Map<EventDto>(entity);
        }
    }
}
