using AutoMapper;
using GuestManagement.Domain.Guests;
using GuestManagement.Infrastructure.Services;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Infrastructure.Guests
{
    public class GuestInMemoryCacheRepository : IGuestRepository
    {
        private readonly IGuestRepository guestRepository;
        private readonly IDistributedCache distributedCache;
        private readonly ISerializer<Guest> serializer;   
        private readonly IMapper mapper;

        public GuestInMemoryCacheRepository(IGuestRepository guestRepository,
            IDistributedCache distributedCache,
            ISerializer<Guest> serializer,        
            IMapper mapper
            )
        {
            this.guestRepository = guestRepository;
            this.distributedCache = distributedCache;
            this.serializer = serializer;       
            this.mapper = mapper;
        }
        public async Task AddAsync(Guest guest)
        {
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

           var guestString =  serializer.Serialize(guest);
                                  
           await distributedCache.SetStringAsync(guest.Email, guestString, options);
         
           await  guestRepository.AddAsync(guest);
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync(int guestsNumber)
        {
           return await guestRepository.GetAllGuestsAsync(guestsNumber);
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            var cachedGuest =  await distributedCache.GetStringAsync(email);       

            Guest guest;

            if (cachedGuest != null)
            {
                 guest = serializer.Deserialize(cachedGuest);
             
                return guest;
            }              
            else
               return await guestRepository.GetGuestByEmailAsync(email);
        }

        public Task<Guest> GetGuestByIdAsync(string guestId)
        {
            throw new NotImplementedException();
        }

        public void Update(Guest guest)
        {
         
            var cacheableGuestString = serializer.Serialize(guest);

            distributedCache.Remove(guest.Email);

            distributedCache.SetString(guest.Email, cacheableGuestString);

            guestRepository.Update(guest);           
        }

      
    }
}
