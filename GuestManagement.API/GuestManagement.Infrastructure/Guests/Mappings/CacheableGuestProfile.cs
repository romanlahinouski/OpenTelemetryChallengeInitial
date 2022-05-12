using AutoMapper;
using GuestManagement.Domain.Guests;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuestManagement.Infrastructure.Guests.Mappings
{
   public class CacheableGuestProfile : Profile
    {

        public CacheableGuestProfile()
        {
            CreateMap<CacheableGuest, Guest>().ReverseMap();
        }

    }
}
