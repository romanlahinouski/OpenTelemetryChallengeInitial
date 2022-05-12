using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Domain.Payment
{
    public class PaymentTokenGenerator : IPaymentTokenGenerator
    {

        public string Generate(int paymentId, DateTime paymentDateTime)
        {
            string paymentIdDateTimeString = $"{paymentId}{paymentDateTime}";

            return paymentIdDateTimeString + paymentIdDateTimeString.GetHashCode();
        }

    }
}
