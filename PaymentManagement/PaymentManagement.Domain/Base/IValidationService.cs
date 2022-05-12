namespace PaymentManagement.Domain.Base
{
    public interface IValidationService
    {
         Task<ValidationResult> Validate();
    }
}