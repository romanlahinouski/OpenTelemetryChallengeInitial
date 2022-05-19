using System.Reflection;
using App = GuestManagement.Application.Guests;
using Infra = GuestManagement.Infrastructure;

namespace GuestManagement.Infrastructure
{
    public static class Assemblies
    {
        public static Assembly Application { get; } = typeof(App.Commands.CreateGuestCommand).Assembly;
        public static Assembly Infrastructure { get; } = typeof(Infra.Assemblies).Assembly;
        public static Assembly API { get; } = typeof(Infra.Assemblies).Assembly;

        public static Assembly[] SolutionAsseblies { get; } = new Assembly[]
        {
            Application,
            Infrastructure,
            API
        };
    }
}
