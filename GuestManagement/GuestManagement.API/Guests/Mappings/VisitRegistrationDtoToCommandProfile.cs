using AutoMapper;
using GuestManagement.Application.Guests;
using GuestManagement.Application.Guests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestManagement.API.Guests.Mappings
{
    public class VisitRegistrationDtoToCommandProfile : Profile
    { 
        public VisitRegistrationDtoToCommandProfile()
        {
            CreateMap<VisitRegistrationDto, VisitRegistrationCommand>()
                .ConstructUsing(x => 
                new VisitRegistrationCommand(
                    x.Email,                    
                    x.RestaurantId));
        }
    }
}
