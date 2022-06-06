using System;

namespace GuestManagement.Domain.Guests.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderItem[] Items {get;}

        public DateTimeOffset CreationTIme { get; }
        
        public string GuestEmail {get;}

        public Order(OrderItem[] items, string guestEmail)
        {
            if(items == null || items.Length <= 0)
                throw new Exception("List of order items can not be empty");
            else
               Items = items;

               GuestEmail = guestEmail;
               Id = Guid.NewGuid();
               CreationTIme = DateTimeOffset.UtcNow;
        }
    }
}