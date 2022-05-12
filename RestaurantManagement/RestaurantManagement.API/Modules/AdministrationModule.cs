using Autofac;
using RestaurantManagement.Application;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Infrastructure;

namespace RestaurantGuide.Modules
{
    public class AdministrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assemblies.Application)
                .AsClosedTypesOf(typeof(IBaseRole<>))
                .AsImplementedInterfaces();        
        }


    }
}
