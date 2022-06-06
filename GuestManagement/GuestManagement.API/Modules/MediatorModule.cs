﻿using Autofac;
using GuestManagement.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestManagement.API.Modules
{
    public class MediatorModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerDependency();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            var mediatorTypes = new[]
            {
                typeof(IRequest<>),
                typeof(IRequestHandler<,>)
            };


            foreach (var type in mediatorTypes)
            {
                foreach (var assembly in Assemblies.SolutionAsseblies)
                {
                    builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(type)
                   .AsImplementedInterfaces()
                   .InstancePerDependency();
                }

            }

        }
    }
    
}
