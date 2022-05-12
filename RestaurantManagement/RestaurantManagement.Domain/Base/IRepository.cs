using System;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Base
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    }
}
