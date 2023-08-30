using Microsoft.AspNetCore.Mvc;
using WildwoodLib.Implementation;
using WildwoodLib.Application.UseCase.Entity.Checkout;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WildwoodLib.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public CheckoutController(UseCaseHandler useCaseHandler)
        {
            _handler = useCaseHandler;
        }
        // GET: api/<CheckoutController>
        [HttpGet]
        public IActionResult Get([FromQuery] CheckoutSearchDto search, [FromServices] IGetCheckoutQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
        // GET: api/<CheckoutController/user>
        [HttpGet("user")]
        public IActionResult Get([FromQuery] UserCheckoutSearchDto search, [FromServices] IGetUserCheckoutQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<CheckoutController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCheckoutDto dto, [FromServices] ICreateCheckoutCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CheckoutController>/5
        [HttpPut]
        public IActionResult Put([FromBody] UpdateCheckoutDto dto, [FromServices] IUpdateCheckoutCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // DELETE api/<CheckoutController>/5
        [HttpDelete]
        public IActionResult Delete(DeleteCheckoutDto dto, [FromServices] IDeleteCheckoutCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
