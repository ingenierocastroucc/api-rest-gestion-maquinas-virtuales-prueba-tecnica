using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using VMManagerAPI.Models.Dto;
using VMManagerAPI.Services;

namespace VMManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var userDto = new UserDto
            {
                Email = model.Email,
                PasswordHash = model.Password
            };

            var token = _authService.Authenticate(userDto);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
