using System;
namespace RestaurantManagement.Application.Restaurants.Commands
{
    public class NoUserInTheSystemException : Exception
    {
        public NoUserInTheSystemException(string message)
            : base(message)
        {

        }
    }
}
