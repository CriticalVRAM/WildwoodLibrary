using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Application.UseCase.Entity.Book;
using WildwoodLib.Implementation;
using static WildwoodLib.Application.UseCase.Entity.Book.Book;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public BookController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }

        // GET: api/<BookController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BookSearchDto search, [FromServices] IGetBooksQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDto dto, [FromServices] ICreateBookCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<BookController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateBookDto dto, [FromServices] IUpdateBookCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<BookController>/5
        [HttpDelete()]
        public IActionResult Delete(int id, [FromServices] IDeleteBookCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(201);
        }
    }
}
