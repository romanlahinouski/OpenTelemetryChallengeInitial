using System.Collections.Concurrent;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using GuestManagement.Domain.Base;
using GuestManagement.Domain.Guests.IntergrationEvents;
using GuestManagement.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GuestManagement.Infrastructure.Services.Events
{
    public class AzureEventBus : IEventBus
    {
        private EventHubProducerClient eventHubProducerClient;

        private ILogger<AzureEventBus> _logger;
        private readonly IIntegrationEventsQueue eventsQueue;

        private AzureEventHubOptions azureEventHubOptions;

        public AzureEventBus(IConfiguration configuration, 
        ILogger<AzureEventBus> logger,
        IIntegrationEventsQueue eventsQueue)
        {
           _logger = logger;
            this.eventsQueue = eventsQueue;
            azureEventHubOptions = configuration.GetSection("Features:AzureOptions")
            .Get<AzureOptions>().AzureEventHubOptions;         
        }

        public async Task PublishEventsBatchAsync(IntegrationEvent[] integrationEvents)
        {
            try
            {
                 eventHubProducerClient = new EventHubProducerClient(azureEventHubOptions.EventHubUrl, azureEventHubOptions.EventHubName);
           
                using EventDataBatch eventDataBatch = await eventHubProducerClient.CreateBatchAsync();

                for (int i = 0; i < integrationEvents.Length; i++)
                {
                    var integrationEvent = integrationEvents[i];
                    var serializedEvent = JsonConvert.SerializeObject(integrationEvent);
                    var eventData = new EventData(serializedEvent);
                    if (!eventDataBatch.TryAdd(eventData))
                    {
                        await eventsQueue.PublishIntegrationEvent(integrationEvent);
                        _logger.LogInformation($"Batch is full, requeing event with id {integrationEvent.Id}");
                    }
                }
                await eventHubProducerClient.SendAsync(eventDataBatch);
            }
            catch (System.Exception ex)
            {
              _logger.LogError($"{ex.Message}");
            }
            finally
            {
                await eventHubProducerClient.CloseAsync();
            }


        }

        public void Subscribe<T, TH>() where T : IntegrationEvent
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe<T, TH>() where T : IntegrationEvent
        {
            throw new System.NotImplementedException();
        }
    }
}