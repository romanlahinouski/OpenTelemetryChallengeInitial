using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;


namespace Gateway.Application.Guests.Commands
{

    public class CancelRegistrationCommandHandler : AsyncRequestHandler<CancelRegistrationCommand>
    {
        private readonly IGuestService guestService;

        public CancelRegistrationCommandHandler(IGuestService guestService)
        {
            this.guestService = guestService;
        }
        
        
        
        protected override async Task Handle(CancelRegistrationCommand request, CancellationToken cancellationToken)
        {
           await guestService.CancelRegistrationAsync(request);
        }
    }


}