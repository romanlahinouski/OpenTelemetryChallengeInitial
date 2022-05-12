using System.Collections.Generic;

namespace RestaurantManagement.Domain.Restaurants.Dishes
{
    public interface IDishRepository
    {
         Dish GetDish(int id);

         List<Dish> GetDishesByNames(IEnumerable<string> names);

         List<Dish> GetAll();

    }
}
