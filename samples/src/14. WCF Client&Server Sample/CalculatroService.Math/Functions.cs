namespace CalculatorService.MathUtils
{
    using System.Collections.Generic;

    public static class Functions
    {
        public static ulong Factorial(ulong range)
        {
            if (range <= 1)
            {
                return 1;
            }

            return range * Factorial(range - 1);
        }

        public static IEnumerable<int> GetFibonacciSequence()
        {
            var first = 0;
            var second = 1;

            yield return first;
            yield return second;

            while (true)
            {
                var current = first + second;
                yield return current;

                first = second;
                second = current;
            }
        }
    }
}
