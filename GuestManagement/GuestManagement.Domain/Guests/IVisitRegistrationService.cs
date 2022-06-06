using System.Threading.Tasks;

namespace GuestManagement.Domain.Guests
{
    public interface IVisitRegistrationService
    {
         Task RegisterVisit(Guest guest, int restaurantId); 
    }
}
