using FluentValidation;
using Gateway.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.API.Guests.Validators
{
    public class CreateGuestDtoValidator : AbstractValidator<CreateGuestDto>
    {

        public CreateGuestDtoValidator()
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
    
            RuleFor(x => x.PhoneNumber)
                .MinimumLength(9)
                .Matches("^[0-9]+$")
                .WithMessage("Phone number must contain only digits");

            RuleFor(x => x.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);

              
        }
    }
}
