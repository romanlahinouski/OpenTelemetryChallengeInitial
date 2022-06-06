using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Domain.Base
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
