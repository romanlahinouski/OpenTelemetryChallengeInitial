using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Restaurants;


namespace RestaurantManagement.Domain.Restaurants
{
    public interface IRestaurantRepository : IRepository
    {
         IReadOnlyCollection<Restaurant> GetAll();

         Task<IReadOnlyCollection<Restaurant>> GetRestaurantsByExpressionAsync(Expression<Func<Restaurant, bool>> expression);

      
         Task<Restaurant> GetRestaurantById(int restaurantId);

         Task AddRestaurant(Restaurant restaurant);
    }
}
