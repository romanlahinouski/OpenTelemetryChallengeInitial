using RestaurantManagement.Domain.Payment;
using RestaurantManagement.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Payments
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentDbContext dbContext) : base(dbContext)
        {

        }
        
        public async Task AddPayment(Payment payment)
        {
           await  base.Add(payment);
        }

        public  void UpdatePayment(Payment payment)
        {
             base.Update(payment);          
        }
    }
}
