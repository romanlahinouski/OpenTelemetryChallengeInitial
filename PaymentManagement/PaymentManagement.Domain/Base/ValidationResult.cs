namespace PaymentManagement.Domain.Base
{
    public class ValidationResult
    {
        private bool isValid;
        public string ReasonPhrase { get; private set; }

        private ValidationResult(bool isValid,string reasonPhrase) 
            : this(isValid)
        {          
            ReasonPhrase = reasonPhrase;
        }
        private ValidationResult(bool isValid)
        {
            this.isValid = isValid;
        }

        public static ValidationResult CreateFailedValidationResult(string reasonPhrase)
        {
            return new ValidationResult(false, reasonPhrase);
        }

        public static ValidationResult CreateSuccessfullValidationResult()
        {
            return new ValidationResult(true);
        }

        public bool IsValid(){
            return isValid;
        }
    }
}