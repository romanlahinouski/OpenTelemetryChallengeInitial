using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Application.Payments.Commands;
using System.Threading.Tasks;

namespace RestaurantManagement.Payments
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [InvalidPaymentTypeExceptionFilter]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreatePaymentRequest createPaymentRequest)
        {
            await mediator.Send(new CreatePaymentCommand(createPaymentRequest.OrderId, createPaymentRequest.PaymentType));

            return Ok();
        }
    
    }
}
