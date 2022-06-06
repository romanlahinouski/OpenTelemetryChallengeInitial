using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.Orders;

namespace GuestManagement.Infrastructure.Guests.Orders
{
    public class FakeOrderManagementService : IOrderManagementService
    {
        public Task CreateOrder(Order order)
        {
           return Task.CompletedTask;
        }

        public Task DeleteOrder(int orderId)
        {
            return Task.CompletedTask;
        }

        public Task GetorderByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateOrder(Order order)
        {
            return Task.CompletedTask;
        }
    }
}