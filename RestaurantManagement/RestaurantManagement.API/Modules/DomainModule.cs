using Autofac;
using RestaurantManagement.Domain.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantGuide.Modules
{
    public class DomainModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PaymentTokenGenerator>()
                .As<IPaymentTokenGenerator>()
                .InstancePerDependency();


        }
    }
}
