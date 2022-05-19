using System;
using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Base;
using GuestManagement.Domain.Guests.IntergrationEvents;
using Microsoft.Extensions.Hosting;

namespace GuestManagement.Infrastructure.Services.Events
{
    public class EventService : BackgroundService
    {
        private readonly IEventBus eventBus;
        public EventService(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
         
          while(!stoppingToken.IsCancellationRequested){
      
          var integrationEvents = IntergrationEventsQueue.GetAllEvents();

          if(integrationEvents.Length > 0)
           await eventBus.PublishEventsBatchAsync(integrationEvents);
             
             await Task.Delay(TimeSpan.FromSeconds(2));
           }
        }
    }
}