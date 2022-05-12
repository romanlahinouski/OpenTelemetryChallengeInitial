using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Gateway.Application.Guests;
using Gateway.Infrastructure;
using Gateway.Infrastructure.Guests;
using System;
using System.Net.Http.Headers;
using Gateway.Infrastructure.Base;
using Gateway.Infrastructure.Users;
using Gateway.Infrastructure.Guests.Orders;
using Gateway.Application.Orders;
using Gateway.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Gateway.Modules
{
    public class InfrastructureModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

         
            builder.RegisterType<GroupPolicyHandler>().As<IAuthorizationHandler>();
          
            builder.RegisterType<GuestRestService>().As<IGuestService>();

            builder.RegisterType<OrderRestService>().As<IOrderFulfilmentService>();


            builder.Register<HttpClient>(x =>
            {
                return new HttpClient(
                    () =>
                     {
                        var client = new System.Net.Http.HttpClient(
                        new  SkipCertValidationHttpHandler(x.Resolve<IConfiguration>()));

                        client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")); 

                        client.Timeout = new TimeSpan(0,0,30); 
                    return client;                                       
                    }, x.Resolve<ILogger<HttpClient>>());
        
            }).SingleInstance();      

            builder.RegisterType<UserRepository>().As<IUserRepository>();

        
        }
    }
}
