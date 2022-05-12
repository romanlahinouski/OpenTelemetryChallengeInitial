namespace RestaurantManagement.Domain.Base
{
    public interface IBusinessRule<T>
    {
         ValidationResult Validate(T entity);

         string ReasonPhrase { get; }
    }
}
