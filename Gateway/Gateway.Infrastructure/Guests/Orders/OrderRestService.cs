using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gateway.Application.Orders;
using Gateway.Application.Orders.Commands;
using Gateway.Application.Orders.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gateway.Infrastructure.Guests.Orders
{
    public class OrderRestService : IOrderFulfilmentService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly ILogger<GuestRestService> logger;

        public OrderRestService(HttpClient httpClient, IConfiguration configuration, ILogger<GuestRestService> logger)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.logger = logger;
        }

        public Task<List<object>> GetDishes()
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderDetailsDto> GetOrderDetailsById(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public async Task PutOrder(PutOrderCommand putOrderCommand)
        {
           logger.LogInformation($"Started execution of {nameof(PutOrder)}");
           
           string serializedPutOrderCommand = JsonConvert.SerializeObject(putOrderCommand);

           string targetUrl = String.Concat(configuration["ConnectionStrings:GuestManagementService"],"api/Order/");

           logger.LogInformation($"Going to make request under the {targetUrl}");

           var response = await httpClient.PostAsync(targetUrl, serializedPutOrderCommand);

           string responseContent = await response.Content.ReadAsStringAsync();

           logger.LogInformation($"Received response with the following status code {response.StatusCode} with the following message {responseContent}");
        }
    }
}