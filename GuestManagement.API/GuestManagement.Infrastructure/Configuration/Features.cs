using System;

using GuestManagement.Infrastructure.Configuration;

namespace GuestManagement.Infrastructure.Configuration
{
    public class Features
    {
        public AzureOptions AzureOptions { get; set; }

        public RedisOptions RedisOptions { get; set; }  
    }
}