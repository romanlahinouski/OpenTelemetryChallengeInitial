using GuestManagement.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Domain.Guests.BusinessRules
{
   public class GuestAgeBusinessRule : IBusinessRule<Guest>
    {
        public string ReasonPhrase { get; }

        public GuestAgeBusinessRule()
        {
            ReasonPhrase = "Guest must be older then 18";
        }

        public Task<ValidationResult> Validate(Guest guest)
        {
            var guestDateOfBirth = guest.DateOfBirth;
            var yearsDifference = DateTime.Now.Year - guestDateOfBirth.Year;
            int clientAge;
            DateTime dateTimeNow = DateTime.Now;

            if (dateTimeNow.Month < guestDateOfBirth.Month
                || (dateTimeNow.Month == guestDateOfBirth.Month && dateTimeNow.Day < guestDateOfBirth.Day))
                clientAge = yearsDifference - 1;
            else
                clientAge = yearsDifference + 1;

            if (clientAge > 18)
                return Task.FromResult(ValidationResult.CreateSuccessfullValidationResult());

            return Task.FromResult(ValidationResult.CreateFailedValidationResult(ReasonPhrase));  
        }
    }
}
