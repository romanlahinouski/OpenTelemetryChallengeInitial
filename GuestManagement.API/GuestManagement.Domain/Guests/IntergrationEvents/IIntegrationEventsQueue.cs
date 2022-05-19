using System.Threading.Tasks;

namespace GuestManagement.Domain.Guests.IntergrationEvents
{
    public interface IIntegrationEventsQueue
    {
          Task PublishIntegrationEvent(IntegrationEvent integrationEvent);
    }
}