namespace GuestManagement.Domain.Base
{
   public interface IMapperWrapper<Source, Target>
        where Source : class, new()
        where Target : class, new()
    {
        Target Map(Source source);

        Target Map(Source source, Target target);
    }
}