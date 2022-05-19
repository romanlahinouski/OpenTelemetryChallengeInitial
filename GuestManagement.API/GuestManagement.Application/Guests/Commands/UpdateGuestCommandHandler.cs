using System;
using System.Threading;
using System.Threading.Tasks;
using GuestManagement.Domain.Base;
using GuestManagement.Domain.Guests;
using MediatR;

namespace GuestManagement.Application.Guests.Commands
{
    public class UpdateGuestCommandHandler : AsyncRequestHandler<UpdateGuestCommand>
    {
        private readonly IMapperWrapper<Guest, Domain.Guests.Guest> mapperWrapper;
        private readonly IGuestRepository guestRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateGuestCommandHandler(IMapperWrapper<Guest, Domain.Guests.Guest> mapperWrapper,
         IGuestRepository guestRepository,
         IUnitOfWork unitOfWork
         )
      {
            this.mapperWrapper = mapperWrapper;
            this.guestRepository = guestRepository;
            this.unitOfWork = unitOfWork;
        }
        
        protected override async Task Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
           
           var guest = await guestRepository.GetGuestByEmailAsync(request.Email);

            _ = guest ?? throw new ArgumentNullException(request.Guest.Email);

           var updatedGuest = mapperWrapper.Map(request.Guest, guest);

           guestRepository.Update(updatedGuest);

           await unitOfWork.CommitChangesAsync();
        }
    }
}