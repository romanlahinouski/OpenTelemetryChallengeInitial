using System;
using MediatR;

namespace RestaurantManagement.Application.Restaurants.Commands
{
    public class CreateRestaurantCommand : IRequest
    {

        public string Name { get; set; }

        public string Cuisine { get; set; }

        public string City { get; set; }
        public string  Street { get; set; }

        public string PostalCode { get; set; }
        public int MaxNumberOfGuests { get; set; }

        public string Description { get; set; }

        public CreateRestaurantCommand()
        {
        }
    }
}
