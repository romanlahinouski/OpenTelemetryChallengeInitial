using System;

namespace GuestManagement.Domain.Guests.IntergrationEvents
{
    public class GuestCreateIntegrationEvent : IntegrationEvent
    { 
        public Guid GuestId { get; set; }

        public GuestCreateIntegrationEvent(Guid guesId)
        {
            GuestId = guesId;
        }

    }
}