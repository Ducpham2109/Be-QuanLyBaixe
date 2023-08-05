using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.DeleteAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesWithCondition;
using DATN.Application.TicketHanler.Commands.CreateTicket;
using DATN.Application.TicketHanler.Commands.UpdateTicket;
using DATN.Application.TicketHanler.Queries.GetTicketWithCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{

    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] CreateTicketCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPut("Recharge")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Recharge([FromBody] UpdateMoneyCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPut("money")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> PutMoneySentVehicle([FromBody] UpdateMoneysentVehicleCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpGet("ticket/IdCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetTicketWithCondition([FromQuery] GetTicketWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }

    }
}
