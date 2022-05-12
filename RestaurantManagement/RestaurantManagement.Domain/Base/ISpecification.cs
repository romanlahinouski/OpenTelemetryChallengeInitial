using System.Linq.Expressions;

namespace RestaurantManagement.Domain.Base
{
    public interface ISpecification
    {
         Expression ToExpression(ParameterExpression restaurant);
    }
}