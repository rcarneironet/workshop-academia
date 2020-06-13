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
        private readonly CustomerQueryHandler _queryHandler;
        public CustomerController(
            CustomerCommandHandler commandHandler,
            CustomerQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
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

        [HttpGet("getAllCustomers")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return StatusCode(200, _queryHandler.Handle());
        }

    }
}