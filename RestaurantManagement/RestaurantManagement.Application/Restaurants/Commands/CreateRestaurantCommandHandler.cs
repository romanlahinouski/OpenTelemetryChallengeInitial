using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Restaurants;
using RestaurantManagement.Domain.Restaurants.Cuisines;

namespace RestaurantManagement.Application.Restaurants.Commands
{
    public class CreateRestaurantCommandHandler : AsyncRequestHandler<CreateRestaurantCommand>
    {
        private readonly IRestaurantRepository restaurantRepository;

        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        protected override async Task Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            Cuisine cuisine;

            if (!Enum.TryParse<Cuisine>(request.Cuisine, out cuisine))
                cuisine = Cuisine.Undefined;

            var restaurant =  Restaurant.CreateRestaurant(request.Name, request.MaxNumberOfGuests, cuisine, request.City, request.Street);
           await restaurantRepository.AddRestaurant(restaurant);           
        }
    }
}
