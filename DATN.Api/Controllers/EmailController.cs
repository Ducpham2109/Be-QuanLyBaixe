using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.EmailHander.Commands.FogotPassWordRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("fogotPassWord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Create([FromBody] ForgotPasswordRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
