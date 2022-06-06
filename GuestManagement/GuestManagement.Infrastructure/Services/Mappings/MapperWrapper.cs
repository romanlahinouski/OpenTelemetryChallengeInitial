using AutoMapper;
using GuestManagement.Domain.Base;

namespace GuestManagement.Infrastructure.Services.Mappings
{
  

    public class MapperWrapper<Source, Target> 
    : IMapperWrapper<Source, Target> where Source : class, new()
where Target : class, new()

    {
        private readonly IMapper mapper;

        public MapperWrapper(IMapper mapper)
        {
            this.mapper = mapper;
        }


        public Target Map(Source source)
        {
            return mapper.Map<Target>(source);
        }

        public Target Map(Source source, Target target)
        {
           return mapper.Map<Source, Target>(source, target);
        }
    }
}