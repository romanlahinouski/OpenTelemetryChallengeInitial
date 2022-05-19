using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gateway.Application.Payments
{
    public class CreatePaymentCommandHandler : AsyncRequestHandler<CreatePaymentCommand>
    {
        private readonly IPaymentCreationService paymentCreationService;

        public CreatePaymentCommandHandler(IPaymentCreationService paymentCreationService)
        {
            this.paymentCreationService = paymentCreationService;
        }
        
        protected override async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            await paymentCreationService.CreatePaymentAsync(request.OrderId, request.PaymentType);
        }
    }
}
