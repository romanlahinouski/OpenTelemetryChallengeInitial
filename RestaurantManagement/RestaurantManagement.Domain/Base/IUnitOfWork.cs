using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Base
{
   public interface IUnitOfWork
    {
         Task CommitChangesAsync();
    }
}
