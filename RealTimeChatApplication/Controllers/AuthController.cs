using Microsoft.AspNetCore.Mvc;
using RealTimeChatApplication.Interfaces;
using RealTimeChatApplication.Models;

namespace RealTimeChatApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginReqModel req)
        {
            try
            {
                // Mock User
                if (req.Username != "admin" ||
                    req.Password != "1234")
                {
                    return Unauthorized("Invalid username or password");
                }

                var user = new UserModel
                {
                    Id = 1,
                    Username = req.Username
                };

                var token = _tokenService.CreateToken(user);

                if (token == null)
                {
                    return StatusCode(500, "Failed to generate token");
                }

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
