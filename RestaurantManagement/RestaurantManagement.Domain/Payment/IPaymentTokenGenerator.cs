using System;

namespace RestaurantManagement.Domain.Payment
{
    public interface IPaymentTokenGenerator
    {
        string Generate(int paymentId, DateTime paymentDateTime);
    }
}