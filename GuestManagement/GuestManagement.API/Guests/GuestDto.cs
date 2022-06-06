using System;

namespace GuestManagement.API.Guests
{
    public class GuestDto
    {
      public string FirstName { get; set; }

      public string LastName { get; set; }

      public string Email { get; set; }

      public string PhoneNumber { get; set; }
      
       public DateTime DateOfBirth { get; set; }
    }
}