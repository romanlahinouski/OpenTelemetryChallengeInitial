using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Gateway.Application.Guests.Commands
{
    public class RegisterGuestCommandHandler : AsyncRequestHandler<RegisterGuestCommand>
    {
        private readonly IGuestService guestService;

        public RegisterGuestCommandHandler(IGuestService guestService)
        {
            this.guestService = guestService;
        }
        
        protected override async Task Handle(RegisterGuestCommand request, CancellationToken cancellationToken)
        {
            await guestService.RegisterForAVisitAsync(request);
        }
    }
}
