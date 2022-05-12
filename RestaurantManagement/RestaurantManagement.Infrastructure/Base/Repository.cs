using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Domain.Base;

namespace RestaurantManagement.Infrastructure.Base
{
    public abstract class Repository<T> : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task Add(T entity)
        {
            await dbContext.AddAsync(entity);
            await SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            dbContext.Update(entity);
        }
    }
}
