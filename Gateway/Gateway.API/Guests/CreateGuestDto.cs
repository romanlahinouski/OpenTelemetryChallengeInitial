using System;
using System.ComponentModel;

namespace Gateway.Guests
{

//    [TypeConverter(typeof(DateTimeConverter))]
    public class CreateGuestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }       
        public string DateOfBirth { get; set; }
    }
}