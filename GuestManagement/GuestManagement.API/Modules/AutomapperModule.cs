using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using GuestManagement.Infrastructure;

namespace GuestManagement.API.Modules
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAutoMapper(config => {

                foreach (var assembly in Assemblies.SolutionAsseblies)
                {
                    config.AddMaps(assembly);
                    config.ShouldMapField = fieldInfo => true;
                    config.ShouldMapProperty = propetyInfo => true;
                }

            },typeof(AutomapperModule).Assembly);
        }

    }
}
