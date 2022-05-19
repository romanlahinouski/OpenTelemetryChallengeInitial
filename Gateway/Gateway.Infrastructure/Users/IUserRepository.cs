using System;
using System.Collections.Generic;
using System.Linq;

namespace  Gateway.Infrastructure.Users
{
    public interface IUserRepository{

     IEnumerable<User> GetAll(int numberOfUsers);
          
    }
    
}