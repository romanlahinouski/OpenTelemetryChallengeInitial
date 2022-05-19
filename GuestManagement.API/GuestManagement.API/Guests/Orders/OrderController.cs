using System.Linq;
using System.Threading.Tasks;
using GuestManagement.Application.Guests;
using GuestManagement.Domain.Guests.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GuestManagement.API.Guests.Orders
{

    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<ActionResult> AcceptOrder([FromBody] AcceptOrderDto acceptOrderDto)
        {
           
            await _mediator.Send(
                new AcceptOrderCommand{
                     Email = acceptOrderDto.Email, 
                     OrderItems = acceptOrderDto.OrderItems
                     .Select( x => new OrderItem (x .ItemId, x.Count))
                     .ToArray()
                     });
           
            return Accepted();
        }


        [HttpGet]
        public async Task<ActionResult> GetOrdersForCustomer(string email){

            return Ok();
        }

    }
}