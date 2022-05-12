using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Domain.Payment
{
    public class Payment
    {
        public int PaymentId { get; private set; }

        private int orderId;

        private PaymentType paymentType;

        private  DateTime paymentDateTime;

        private string paymentToken;

        public Payment()
        {
            //ef core
        }

        private Payment(
            int orderId, 
            PaymentType paymentType)
        {
            this.orderId = orderId;
            this.paymentType = paymentType;         
            this.paymentDateTime = DateTime.UtcNow;
        }


        public static Payment Create(int orderId, PaymentType paymentType)
        {
            return new Payment(orderId, paymentType);
        }  

        public void AssignPaymentToken(string paymentToken)
        {
            this.paymentToken = paymentToken;
        }

        public DateTime GetDate()
        {
            return paymentDateTime;
        }
    }
}
