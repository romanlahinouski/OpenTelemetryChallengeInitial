using GuestManagement.Domain.Guests.Visits;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuestManagement.Infrastructure.Guests
{
    public class CacheableGuest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string  PhoneNumber { get; set; }

        public List<Visit> Visits { get; set; }
          = new List<Visit>();

    }
}
