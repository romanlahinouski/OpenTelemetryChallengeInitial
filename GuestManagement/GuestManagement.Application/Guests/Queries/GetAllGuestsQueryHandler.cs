using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using MediatR;

namespace GuestManagement.Application.Guests.Queries
{
    public class GetAllGuestsQueryHandler : IRequestHandler<GetAllGuestsQuery, IEnumerable<Guest>>
    {
        private readonly IGuestRepository repository;

        public GetAllGuestsQueryHandler(IGuestRepository repository)
       {
            this.repository = repository;
        }
       
        public async Task<IEnumerable<Guest>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            return (await repository.GetAllGuestsAsync(request.GuestsNumber)).Select(x => new Guest{
              Email = x.Email,
              FirstName = x.FirstName,
              LastName = x.LastName,
               PhoneNumber = x.PhoneNumber,
               Id = x.GuestId
            });
        }
    }
}