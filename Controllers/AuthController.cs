using EventManagementAPIEvaluationTask.DTOs;
using EventManagementAPIEvaluationTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPIEvaluationTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            if (!_auth.ValidateUser(dto))
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _auth.GenerateToken(dto);
            return Ok(new { token });
        }
    }
}
