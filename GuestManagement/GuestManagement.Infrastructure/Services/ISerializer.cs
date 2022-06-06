using System;
using System.Collections.Generic;
using System.Text;

namespace GuestManagement.Infrastructure.Services
{
    public interface ISerializer <T>
    {
         string Serialize(T obj);

        T Deserialize(string value);

    }
}
