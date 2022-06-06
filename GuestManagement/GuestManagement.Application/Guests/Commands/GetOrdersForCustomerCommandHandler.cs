using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.Orders;
using MediatR;

namespace GuestManagement.Application.Guests.Commands
{
    public class GetOrdersForCustomerCommandHandler : IRequestHandler<GetOrdersForCustomerCommand, List<Order>>
    {
        private readonly IOrderRepository orderRepository;

        public GetOrdersForCustomerCommandHandler(IOrderRepository orderRepository)
       {
            this.orderRepository = orderRepository;
        }
       
        public async Task<List<Order>> Handle(GetOrdersForCustomerCommand request, CancellationToken cancellationToken)
        {
           List<Order> orders = await orderRepository.GetOrdersByEmail(request.Email);
           
           return orders;
        }
    }
}