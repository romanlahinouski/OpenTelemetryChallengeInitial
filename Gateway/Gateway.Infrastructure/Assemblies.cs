using System.Reflection;
using App = Gateway.Application.Guests.Commands;
using Infra = Gateway.Infrastructure;

namespace Gateway.Infrastructure
{
    public static class Assemblies
    {
        public static Assembly Application { get; } = typeof(App.CreateGuestCommand).Assembly;
        public static Assembly Infrastructure { get; } = typeof(Infra.Assemblies).Assembly;
       
        public static Assembly[] SolutionAsseblies { get; } = new Assembly[]
        {
            Application,
            Infrastructure,     
            
        };
    }
}
