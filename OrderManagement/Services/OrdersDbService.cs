using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using OrderManagement.Models;

namespace OrderManagement.Services
{
    public class OrdersDbService : IOrderDbService
    {
        private readonly Container _container;

        public OrdersDbService(Container container)
         {
            _container = container;
        }
         
         public async Task CreateOrder(Order order){
            
             await _container.CreateItemAsync<Order>(order,new PartitionKey(order.Id.ToString()));

         }
    }
}