using System;

namespace WPFIntegral
{
    public class SimpsonIntegralCalculator : ICalculatorIntegral
    {
        public double Calculate(double down, double up, int N, Func<double, double> func, CalculationType sequential)
        {
            double sum = 0;
            double h = (up - down) / N;

            for (int i = 1; i < N/2+1; i++)
            {
                sum += 2*func(down + (2 * i - 1) * h);
                sum += 4*func(down +  2 * i * h);
            }

            return h/3 * (func(up) + func(down) + sum);
        }
    }
}