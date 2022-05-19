using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Application.Orders.Queries
{
    public class GetDishesQueryHandler : IRequestHandler<GetDishesQuery, IReadOnlyCollection<object>>
    {
        private readonly IOrderFulfilmentService orderFulfilmentService;

        public GetDishesQueryHandler(IOrderFulfilmentService orderFulfilmentService)
        {
            this.orderFulfilmentService = orderFulfilmentService;
        }
        
        public async Task<IReadOnlyCollection<object>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            var dishes = await orderFulfilmentService.GetDishes();

            return dishes;
        }
    }
}
