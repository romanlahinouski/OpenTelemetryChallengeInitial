using MediatR;
using RestaurantManagement.Domain.Payment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Payments.Commands
{
    public class CreatePaymentCommandHandler : AsyncRequestHandler<CreatePaymentCommand>
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IPaymentTokenGenerator paymentTokenGenerator;

        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IPaymentTokenGenerator paymentTokenGenerator)
        {
            this.paymentRepository = paymentRepository;
            this.paymentTokenGenerator = paymentTokenGenerator;
        }
        
        
        protected override async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            PaymentType paymentType;

            if (!Enum.TryParse<PaymentType>(request.PaymentType, out paymentType))
                throw new InvalidPaymentTypeException("Incorrect payment type");

            var payment = Payment.Create(request.OrderId, paymentType);

            await paymentRepository.AddPayment(payment);

            string paymentToken = paymentTokenGenerator.Generate(payment.PaymentId, payment.GetDate());

            payment.AssignPaymentToken(paymentToken);

            paymentRepository.UpdatePayment(payment);

        }
    }
}
