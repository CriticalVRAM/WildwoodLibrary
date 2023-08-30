using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Application.UseCase;
using WildwoodLib.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public SeedController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }

        // POST api/<SeedController>
        [HttpPost]
        public IActionResult Post([FromServices] ISeedDataCommand command)
        {
            _handler.HandleCommand(command, 0);
            return Ok();
        }
    }
}
