using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Application.UseCase.Entity.UserUseCase;
using WildwoodLib.Implementation;
using static WildwoodLib.Application.UseCase.Entity.UserUseCase.UserUseCase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserUseCaseController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public UserUseCaseController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }

        // GET: api/<UserUseCaseController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserUseCaseSearchDto search, [FromServices] IGetUserUseCaseQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<UserUseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserUseCaseDto dto, [FromServices] ICreateUserUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<UserUseCaseController>/5
        [HttpDelete()]
        public IActionResult Delete(DeleteUserUseCaseDto dto, [FromServices] IDeleteUserUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
