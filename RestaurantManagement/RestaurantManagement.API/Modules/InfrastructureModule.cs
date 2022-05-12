using System;
using Autofac;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Payment;
using RestaurantManagement.Domain.Restaurants;
using RestaurantManagement.Infrastructure.Base;
using RestaurantManagement.Infrastructure.Payments;
using RestaurantManagement.Infrastructure.Restaurants;

namespace RestaurantGuide.Modules
{
    public class InfrastructureModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RestaurantRepository>()
              .As<IRestaurantRepository>()
              .InstancePerDependency();

            builder.RegisterType<PaymentRepository>()
                .As<IPaymentRepository>()
                .InstancePerDependency();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();
        }
    }
}
