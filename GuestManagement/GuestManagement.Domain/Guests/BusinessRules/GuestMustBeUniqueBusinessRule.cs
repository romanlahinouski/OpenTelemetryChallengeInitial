using GuestManagement.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Domain.Guests.BusinessRules
{
    public class GuestMustBeUniqueBusinessRule : IBusinessRule<Guest>
    {
        private readonly IGuestRepository guestRepository;

        public GuestMustBeUniqueBusinessRule(IGuestRepository guestRepository)
        {
            this.guestRepository = guestRepository;
            ReasonPhrase = "User must be unique";
        }

        public string ReasonPhrase { get; }

        public async Task<ValidationResult> Validate(Guest guest)
        {
            var guestInTheSystem = await guestRepository.GetGuestByEmailAsync(guest.Email);         
                if (guestInTheSystem == null)
                    return ValidationResult.CreateSuccessfullValidationResult();

                return ValidationResult.CreateFailedValidationResult(ReasonPhrase);              
        }
    }
}
