namespace GuestManagement.Domain.Guests.Orders
{
    public class OrderItem
    {
        public OrderItem(int itemId, int count)
        {
            this.ItemId = itemId;
            this.Count = count;

        }
        public int ItemId { get; }

        public int Count { get; }

    

    }
}