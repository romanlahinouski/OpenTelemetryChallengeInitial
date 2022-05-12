using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestManagement.API.Guests
{
    public class VisitRegistrationDto
    {
        public string Email { get; set; }
        public int RestaurantId { get; set; }
       
    }
}
