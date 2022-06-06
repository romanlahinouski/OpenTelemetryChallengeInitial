using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.Orders;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GuestManagement.Application.Guests.Commands
{
    public class AcceptOrderCommandHandler : AsyncRequestHandler<AcceptOrderCommand>
    {
        private readonly ILogger<AcceptOrderCommandHandler> logger;
        private readonly IOrderManagementService orderManagementService;

        public AcceptOrderCommandHandler(ILogger<AcceptOrderCommandHandler> logger, IOrderManagementService orderManagementService)
        {
            this.logger = logger;
            this.orderManagementService = orderManagementService;
        }
       
        protected override async Task Handle(AcceptOrderCommand request, CancellationToken cancellationToken)
        {                   
           Order order = new Order(request.OrderItems, request.Email);

           await orderManagementService.CreateOrder(order);
        }
    }
}