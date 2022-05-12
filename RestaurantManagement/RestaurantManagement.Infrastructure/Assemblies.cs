using System.Reflection;
using Infra = RestaurantManagement.Infrastructure;
using App = RestaurantManagement.Application;

namespace RestaurantManagement.Infrastructure
{
    public static class Assemblies
    {
     
        public static Assembly Infrastructure { get; } = typeof(Infra.Assemblies).Assembly;

        public static Assembly Application { get; } = typeof(App.Restaurants.Commands.CreateRestaurantCommand).Assembly;


        public static Assembly[] SolutionAsseblies { get; } = new Assembly[]
        {         
            Infrastructure, 
            Application
        };
    }
}
