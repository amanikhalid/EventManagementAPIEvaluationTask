using AutoMapper;
using EventManagementAPIEvaluationTask.DTOs;
using EventManagementAPIEvaluationTask.Interfaces;
using EventManagementAPIEvaluationTask.Models;

namespace EventManagementAPIEvaluationTask.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IAttendeeRepository _attendeeRepo;
        private readonly IEventRepository _eventRepo;
        private readonly IMapper _mapper;

        public AttendeeService(IMapper mapper, IAttendeeRepository attendeeRepo, IEventRepository eventRepo)
        {
            _mapper = mapper;
            _attendeeRepo = attendeeRepo;
            _eventRepo = eventRepo;
        }

        public async Task<IEnumerable<AttendeeDto>> GetAttendeesByEventIdAsync(int eventId)
        {
            var attendees = await _attendeeRepo.GetAttendeesByEventIdAsync(eventId);
            return _mapper.Map<IEnumerable<AttendeeDto>>(attendees);
        }

        public async Task<AttendeeDto> RegisterAttendeeAsync(RegisterAttendeeDto dto)
        {
            // Check the following before registering an attendee:
            var count = await _attendeeRepo.GetAttendeeCountAsync(dto.EventId);
            var eventInfo = await _eventRepo.GetByIdAsync(dto.EventId);
            if (eventInfo == null)
                throw new ArgumentException("Event not found.");

            if (count >= eventInfo.MaxAttendees)
                throw new InvalidOperationException("Event is full.");

            // Check if the email is already registered for the event
            if (await _attendeeRepo.IsEmailRegisteredAsync(dto.Email, dto.EventId))
                throw new InvalidOperationException("This email is already registered for this event.");

            // All checks passed, register the attendee
            var entity = _mapper.Map<Attendee>(dto);
            await _attendeeRepo.AddAsync(entity);
            return _mapper.Map<AttendeeDto>(entity);
        }
    }
}
