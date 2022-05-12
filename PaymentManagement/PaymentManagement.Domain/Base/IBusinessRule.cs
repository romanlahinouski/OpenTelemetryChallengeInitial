namespace PaymentManagement.Domain.Base
{
    public interface IBusinessRule<T> where T : Entity
    {
         Task<ValidationResult> Validate(T entity);
    }
}