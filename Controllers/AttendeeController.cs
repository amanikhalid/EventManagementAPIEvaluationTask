using EventManagementAPIEvaluationTask.DTOs;
using EventManagementAPIEvaluationTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPIEvaluationTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendeeController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;

        public AttendeeController(IAttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        // GET: api/attendee/event/{eventId}
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetAttendeesByEvent(int eventId)
        {
            var attendees = await _attendeeService.GetAttendeesByEventIdAsync(eventId);
            return Ok(attendees);
        }

        // POST: api/attendee
        [HttpPost]
        public async Task<IActionResult> RegisterAttendee([FromBody] RegisterAttendeeDto dto)
        {
            try
            {
                var attendee = await _attendeeService.RegisterAttendeeAsync(dto);
                return Ok(attendee);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
