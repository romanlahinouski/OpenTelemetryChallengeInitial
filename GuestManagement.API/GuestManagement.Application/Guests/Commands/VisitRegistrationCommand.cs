using MediatR;
using System;
namespace GuestManagement.Application.Guests.Commands
{
    public class VisitRegistrationCommand : IRequest
    {       
        public VisitRegistrationCommand(string email,          
            int restaurantId)
        {
            Email = email;       
            RestaurantId = restaurantId;       
        }

        public string Email { get; }
  
        public int RestaurantId { get; }
   
    }
}
