using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderManagement;
using OrderManagement.Configuration;
using OrderManagement.Models;
using OrderManagement.Services;

namespace RestaurantGuide.OrderManagement.Handlers
{
    public class OrderCreationHandler
    {
        [FunctionName("Handle")]
        public void Run([ServiceBusTrigger("orders", Connection = "rg_servicebus")] string myQueueItem,
        ILogger log)
        {
            try
            {
                var correlationHeader = myQueueItem
                .Split("\"SingularityHeader\":")[1]
                .Split("\"")[1];

             log.LogInformation($"{correlationHeader}");
                
                IOrderDbService orderDbService =
           OrdersDbServiceConfigHelper.ConfigureOrdersDb();


                var message = JsonConvert.DeserializeObject<Message<Order>>(myQueueItem);

                Order order = message.Body ?? throw new ArgumentException("Order is empty");

                if (orderDbService != null)
                {
                    log.LogInformation($"Cosmos db connection is initialized");
                    log.LogInformation($"Goind to create the following order : {myQueueItem}");


                    orderDbService.CreateOrder(order)
                      .GetAwaiter()
                      .GetResult();
                }

                 else{
                log.LogInformation($"No cosmos db available");
            }
    
            }

            catch (System.Exception ex)
            {
                log.LogError(ex.Message);
            }

        }
          
           
    }
}
