using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Restaurants;
using RestaurantManagement.Infrastructure.Base;

namespace RestaurantManagement.Infrastructure.Restaurants
{
    public class RestaurantRepository : Repository<Restaurant>,IRestaurantRepository
    {
        private readonly RestaurantDbContext restaurantDbContext;

        public RestaurantRepository(RestaurantDbContext restaurantDbContext )
            : base(restaurantDbContext)
        {
            this.restaurantDbContext = restaurantDbContext;
        }

        public IReadOnlyCollection<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> GetRestaurantById(int restaurantId)
        {
            return await restaurantDbContext.Restaurants.FirstOrDefaultAsync(r => r.RestaurantId == restaurantId);
        }

      

        public async Task<IReadOnlyCollection<Restaurant>> GetRestaurantsByExpressionAsync(Expression<Func<Restaurant,bool>> expression)
        {

            var queryProvider = restaurantDbContext.Restaurants.AsQueryable().Provider;

            var del =  expression.Compile();

            var query = queryProvider.CreateQuery<Restaurant>(expression);

            var restaurants = await restaurantDbContext.Restaurants
                .Where(expression)
                .ToListAsync();

            return restaurants;

        }

        public IQueryable<Restaurant> GetSource()
        {
            throw new NotImplementedException();
        }

        public async Task AddRestaurant(Restaurant restaurant)
        {
           await restaurantDbContext.AddAsync(restaurant);
           await restaurantDbContext.SaveChangesAsync();
        }



        public async Task<IReadOnlyCollection<Restaurant>> GetRestaurantWithGuestIncluded(int restaurantId)
        {
            var restaurants = await restaurantDbContext.Restaurants
                .Where(r => r.RestaurantId == restaurantId)
                .Include("currentGuests")
                .ToListAsync();

            //var guests = restaurant.

            return restaurants;
        }
    }
}
