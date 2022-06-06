using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests.Orders;
using GuestManagement.Infrastructure.Configuration;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace GuestManagement.Infrastructure.Guests
{
    public class CosmosOrderRepository : IOrderRepository
    {
        private readonly IConfiguration configuration;

        private const string dbName = "Orders";

        private const string containerName = "OrdersData";

        private Container container;



        public CosmosOrderRepository(IConfiguration configuration)
        {
            this.configuration = configuration;

            var options = configuration.GetSection("Features:AzureOptions:CosmosClientOptions")
            .Get<AzureCosmosDbOptions>();

            var cosmosClient = new CosmosClient(options.CosmosDbUrl, options.CosmosDbKey);

            var db = cosmosClient.GetDatabase(dbName);

            container = db.GetContainer(containerName);

        }


        public async Task<List<Order>> GetOrdersByEmail(string email)
        {
           List<Order> orders = new List<Order>();
           
            using FeedIterator<Order> iterator = container.GetItemLinqQueryable<Order>
            (requestOptions: new QueryRequestOptions {})
            .Where(o => o.GuestEmail == email)
            .ToFeedIterator();

            while (iterator.HasMoreResults)
            {
                foreach (var item in await iterator.ReadNextAsync())
                {
                   orders.Add(item);
                }

            }
            return orders;
        }

    }
}