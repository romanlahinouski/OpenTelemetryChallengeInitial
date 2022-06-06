using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests.IntergrationEvents;

namespace GuestManagement.Infrastructure.Services.Events
{
    public  class IntergrationEventsQueue : IIntegrationEventsQueue
    {
        
        private static ConcurrentQueue<IntegrationEvent> eventsQueue = new ConcurrentQueue<IntegrationEvent>();

        public static IntegrationEvent GetEvent()
        {
            IntegrationEvent integrationEvent = default;

            eventsQueue.TryDequeue(out integrationEvent);
           
            return  integrationEvent;
        }

        public static IntegrationEvent [] GetAllEvents(int max = 100){

              List<IntegrationEvent> integrationEvents =
               new List<IntegrationEvent>(max);

               int i = max;
              
                while(eventsQueue.Count > 0 && i > 0){
                    
                IntegrationEvent integrationEvent = default;

                 if(eventsQueue.TryDequeue(out integrationEvent))
                 {
                    integrationEvents.Add(integrationEvent);
                    i--;
                 }

                 else
                   integrationEvents.AddRange(GetAllEvents(i));      
                              
                }

                return integrationEvents.ToArray();
        }

        public static int GetEventsCount() => eventsQueue.Count;

        public  Task PublishIntegrationEvent(IntegrationEvent integrationEvent)
        {
            eventsQueue.Enqueue(integrationEvent);

            return Task.CompletedTask;
        }
    }
}