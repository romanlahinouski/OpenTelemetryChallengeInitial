namespace PaymentManagement.Domain.Payments.Services
{
    public class OrderPaymentService
    {
    

        //1) We need to check the business rules on our order
        //2) Put lock on the stock which is being ordered and release lock if order is cancelled and reduce stock if purchase is completed
        //3) We need to record payment in database

        public OrderPaymentService()
        {
          
        }
        public async Task ProcessOrderPayment()
        {
          
        }

    }
}
