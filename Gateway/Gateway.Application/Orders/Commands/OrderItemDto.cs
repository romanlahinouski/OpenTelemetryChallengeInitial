namespace Gateway.Application.Orders.Commands
{
    public class OrderItemDto
    {      
        public int Count { get; set; }

        public int ItemId { get; set; }

        public OrderItemDto()
        {
        }
    }
}