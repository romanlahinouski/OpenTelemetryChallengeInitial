using System;
using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using RestaurantManagement.Infrastructure;

namespace RestaurantGuide.Modules
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterAutoMapper(config => {
                config.AddMaps(Assemblies.Infrastructure);
                config.ShouldMapField = fieldInfo => true;
                config.ShouldMapProperty = propetyInfo => true;

            }, Assemblies.Infrastructure);
        }
    }
}
