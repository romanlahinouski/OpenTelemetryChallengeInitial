
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(OrderManagement.Startup))]

namespace OrderManagement
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
           // builder.Services.AddSingleton<IOrderDbService>(config => {return OrdersDbServiceConfigHelper.ConfigureOrdersDb();});
        }

    }
}