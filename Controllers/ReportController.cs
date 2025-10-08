using EventManagementAPIEvaluationTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPIEvaluationTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IEventReportService _reportService;

        public ReportController(IEventReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/report/upcoming
        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingEvents()
        {
            var result = await _reportService.GetUpcomingEventsAsync();
            return Ok(result);
        }
    }
}
