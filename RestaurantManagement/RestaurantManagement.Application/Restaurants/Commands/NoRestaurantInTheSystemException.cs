using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Application.Restaurants.Commands
{
   public class NoRestaurantInTheSystemException : ApplicationException
    {

        public NoRestaurantInTheSystemException(string message) : 
            base (message)
        {

        }
    }
}
