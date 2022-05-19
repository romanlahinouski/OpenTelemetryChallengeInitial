using System;
using System.Collections.Generic;
using System.Linq;

namespace  Gateway.Infrastructure.Users
{
    public class UserRepository : IUserRepository{
        private readonly UsersDbContext context;

        public UserRepository(UsersDbContext context)
        {
            this.context = context;
        }


        public IEnumerable<User> GetAll(int numberOfUsers){
            return context.Users
            .Take(numberOfUsers)
            .Select(x => x).
            ToList();
        }

    }
    
}