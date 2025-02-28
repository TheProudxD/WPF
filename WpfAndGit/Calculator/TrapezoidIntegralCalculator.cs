using System;
using System.Linq;
using System.Threading.Tasks;

namespace WPFIntegral
{
    public class TrapezoidIntegralCalculator : ICalculatorIntegral
    {
        private object _lock = new object();

        public double Calculate(double down, double up, int n, Func<double, double> func, CalculationType type)
        {
            double h = (up - down) / n;
            double sum = 0;
            switch (type)
            {
                case CalculationType.Sequential:            
                    sum = Enumerable.Range(0, n).Sum(s => func(s * h + down));
                    break;
                case CalculationType.Parallel:
                    sum = ParallelEnumerable.Range(0, n).Sum(s => func(s * h + down));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return h * ((func(up) + func(down)) / 2 + sum);
        }
    }    
}