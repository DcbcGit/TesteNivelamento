using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankOperationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankOperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("consult-accounts")]
        public async Task<ActionResult> GetAllAccount([FromQuery] GetAllAccountRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("consult-account-by-number")]
        public async Task<ActionResult> GetAccountByNumber([FromQuery] GetAccountByNumberAccountRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("get-balance-account")]
        public async Task<ActionResult> GetAccountByNumber([FromQuery] GetAccountBalanceRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("insert-account-movement")]
        public async Task<ActionResult> InsertAccountMovement([FromBody] InsertAccountMovementRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        

    }
}