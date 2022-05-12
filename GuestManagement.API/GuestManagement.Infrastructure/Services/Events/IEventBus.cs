using System.Threading.Tasks;
using GuestManagement.Domain.Guests.IntergrationEvents;

namespace GuestManagement.Infrastructure.Services.Events
{
    public interface IEventBus
    {
        Task PublishEventsBatchAsync(IntegrationEvent [] integrationEvents);

        void Subscribe<T, TH>()
            where T : IntegrationEvent;

        // void SubscribeDynamic<TH>(string eventName)
        //     where TH : IDynamicIntegrationEventHandler;

        // void UnsubscribeDynamic<TH>(string eventName)
        //     where TH : IDynamicIntegrationEventHandler;

        void Unsubscribe<T, TH>()       
            where T : IntegrationEvent;
    }
}