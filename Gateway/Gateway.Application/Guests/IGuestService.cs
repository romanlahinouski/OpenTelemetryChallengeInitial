using Gateway.Application.Guests.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Application.Guests
{
    public interface IGuestService
    {
        public Task RegisterForAVisitAsync(RegisterGuestCommand registerGuestCommand);

        public Task CreateGuestAsync(CreateGuestCommand createGuestCommand);

        public Task CancelRegistrationAsync(CancelRegistrationCommand cancelRegistrationCommand);

        public Task<IEnumerable<GuestDto>> GetGuestsAsync(int guestsNumber);

    }
}
