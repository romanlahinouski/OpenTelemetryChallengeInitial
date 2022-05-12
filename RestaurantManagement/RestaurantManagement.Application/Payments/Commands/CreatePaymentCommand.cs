using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Application.Payments.Commands
{
    public class CreatePaymentCommand : IRequest
    {
        public int OrderId { get; set; }

        public string PaymentType { get; set; }

        public CreatePaymentCommand(int orderId, string paymentType)
        {
            OrderId = orderId;
            PaymentType = paymentType;
        }
    }
}
