using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using WildwoodLib.Implementation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static WildwoodLib.Application.UseCase.Entity.Category.Category;
using WildwoodLib.Application.UseCase.Entity.Category;
using WildwoodLib.Application.UseCase.Entity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public CategoryController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetCategoryQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateCategoryDto dto, [FromServices] IUpdateCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(201);
        }
    }
}
