namespace GuestManagement.API.Guests
{
    public class AcceptOrderDto
    {
        public string Email { get; set; }

        public OrderItemDto [] OrderItems {get; set;}

    }
}