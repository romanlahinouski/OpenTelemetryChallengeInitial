using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Application.Restaurants.Queries
{
   public class GetRestaurantRemainingCapacityQuery : IRequest<int>
    {
        public int RestaurantId { get; set; }
    }
}
