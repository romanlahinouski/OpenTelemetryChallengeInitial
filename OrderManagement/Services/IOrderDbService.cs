using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.Services
{
    public interface IOrderDbService
    {
         Task CreateOrder(Order order);    
    }
}