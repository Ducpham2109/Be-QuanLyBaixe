
using DATN.Application.AccountHandler.Commands.DeleteAccount;
using DATN.Application.EntryVehiclesHandler.Commands.DeleteEntryVehicle;
using DATN.Application.EntryVehiclesHandler.Commands.GetEntryVehicles;
using DATN.Application.EntryVehiclesHandler.CreateEntryVehicles;
using DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesMonthWithConditionQuery;
using DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesParkingCodeMonthWithCondition;
using DATN.Application.EntryVehiclesHandler.Queries.GetAllEntryVehiclesWithCondition;

using DATN.Application.EntryVehiclesHandler.Queries.GetEntryVehiclesPaging;
using DATN.Application.EntryVehiclesHandler.Queries.GetVehicleWithConditionQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{

    [Route("api/entryVehicles")]
    [ApiController]
    public class EntryVehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntryVehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] CreateEntryVehiclesCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpGet("/api/entryVehicles/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetAllEntryVehiclesWithCondition([FromQuery] GetAllEntryVehiclesWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        //[HttpGet("/api/entryVehicles/parkingCode/search")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<bool>> GetEntryVehiclesWithCondition([FromQuery] GetEntryVehiclesWithConditionQuery queries)
        //{
        //    var result = await _mediator.Send(queries);
        //    return Ok(result);
        //}
        [HttpGet("/api/entryVehicles/parkingCode/month")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetAllEntryVehiclesParkingCodeMonthWithCondition([FromQuery] GetAllEntryVehiclesParkingCodeMonthWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/entryVehicles/month")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetAllEntryVehiclesMonthWithCondition([FromQuery] GetAllEntryVehiclesMonthWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetEntryVehiclesPagingQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/entryVehicles/IDCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetVehicle queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }

        [HttpGet("cost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetEntryVehiclesCommand queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpDelete("IDCard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(int IDCard)
        {
            var query = new DeleteEntryVehicleCommand(IDCard);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
