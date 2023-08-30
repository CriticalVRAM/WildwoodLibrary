using ASPNedelja3Vezbe.Api.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Domain.Entites;

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager _manager;

        public TokenController(JwtManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] TokenRequest request)
        {
            try
            {
                var token = _manager.MakeToken(request.Email, request.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult Get([FromServices] IAppUser user)
        {
            return Ok(user);
        }
    }

    public class TokenRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
