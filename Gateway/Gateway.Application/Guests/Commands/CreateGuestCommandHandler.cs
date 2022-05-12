using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Gateway.Application.Guests;

namespace Gateway.Application.Guests.Commands
{
    public class CreateGuestCommandHandler : AsyncRequestHandler<CreateGuestCommand>
    {
      
        private readonly IGuestService guestService;

        public CreateGuestCommandHandler(IGuestService guestService)
        {           
            this.guestService = guestService;
        }

        protected override  async Task Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {                  
            await guestService.CreateGuestAsync(request);          
        }
    }
}
