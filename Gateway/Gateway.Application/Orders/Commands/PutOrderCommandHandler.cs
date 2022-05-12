using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Gateway.Application.Orders.Commands
{
  public class PutOrderCommandHandler : AsyncRequestHandler<PutOrderCommand>
    {
        private readonly IOrderFulfilmentService orderFulfilmentService;

        public PutOrderCommandHandler(IOrderFulfilmentService orderFulfilmentService)
        {
            this.orderFulfilmentService = orderFulfilmentService;
        }

   
        protected override async Task Handle(PutOrderCommand request, CancellationToken cancellationToken)
        {                         
            await orderFulfilmentService.PutOrder(request);
     
        }
    }
}
