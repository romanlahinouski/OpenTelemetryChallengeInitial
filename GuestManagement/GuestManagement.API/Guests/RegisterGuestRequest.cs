using RestaurantGuide.Guests;
using System;
using System.ComponentModel;
using DateTimeConverter = RestaurantGuide.Guests.DateTimeConverter;

namespace GuestManagement.API.Guests
{
    [TypeConverter(typeof(DateTimeConverter))]
    public class RegisterGuestRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
