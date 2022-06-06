using Autofac;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Base;
using GuestManagement.Infrastructure.Guests;
using GuestManagement.Infrastructure.Services;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GuestManagement.Infrastructure.Guests.Orders;
using System;
using GuestManagement.Infrastructure.Services.Events;
using GuestManagement.Domain.Guests.IntergrationEvents;
using GuestManagement.Infrastructure.Configuration;
using GuestManagement.Infrastructure.Services.Mappings;
using GuestManagement.Infrastructure.Services.Messages;

namespace GuestManagement.API.Modules
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<InfrastructureModule> logger;

        public InfrastructureModule(IConfiguration configuration, ILogger<InfrastructureModule> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        protected override void Load(ContainerBuilder builder)
        {
                       
            builder.RegisterType<GuestRepository>()
                .As<IGuestRepository>();

            if (Startup.ApplicationFeatures.AzureOptions.Enabled)
            {
                builder.Register<IStorageService>(c => new AzureStorage(configuration));

                builder.RegisterType<ServiceBusMessageSender>()
                .As<MessageSender>()
                .InstancePerDependency();

                builder.RegisterType<CosmosGuestRepository>().As<IGuestRepository>();

                builder.RegisterType<AzureEventBus>().As<IEventBus>();
            }

            if(Startup.ApplicationFeatures.RabbitMQOptions.Enabled)
            {
              builder.RegisterType<RabbitMQMessageSender>()
                .As<MessageSender>()
                .SingleInstance();
            }
        
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            builder.RegisterType<VisitRegistrationService>()
                .As<IVisitRegistrationService>();

            builder.Register<DefaultMessageSender>(c => new DefaultMessageSender(c.Resolve<ILogger<MessageSender>>()));

            //builder
            //    .RegisterDecorator<GuestRegistrationServiceLogger, IGuestRegistrationService>();

            builder.RegisterType<CachedGuestSerializer<Guest>>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<OrderManagementService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<LogProcessor>().As<ILogProcessor>();
            builder.RegisterType<LogsScannerService>().As<ILogsScannerService>();
            builder.RegisterType<LogRemover>().As<ILogRemover>();
        
            if (Startup.ApplicationFeatures.RedisOptions.Enabled)
                builder.RegisterDecorator<GuestRedisChacheRepository, IGuestRepository>();

            builder.RegisterType<IntergrationEventsQueue>().As<IIntegrationEventsQueue>();

            builder.RegisterGeneric(typeof(MapperWrapper<,>)).As(typeof(IMapperWrapper<,>));

        }
    }

}
