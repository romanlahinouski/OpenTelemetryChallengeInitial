using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Domain.Base
{
    public class ValidationResult
    {
        public bool IsValid { get; private set; }

        public string ReasonPhrase { get; private set; }

        private ValidationResult(bool isValid, string reasonPhrase)
            : this(isValid)
        {
            ReasonPhrase = reasonPhrase;
        }
        private ValidationResult(bool isValid)
        {
            IsValid = isValid;
        }

        public static ValidationResult CreateFailedValidationResult(string reasonPhrase)
        {
            return new ValidationResult(false, reasonPhrase);
        }

        public static ValidationResult CreateSuccessfullValidationResult()
        {
            return new ValidationResult(true);
        }
    }
}
