using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GuestManagement.Infrastructure.Services
{
    public class ServiceBusMessageSender : MessageSender
    {

        private ServiceBusClient _client;
        private readonly DefaultMessageSender _defaultMessageSender;
        private readonly ILogger<ServiceBusMessageSender> _logger;

        private void InitializeSender(string connectionString)
        {
            _client = new ServiceBusClient(connectionString);
        }

        public ServiceBusMessageSender(
        IConfiguration configuration,
        DefaultMessageSender defaultMessageSender,
        ILogger<ServiceBusMessageSender> logger)
        {
            string connectinString = Environment.GetEnvironmentVariable("ServiceBusNamespace", EnvironmentVariableTarget.Process);

            if (String.IsNullOrEmpty(connectinString))
                connectinString = configuration["ConnectionStrings:ServiceBusNamespace"];

            InitializeSender(connectinString);

            _defaultMessageSender = defaultMessageSender;
            _logger = logger;
        }
        public override async Task SendMessageAsync(string message, string topicOrQueueName)
        {
            await using (ServiceBusSender sender = _client.CreateSender(topicOrQueueName))
            {               

                ServiceBusMessage sbMessage = new ServiceBusMessage(message);

                var operation = sender.SendMessageAsync(sbMessage);

                var timeOut = TimeSpan.FromMilliseconds(1000);
           
                if (!(await Task.WhenAny(operation,
                Task.Delay(timeOut)) == operation))
                {
                    _logger.LogInformation($"Azure service bus connection timed out after {timeOut.Milliseconds} milliseconds, sending to local queue");
                    await _defaultMessageSender.SendMessageAsync(message, topicOrQueueName);
                }
                else{
                     _logger.LogInformation("Sent message to Azure Service Bus");
                }           
            }
        }
    }
}