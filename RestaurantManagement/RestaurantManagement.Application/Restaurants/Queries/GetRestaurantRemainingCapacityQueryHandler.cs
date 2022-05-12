using MediatR;
using RestaurantManagement.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Restaurants.Queries
{
    public class GetRestaurantRemainingCapacityQueryHandler : IRequestHandler<GetRestaurantRemainingCapacityQuery, int>
    {
        private readonly IRestaurantRepository restaurantRepository;

        public GetRestaurantRemainingCapacityQueryHandler(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }
        
        
        public async Task<int> Handle(GetRestaurantRemainingCapacityQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantRepository.GetRestaurantById(request.RestaurantId);

            return restaurant.GetRemainingCapacity();
        }
    }
}
