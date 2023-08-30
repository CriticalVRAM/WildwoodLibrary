using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Application.UseCase.Entity;
using WildwoodLib.Application.UseCases.Entity.User;
using WildwoodLib.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public UserController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateUserDto dto, [FromServices] ICreateUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UserController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] EditUserDto dto, [FromServices] IEditUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(204);
        }
    }
}
