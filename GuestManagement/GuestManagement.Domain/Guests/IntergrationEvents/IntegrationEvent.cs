using System;

namespace GuestManagement.Domain.Guests.IntergrationEvents
{
    public abstract class IntegrationEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreationDate { get; set; } = DateTime.Now;
        
    }
}