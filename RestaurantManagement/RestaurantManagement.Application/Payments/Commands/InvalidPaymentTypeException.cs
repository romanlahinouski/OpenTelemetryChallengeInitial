using RestaurantManagement.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Application.Payments.Commands
{
    public class InvalidPaymentTypeException : DomainException
    {

        public InvalidPaymentTypeException(string message) 
            : base(message)
        {

        }
    }
}
