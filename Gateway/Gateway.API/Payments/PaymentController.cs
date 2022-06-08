using MediatR;
using Microsoft.AspNetCore.Mvc;
using Gateway.Application.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Payments
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Obsolete]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PaymentRequest paymentRequest)
        {
            await mediator.Send(new CreatePaymentCommand(paymentRequest.OrderIdentifier, paymentRequest.Payment));

            return Ok();
        }

    }
}
