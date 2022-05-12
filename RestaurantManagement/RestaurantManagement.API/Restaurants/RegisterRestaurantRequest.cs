using System;
namespace RestaurantManagement.Restaurants
{
    public class RegisterRestaurantRequest
    {
        public string RestaurantName { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Cuisine { get; set; }
    }
}
