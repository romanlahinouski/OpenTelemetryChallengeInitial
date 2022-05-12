using GuestManagement.Domain.Base;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Guests.IntergrationEvents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GuestManagement.Application.Guests.Commands
{
    public class CreateGuestCommandHandler : AsyncRequestHandler<CreateGuestCommand>
    {
        private readonly IGuestRepository guestRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBusinessRule<Domain.Guests.Guest> compositeBusinessRule;
        private readonly IIntegrationEventsQueue eventsQueue;

        public CreateGuestCommandHandler(IGuestRepository guestRepository, 
        IUnitOfWork unitOfWork, 
        IBusinessRule<Domain.Guests.Guest> compositeBusinessRule,
        IIntegrationEventsQueue eventsQueue
        )
        {
            this.guestRepository = guestRepository;
            this.unitOfWork = unitOfWork;
            this.compositeBusinessRule = compositeBusinessRule;
            this.eventsQueue = eventsQueue;
        }
        protected override async Task Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = Domain.Guests.Guest.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.DateOfBirth);

            var validationResult = await compositeBusinessRule.Validate(guest);

            if(!validationResult.IsValid())
                throw new BusinessRuleValidationException(validationResult.ReasonPhrase);
                 

            await guestRepository.AddAsync(guest);

            await unitOfWork.CommitChangesAsync();

            

            eventsQueue.PublishIntegrationEvent(new GuestCreateIntegrationEvent(Guid.Parse(guest.GuestId)));
   
        }
    }
}
