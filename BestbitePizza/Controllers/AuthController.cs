using BestbitePizza.Models.Auth;
using BestbitePizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace BestbitePizza.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, IAuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]Credential credential)
        {
            var result = _authService.GetToken(credential);

            if (result == null || string.IsNullOrWhiteSpace(result.AccessToken)) return Unauthorized("Unauthorized");

            return Ok(result);
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            return Ok("Logged out");
        }
    }
}