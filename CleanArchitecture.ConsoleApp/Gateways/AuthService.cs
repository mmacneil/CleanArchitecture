
using CleanArchitecture.Core.Contracts;

namespace CleanArchitecture.ConsoleApp.Gateways
{
    public class AuthService : IAuthService
    {
        public bool IsAuthenticated()
        {
            return true;
        }
    }
}
