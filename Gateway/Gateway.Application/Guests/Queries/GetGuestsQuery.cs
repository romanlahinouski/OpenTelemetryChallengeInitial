using System.Collections.Generic;
using MediatR;

namespace Gateway.Application.Guests.Queries
{
    public class GetGuestsQuery : IRequest<IEnumerable<GuestDto>>
    {
        public int GuestsNumber { get; set; }
        
        
        public GetGuestsQuery(int guestsNumber)
        {
            GuestsNumber = guestsNumber;
        }
    }
}