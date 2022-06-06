using GuestManagement.Domain.Guests;
using MediatR;

namespace GuestManagement.Application.Guests.Queries
{
    public class GetGuestByEmailQuery : IRequest<Guest>
    {
        public string Email { get; set; }
     
    }
}