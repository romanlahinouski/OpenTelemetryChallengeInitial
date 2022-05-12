using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Application.Orders.Queries
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
    {
        private readonly IOrderFulfilmentService orderFulfilmentService;

        public GetOrderDetailsQueryHandler(IOrderFulfilmentService orderFulfilmentService)
        {
            this.orderFulfilmentService = orderFulfilmentService;           
        }
        
        
        public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await orderFulfilmentService.GetOrderDetailsById(request.OrderId);

            return orderDetails;
        }
    }
}
