using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gateway.Application.Orders.Commands;
using Gateway.Application.Orders.Queries;
using System;

namespace Gateway.Orders.Administration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserNotRegisteredExceptionFilter]
    [Obsolete]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public int RestaurantId { get; set; }

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;          
        }

        [HttpPost]      
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put([FromBody] OrderRequest orderDto)
        {
           await mediator.Send(
               new PutOrderCommand(orderDto.Email, orderDto.OrderItems));
           

            return Ok("Order Received");
        }

       
        [HttpGet]
        public async Task<ActionResult> GetDishes()
        {
            var dishes = await mediator.Send(new GetDishesQuery());

            return Ok(dishes);
        }

        [HttpGet("{OrderId}")]
        public async Task<ActionResult> GetOrderDetails(int orderId)
        {
           var orderDetails =  await mediator.Send(new GetOrderDetailsQuery { OrderId = orderId });

            return Ok(orderDetails);
        }
    }
}
