using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Dummy user for testing
        private const string TestUsername = "user";
        private const string TestPassword = "hardCoded";

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == TestUsername && request.Password == TestPassword)
            {
                // Return a fake token for demo
                return Ok(new { token = "fake-jwt-token" });
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}