using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.DeleteAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.AccountHandler.Queries.GetAllAccountWithCondition;
using DATN.Application.ParkingHandler.Commam.CreateParking;
using DATN.Application.ParkingHandler.Commam.DeleteParking;
using DATN.Application.ParkingHandler.Commam.UpdateParking;
using DATN.Application.ParkingHandler.Queries;
using DATN.Application.ParkingHandler.Queries.GetAccountPaging;
using DATN.Application.ParkingHandler.Queries.GetCapacityParkingCodeWithCondition;
using DATN.Application.ParkingHandler.Queries.GetParkingPagingWithConditionQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] CreateParkingCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPost("UpdatePerLoading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] UpdatePreParkingCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("PakingCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(int ParkingCode)
        {
            var query = new DeleteParkingCommand(ParkingCode);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("PakingCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get(int ParkingCode)
        {
            var query = new GetParkingQuery(ParkingCode);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("/api/parking/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetAllParkingWithCondition([FromQuery] GetAllParkingWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetParkingPagingQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }

        [HttpGet("parkingCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetParkingPagingWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateParkingCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpGet("capacity/parkingCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetCapacityParkingCodeWithCondition queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }


    }
}
