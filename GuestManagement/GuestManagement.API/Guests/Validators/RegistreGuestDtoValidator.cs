using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestManagement.API.Guests.Validators
{
    public class RegistreGuestDtoValidator : AbstractValidator<RegisterGuestRequest>
    {


        public RegistreGuestDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .MinimumLength(1)
                .Matches("^[A-Za-z]+$");
          
            RuleFor(x => x.LastName)
                .NotNull()
                .MinimumLength(1)
                .Matches("^[A-Za-z]+$"); 

            RuleFor(x => x.DateOfBirth).NotNull();
            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now.AddYears(-18));

            RuleFor(x => x.PhoneNumber)
                .MinimumLength(9)
                .Matches("^[0-9]+$")
                .WithMessage("Phone number must contain only digits");

            RuleFor(x => x.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        
        }
    }
}
