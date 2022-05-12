using System;
using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using GuestManagement.Domain.Base;
using MediatR;

namespace GuestManagement.Application.Guests.Commands
{
    public class VisitRegistrationCommandHandler : AsyncRequestHandler<VisitRegistrationCommand>
    {
        private readonly IGuestRepository guestRepository;
        private readonly IVisitRegistrationService visitRegistrationService;
        private readonly IUnitOfWork unitOfWork;

        public VisitRegistrationCommandHandler(
            IGuestRepository guestRepository,
            IVisitRegistrationService visitRegistrationService,
            IUnitOfWork unitOfWork
            )
        {
            this.guestRepository = guestRepository;
            this.visitRegistrationService = visitRegistrationService;
            this.unitOfWork = unitOfWork;
        }

        protected override async Task Handle(VisitRegistrationCommand request, CancellationToken cancellationToken)
        {

            var guest = await guestRepository.GetGuestByEmailAsync(request.Email);

           _  =  guest ?? throw new NoGuestPresentInTheSystemException("User is not present in the system");
   
            await visitRegistrationService.RegisterVisit(guest, request.RestaurantId);

            await unitOfWork.CommitChangesAsync();
        }
    }
}
