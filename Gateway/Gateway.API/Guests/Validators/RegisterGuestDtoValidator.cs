using FluentValidation;
using Gateway.Guests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.API.Guests.Validators
{
    public class RegisterGuestDtoValidator : AbstractValidator<RegisterGuestDto>
    {

        public RegisterGuestDtoValidator()
        {
            RuleFor(x => x.Email)
              .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
      
            RuleFor(x => x.RestaurantId).NotEmpty();
            RuleFor(x => x.RestaurantId).NotEqual(0);

        }
    }
}
