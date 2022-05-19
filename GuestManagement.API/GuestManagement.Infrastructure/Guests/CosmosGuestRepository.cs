using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using GuestManagement.Infrastructure.Configuration;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace GuestManagement.Infrastructure.Guests
{
    public class CosmosGuestRepository : IGuestRepository
    {
        private const string dbName = "Guests";

        private const string guestsDataContainer = "GuestsData";
        private Database guestsDatabase;

        public CosmosGuestRepository(IConfiguration configuration)
       {
       
        AzureOptions options = configuration.GetSection("Features:AzureOptions")
        .Get<AzureOptions>();

        AzureCosmosDbOptions cosmosDbOptions = options.AzureCosmosDbOptions;

             if(guestsDatabase == null)
             guestsDatabase = new CosmosClient(cosmosDbOptions.CosmosDbUrl,
             cosmosDbOptions.CosmosDbKey)
             .GetDatabase(dbName);
        }
       

        public async Task AddAsync(Guest guest)
        {
          var guestsContainer = guestsDatabase.GetContainer(guestsDataContainer);
          var response = await guestsContainer.CreateItemAsync<Guest>(guest);         
        }

        public  async Task<IEnumerable<Guest>> GetAllGuestsAsync(int guestsNumber)
        {
         var guestsContainer = guestsDatabase.GetContainer(guestsDataContainer); 

          List<Guest> guests = new List<Guest>();

        using FeedIterator<Guest> iterator = guestsContainer.GetItemLinqQueryable<Guest>(
            requestOptions: new QueryRequestOptions {
                MaxItemCount = guestsNumber
            }).ToFeedIterator();

            while(iterator.HasMoreResults){

                foreach(var item in await iterator.ReadNextAsync()){
                        guests.Add(item);

                }
            };

            return guests;
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
          Guest guest = default;

          var guestsContainer = guestsDatabase.GetContainer(guestsDataContainer);
        
           using FeedIterator<Guest> iterator = guestsContainer.GetItemLinqQueryable<Guest>
           (requestOptions: new QueryRequestOptions {MaxItemCount = 1 })
           .Where(g => g.Email == email)
           .ToFeedIterator<Guest>();      

           while(iterator.HasMoreResults){

               foreach(var item in await iterator.ReadNextAsync())
               {
                guest = item;
               }
           }

          return guest;
        }

        public Task<Guest> GetGuestByIdAsync(string guestId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Guest guest)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGuestAsync(Guest guest)
        {
            throw new System.NotImplementedException();
        }
    }
}