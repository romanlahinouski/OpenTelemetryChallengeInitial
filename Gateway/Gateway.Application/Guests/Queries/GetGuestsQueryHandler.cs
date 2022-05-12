using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Gateway.Application.Guests.Queries
{
    public class GetGuestsQueryHandler : IRequestHandler<GetGuestsQuery, IEnumerable<GuestDto>>
    {
        private readonly IGuestService guestService;

        public GetGuestsQueryHandler(IGuestService guestService)
        {
            this.guestService = guestService;
        }
        
        public async Task<IEnumerable<GuestDto>> Handle(GetGuestsQuery request, CancellationToken cancellationToken)
        {
          return await guestService.GetGuestsAsync(request.GuestsNumber);
        }
    }
}