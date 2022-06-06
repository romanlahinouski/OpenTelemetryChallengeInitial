using AutoMapper;

namespace GuestManagement.Infrastructure.Guests.Mappings
{
    public class GuestPatchProfile : Profile
    {
        public GuestPatchProfile()
        {
            CreateMap<Application.Guests.Guest, Domain.Guests.Guest>().ForAllMembers(options =>{

                options.Condition((source,target,sourceObjMember) => 
                    
                    sourceObjMember != default
                );
            });
        }
    }
}