using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GuestManagement.Infrastructure.Guests;
using Newtonsoft.Json;

namespace GuestManagement.Infrastructure.Services
{
    public class CachedGuestSerializer<Guest> : ISerializer<Guest>
    {
        private readonly IMapper mapper;

        public CachedGuestSerializer(IMapper mapper)
        {
            this.mapper = mapper;
        }
        
        public Guest Deserialize(string value)
        {               
            var cacheableGuest =  JsonConvert.DeserializeObject<CacheableGuest>(value);
            return mapper.Map<CacheableGuest, Guest>(cacheableGuest);
        }

     
        public string Serialize(Guest guest)
        {

            var cachableGuest
             = mapper.Map<Guest, CacheableGuest>(guest);
           
            return JsonConvert.SerializeObject(guest);
        }
    }
}
