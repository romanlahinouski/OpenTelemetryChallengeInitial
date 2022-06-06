using AutoMapper;
using GuestManagement.Application.Guests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestManagement.API.Guests.Mappings
{
    public class RegisterGuestDtoToCommandProfile : Profile
    {

        public RegisterGuestDtoToCommandProfile()
        {
            CreateMap<RegisterGuestRequest, CreateGuestCommand>()
                .ConvertUsing(x =>
                new CreateGuestCommand(
                    x.PhoneNumber,
                    x.FirstName,
                    x.LastName,
                    x.Email,
                    x.DateOfBirth));
        }
    }
}
