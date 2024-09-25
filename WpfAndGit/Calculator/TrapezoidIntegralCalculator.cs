using System;
using System.Linq;

namespace WPFIntegral
{
    public class TrapezoidIntegralCalculator : ICalculatorIntegral
    {
        public double Calculate(double down, double up, int N, Func<double, double> func)
        {
            double h = (up - down) / N;
            double sum = Enumerable.Range(0, N).Sum(s => func(s * h + down));

            return h * ((func(up) + func(down)) / 2 + sum);
        }
    }    
}