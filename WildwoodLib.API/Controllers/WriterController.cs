using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCase.Entity.Writter;
using WildwoodLib.Implementation;
using static WildwoodLib.Application.UseCase.Entity.Writter.Writer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public WriterController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }
        // GET: api/<WritterController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetWritersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateWriterDto dto, [FromServices] ICreateWriterCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        // DELETE api/<WriterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteWriterCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
