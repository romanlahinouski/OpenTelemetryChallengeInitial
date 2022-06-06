using GuestManagement.Application.Guests.Queries;
using MediatR;

namespace GuestManagement.Application.Guests.Commands
{
    public class UpdateGuestCommand : IRequest
    {

        public Guest Guest { get; set; }
        public string Email { get; set; }

        public UpdateGuestCommand(Guest guest, string email)
        {
            Email = email;
            Guest = guest;

        }

    }
}