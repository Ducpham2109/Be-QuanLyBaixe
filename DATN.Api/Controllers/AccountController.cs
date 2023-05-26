

using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.DeleteAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.AccountHandler.Queries.GetAllAccountWithCondition;
using DATN.Application.BillsHandler.Commands.CreateBills;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("username")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(string Username)
        {
            var query = new DeleteAccountCommand(Username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("username")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get(string Username)
        {
            var query = new GetAccountQuery(Username);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetAccountPagingQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/account/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetAllAccountWithCondition([FromQuery] GetAllAccountWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
    }
}