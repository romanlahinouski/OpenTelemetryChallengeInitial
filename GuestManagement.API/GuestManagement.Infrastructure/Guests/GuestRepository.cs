using GuestManagement.Domain.Guests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Infrastructure.Guests
{
    public class GuestRepository : IGuestRepository
    {
        private readonly GuestDbContext guestDbContext;
     
        public GuestRepository(GuestDbContext guestDbContext,
            IConfiguration configuration)          
        {
            this.guestDbContext = guestDbContext;  
        }

        public void Add(Guest guest)
        {
            guestDbContext.Guests.Add(guest);
        }

        public async Task AddAsync(Guest guest)
        {
           await guestDbContext.Guests.AddAsync(guest);
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync(int guestsNumber)
        {
          return await guestDbContext.Guests
          .Take(guestsNumber)
          .ToListAsync();
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            var user = await guestDbContext.Guests                       
                 .FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<Guest> GetGuestByIdAsync(string guestId)
        {
            return await guestDbContext.Guests           
              .FirstOrDefaultAsync(x => x.GuestId == guestId);
        }

        public void Update(Guest guest)
        {
           if(guestDbContext.Entry<Guest>(guest).State == EntityState.Detached)
           throw new ArgumentException("Only existing guests can be updated");
          
           guestDbContext.Update(guest);
        }
    }
}
