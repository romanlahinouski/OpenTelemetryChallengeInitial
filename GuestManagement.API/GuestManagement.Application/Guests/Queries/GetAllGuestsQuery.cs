using System.Collections.Generic;
using MediatR;

namespace GuestManagement.Application.Guests.Queries
{
    public class GetAllGuestsQuery : IRequest<IEnumerable<Guest>>
    {     
      
       public int GuestsNumber { get; set; }
       
       
      
        public GetAllGuestsQuery(int guestsNumber)
        {
            GuestsNumber = guestsNumber;
        }
    }
}