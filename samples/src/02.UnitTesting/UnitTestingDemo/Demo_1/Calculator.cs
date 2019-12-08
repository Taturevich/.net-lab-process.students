namespace Demo_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Calculator
    {
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                return double.NaN;
            }

            return a / b;
        }

        public double Summ(IEnumerable<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Sum();
        }
    }
}
