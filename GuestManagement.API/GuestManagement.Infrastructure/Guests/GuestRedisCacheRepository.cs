using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using GuestManagement.Infrastructure.Configuration;
using GuestManagement.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace GuestManagement.Infrastructure.Guests
{
    public class GuestRedisChacheRepository : IGuestRepository
    {
        private readonly IDatabase redis;
        private readonly ISerializer<Guest> serializer;
        private readonly IGuestRepository guestRepository;

        public GuestRedisChacheRepository(
        IConfiguration configuration,
        ISerializer<Guest> serializer,
        IGuestRepository guestRepository)
        {          
            RedisOptions redisOptions = configuration.GetSection("Features")
            .Get<RedisOptions>();

             
             var configurationOptions = new ConfigurationOptions
                {
                    EndPoints = {
                         {redisOptions.Url, 6379}
                     },

                    Ssl = false
                };
            this.redis = ConnectionMultiplexer
            .Connect(configurationOptions)
            .GetDatabase();

            this.serializer = serializer;        
            this.guestRepository = guestRepository;
        }

        public void Add(Guest guest)
        {
            var serializedGuest = serializer.Serialize(guest);
            redis.StringSet(guest.Email,serializedGuest);   
        }

        public async Task AddAsync(Guest guest)
        {          
            var serializedGuest = serializer.Serialize(guest);
            await redis.StringSetAsync(guest.Email,serializedGuest);                    
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync(int guestsNumber)
        {
           return await guestRepository.GetAllGuestsAsync(guestsNumber);
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            var cachedGuest =  await redis.StringGetAsync(email);

            Guest guest;

            if (!cachedGuest.IsNullOrEmpty)
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

        public void Update(Guest user)
        {
            throw new NotImplementedException();
        }
    }
}