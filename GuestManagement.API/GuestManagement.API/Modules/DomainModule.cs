using Autofac;
using GuestManagement.Domain.Base;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.BusinessRules;
using GuestManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestManagement.API.Modules
{
    public class DomainModule : Module
    {


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GuestAgeBusinessRule>().As<IBusinessRule<Guest>>();
            
            builder.RegisterType<GuestMustBeUniqueBusinessRule>().As<IBusinessRule<Guest>>();

            builder.RegisterType<GuestMustBePresentBusinessRule>().As<IBusinessRule<Guest>>();

            builder.RegisterComposite<GuestCompositeBusinessRule,IBusinessRule<Guest>>();
        }
    }
}
