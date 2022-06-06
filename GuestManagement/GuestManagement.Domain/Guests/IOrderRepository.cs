using System.Collections.Generic;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests.Orders;

namespace GuestManagement.Domain.Guests.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByEmail(string email);
    }
}