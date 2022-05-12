using System;
using Newtonsoft.Json;

namespace OrderManagement.Models
{
    public class Order
    {
        public string GuestEmail { get; set; }
        public DateTimeOffset CreationTime { get; set;}
        public OrderItem [] Items { get; set; }      

        [JsonProperty(propertyName: "id")]
        public Guid Id { get; set;}
                    
    }
}
