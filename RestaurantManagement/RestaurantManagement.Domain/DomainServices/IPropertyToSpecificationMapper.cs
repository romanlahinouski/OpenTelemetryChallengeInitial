using System.Collections.Generic;
using RestaurantManagement.Domain.Base;

namespace RestaurantManagement.Domain.DomainServices
{
    public interface IPropertyToSpecificationMapper
    {
        IEnumerable<ISpecification> Map(params (string Name, object Value) []  propeties);
    }
}