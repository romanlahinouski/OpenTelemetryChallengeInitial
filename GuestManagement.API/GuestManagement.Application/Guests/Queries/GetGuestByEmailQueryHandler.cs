using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using MediatR;

namespace GuestManagement.Application.Guests.Queries
{
    public class GetGuestByEmailQueryHandler : IRequestHandler<GetGuestByEmailQuery, Guest>
    {
        private readonly IGuestRepository guestRepository;

        public GetGuestByEmailQueryHandler(IGuestRepository guestRepository)
        {
            this.guestRepository = guestRepository;
        }
        
        
        public async Task<Guest> Handle(GetGuestByEmailQuery request, CancellationToken cancellationToken)
        {
          
          //remake with automapper
          
           var domainGuest = await guestRepository.GetGuestByEmailAsync(request.Email);

           return  domainGuest == null ? null : new Guest { Email = domainGuest.Email , Id = domainGuest.GuestId };
        }
    }
}