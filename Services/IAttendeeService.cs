using EventManagementAPIEvaluationTask.DTOs;

namespace EventManagementAPIEvaluationTask.Services
{
    public interface IAttendeeService
    {
        Task<IEnumerable<AttendeeDto>> GetAttendeesByEventIdAsync(int eventId);
        Task<AttendeeDto> RegisterAttendeeAsync(RegisterAttendeeDto dto);
    }
}
