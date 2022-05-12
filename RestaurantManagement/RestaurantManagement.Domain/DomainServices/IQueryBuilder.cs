using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RestaurantManagement.Domain.DomainServices
{
    public interface IQueryBuilder<T>
    {
        Expression<Func<T,bool>> Build(IEnumerable<ISpecification> expressions);
    }
}