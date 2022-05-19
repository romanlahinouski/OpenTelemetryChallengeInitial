using System.Threading.Tasks;
using GuestManagement.Domain.Guests.Orders;

namespace GuestManagement.Domain.Guests
{
    public interface IOrderManagementService
    {
          Task CreateOrder(Order order);

          Task UpdateOrder(Order order);

          Task DeleteOrder(int orderId);
         
         // Task CheckOrderStatus(int orderId);

    }
}