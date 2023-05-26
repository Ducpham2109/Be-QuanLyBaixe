
using DATN.Application.AccountHandler.Commands.DeleteAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.ManagementHandler.CreateManagement;
using DATN.Application.ManagementHandler.DeleteManagement;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
    [Route("api/management")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] CreateManagementCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpGet("username")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get(string Username)
        {
            var query = new GetManagementQuery(Username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpDelete("username")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(string Username)
        {
            var query = new DeleteManagementCommand(Username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    
    }
}
