using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Domain.Restaurants
{
   public class RestaurantGuest
    {
        public int RestaurantGuestId { get; set; }

        public int GuestId  { get;  }

        public int RestaurantId { get; set; }

        public RestaurantGuest()
        {
            //ef core
        }

        public RestaurantGuest(int guestId,int restaurantId)
        {
            GuestId = guestId;
            RestaurantId = restaurantId;
        }

    }
}
