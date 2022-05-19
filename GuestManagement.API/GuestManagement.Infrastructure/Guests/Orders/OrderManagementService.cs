using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.Orders;
using GuestManagement.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GuestManagement.Infrastructure.Guests.Orders
{
    public class OrderManagementService : IOrderManagementService
    {
        
       MessageSender _messageSender;

        private  const  string _queueName = "orders";
        private readonly ILogger<MessageSender> logger;
        public Message<Order> Message;


        public void SetDownstreamCorrelation(Message<Order> order){}  
       
       //TODO: remove logger from here as it's only for debugging singularity header
        public OrderManagementService(MessageSender messageSender, ILogger<MessageSender> logger)
        {
            if (messageSender is null)
            {
                throw new ArgumentNullException(nameof(messageSender));
            }

            else
            {
                _messageSender = messageSender;
            }

            this.logger = logger;
        }
        
        public async Task CreateOrder(Order order)
        {
          Message = new Message<Order>(logger) {Body = order};

          SetDownstreamCorrelation(Message);

          string serializedOrder = JsonConvert.SerializeObject(Message);

          await  _messageSender.SendMessageAsync(serializedOrder,_queueName);
        }

        public Task DeleteOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateOrder(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}