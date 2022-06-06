using GuestManagement.Domain.Base;
using GuestManagement.Infrastructure.Guests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuestDbContext guestDbContext;

        public UnitOfWork(GuestDbContext guestDbContext)
        {
            this.guestDbContext = guestDbContext;
        }
        
        public async Task CommitChangesAsync()
        {
           await guestDbContext.SaveChangesAsync();
        }
    }
}

