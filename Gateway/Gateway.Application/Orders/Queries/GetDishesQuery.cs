using estaurantGuide.Application.Orders.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Application.Orders.Queries
{
    public class GetDishesQuery : IRequest<IReadOnlyCollection<object>>
    {
    }
}
