using MediatR;
using System;
namespace RestaurantManagement.Application.Restaurants.Commands
{
    public class VisitRegistrationCommand : IRequest
    {

        public VisitRegistrationCommand(int restaurantId, int guestId )
        {
            RestaurantId = restaurantId;
            GuestId = guestId;
        }
 
        public int RestaurantId { get; }
        public int GuestId { get; set; }

    }
}
