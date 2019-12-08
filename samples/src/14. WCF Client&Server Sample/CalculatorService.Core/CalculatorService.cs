using System.Security.Permissions;

namespace CalculatorService.Core
{
    using global::CalculatorService.MathUtils;

    public class CalculatorService : ICalculatorService
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Manager")]
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public int Multiple(int a, int b)
        {
            return a * b;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "User")]
        public ulong Factorial(ulong range)
        {
            return Functions.Factorial(range);
        }
    }
}