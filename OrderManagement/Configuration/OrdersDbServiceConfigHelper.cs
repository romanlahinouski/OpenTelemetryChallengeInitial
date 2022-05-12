using Microsoft.Azure.Cosmos;
using OrderManagement.Services;

namespace OrderManagement.Configuration
{
    public class OrdersDbServiceConfigHelper
    {
       private const string dbName = "OrdersDb";
       private const string containerName = "OrdersDbContainer";

       private const string endpointUrl = "https://restaurantguide.documents.azure.com:443/";
       private const string authKey ="JeiRjrMrZlEu8kaBuFIDaUBXHwZVUmC5AgsC46PbVx0lypS5wO9M0bAnUhH5J5vzIbEvWYxtUBQBXYp6feVRqQ==";
  
        public static IOrderDbService ConfigureOrdersDb(){

                CosmosClient client = new CosmosClient(endpointUrl,authKey);
                client.CreateDatabaseIfNotExistsAsync(dbName)
                .ContinueWith(t => {
                    client.GetDatabase(dbName)
                    .CreateContainerIfNotExistsAsync(containerName, "/id");
                }).GetAwaiter().GetResult();

                Container container = client.GetContainer(dbName,containerName);

           return new OrdersDbService(container);     
        }
    }
}