using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Domain.Guests
{
  public  interface IGuestService
    {     
     //Task CancelRegistrationAsync(CancelRegistrationCommand cancelRegistrationCommand); 
     Task CreateGuestAsync(Guest guest);
     Task RegisterForAVisitAsync(string guestEmail, int restaurantId);
 
    }
}
