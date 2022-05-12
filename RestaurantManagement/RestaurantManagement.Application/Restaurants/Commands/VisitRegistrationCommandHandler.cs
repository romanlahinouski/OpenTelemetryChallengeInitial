using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Restaurants;

namespace RestaurantManagement.Application.Restaurants.Commands
{
    public class VisitRegistrationCommandHandler : AsyncRequestHandler<VisitRegistrationCommand>
    {
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IUnitOfWork unitOfWork;

        public VisitRegistrationCommandHandler(IRestaurantRepository restaurantRepository, IUnitOfWork unitOfWork)
        {
            this.restaurantRepository = restaurantRepository;
            this.unitOfWork = unitOfWork;
        }

        protected override async Task Handle(VisitRegistrationCommand request, CancellationToken cancellationToken)
        {
           var restaurant = await restaurantRepository.GetRestaurantById(request.RestaurantId);
            if (restaurant == null)
                throw new NoRestaurantInTheSystemException("Supplied restaurant id doesn't exist");

            restaurant.RegisterGuest(request.GuestId);

            await unitOfWork.CommitChangesAsync();          
        }
    }
}
