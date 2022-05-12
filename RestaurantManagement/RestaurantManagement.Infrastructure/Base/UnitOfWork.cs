using RestaurantManagement.Domain.Base;
using RestaurantManagement.Infrastructure.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext restaurantDbContext;

        public UnitOfWork(RestaurantDbContext restaurantDbContext)
        {
            this.restaurantDbContext = restaurantDbContext;
        }
        
        public async Task CommitChangesAsync()
        {
            await restaurantDbContext.SaveChangesAsync();
        }
    }
}
