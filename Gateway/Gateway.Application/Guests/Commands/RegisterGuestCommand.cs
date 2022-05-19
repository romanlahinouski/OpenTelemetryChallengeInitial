using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Application.Guests.Commands
{
   public class RegisterGuestCommand : IRequest
    {
        public RegisterGuestCommand(
            int restaurantId,
            string email       
            )
        {
            RestaurantId = restaurantId;
            Email = email;     
        }
    
   
        public string Email { get; set; }
        public int RestaurantId { get; set; }

    }
}
