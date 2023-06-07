using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Application.AccountHandler.Queries.GetAllAccountWithCondition;
using DATN.Application.BillHandler.Queries.GetRevenveParkingCode;
using DATN.Application.BillsHandler.Commands.CreateBills;
using DATN.Application.BillsHandler.Commands.Queries.GetAllBillWithCondition;
using DATN.Application.BillsHandler.Commands.Queries.GetBillPaging;
using DATN.Application.BillsHandler.Commands.Queries.GetRevenve;
using DATN.Application.BillsHandler.Commands.Queries.GetRevenveParkingCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IMediator _mediator;

        public BillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] CreateBillCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Get([FromQuery] GetBillPagingQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/bill/search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetAllBillWithCondition([FromQuery] GetAllBillWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/bill/revenue/month")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetRevenveParkingCode([FromQuery] GetRevenveMonthWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/bill/revenue/parkingCode/month")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetRevenveParkingCodeMonth([FromQuery] GetRevenveParkingMonthWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }
        [HttpGet("/api/bill/revenue/parkingCode/month/day")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> GetRevenveParkingCodeDate([FromQuery] GetRevenveParkingDateWithConditionQuery queries)
        {
            var result = await _mediator.Send(queries);
            return Ok(result);
        }

    }
}
