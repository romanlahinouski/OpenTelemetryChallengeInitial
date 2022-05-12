using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Domain.Payment
{
  public interface IPaymentRepository 
    {
         Task AddPayment(Payment payment);

         void UpdatePayment(Payment payment);
    }
}
