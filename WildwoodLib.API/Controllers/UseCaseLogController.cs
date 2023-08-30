using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Application;
using WildwoodLib.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    //[Authorize]
    public class UseCaseLogController : ControllerBase
    {
        // GET: api/<UseCaseLogController>
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] IUseCaseLogger useCaseLogger)
        {
            return Ok(useCaseLogger.GetLogs(search));
        }
    }
}
