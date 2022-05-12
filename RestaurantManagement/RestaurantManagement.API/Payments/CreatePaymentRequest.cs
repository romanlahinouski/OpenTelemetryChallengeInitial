namespace RestaurantManagement.Payments
{
    public class CreatePaymentRequest
    {
        public int OrderId { get; set; }

        public string PaymentType { get; set; }

    }
}