using System;
using System.Threading.Tasks;
using GuestManagement.Domain.Base;

namespace GuestManagement.Domain.Guests.BusinessRules{

    public class GuestMustBePresentBusinessRule : IBusinessRule<Guest>
    {

        public string ReasonPhrase => throw new NotImplementedException();

        private IGuestRepository _guestRepository;

        public GuestMustBePresentBusinessRule(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;

        }

        public  Task<ValidationResult> Validate(Guest entity)
        {
           if(entity == null){
               return Task.FromResult(ValidationResult.CreateFailedValidationResult("Guest must be unique"));
           } 
           else{
               return Task.FromResult(ValidationResult.CreateSuccessfullValidationResult());
           }
        }
    }
}