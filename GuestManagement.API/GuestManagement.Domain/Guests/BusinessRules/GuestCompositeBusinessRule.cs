using GuestManagement.Domain.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestManagement.Domain.Guests.BusinessRules
{
   public class GuestCompositeBusinessRule : IBusinessRule<Guest>
    {
        private readonly IEnumerable<IBusinessRule<Guest>> rules;

        public GuestCompositeBusinessRule(IEnumerable<IBusinessRule<Guest>> rules)
        {
            this.rules = rules;
            ReasonPhrase = "All rules must be valid";
        }

        public string ReasonPhrase { get; }

        public async Task<ValidationResult> Validate(Guest guest)
        {
            List<ValidationResult> invalidResults 
                = new List<ValidationResult>();
            ValidationResult ValidationResult;

            foreach (var rule in rules)
            {
                ValidationResult = await rule.Validate(guest);
                if(!ValidationResult.IsValid())
                    invalidResults.Add(ValidationResult);
            }

            if (invalidResults.Any())
               return ValidationResult.CreateFailedValidationResult(JsonConvert.SerializeObject(invalidResults));

            return ValidationResult.CreateSuccessfullValidationResult();
        }
     
    }
}
