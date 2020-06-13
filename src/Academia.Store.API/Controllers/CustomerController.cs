using Academia.Store.Application.Handlers.CustomerHandlers;
using Academia.Store.Domain.Contexts.Commands.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerCommandHandler _commandHandler;
        public CustomerController(CustomerCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] CreateCustomerCommand command) //thin controller
        {
            return StatusCode(201, _commandHandler.Handle(command));
        }
    }
}