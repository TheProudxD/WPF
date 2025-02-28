using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WPFIntegral
{
    public enum RectangleIntegralType
    {
        Left,
        Middle,
        Right
    }

    public class RectangleIntegralCalculate : ICalculatorIntegral
    {
        private readonly double _k;

        private object _lock = new object();

        public RectangleIntegralCalculate(RectangleIntegralType rectangleIntegralType)
        {
            switch (rectangleIntegralType)
            {
                case RectangleIntegralType.Left:
                    _k = 0.0;
                    break;
                case RectangleIntegralType.Middle:
                    _k = 0.5;
                    break;
                case RectangleIntegralType.Right:
                    _k = 1.0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rectangleIntegralType), rectangleIntegralType, null);
            }
        }

        public double Calculate(double down, double up, int n, Func<double, double> func, CalculationType sequential)
        {
            if (down > up)
                throw new ArgumentException("Down are greater than Up");

            if (n <= 0)
                throw new ArgumentOutOfRangeException(nameof(n) + "is not positive");

            if (func == null)
                throw new ArgumentException("Function is null");

            double sum = 0;
            double h = (up - down) / n;
            down += h * _k;

            switch (sequential)
            {
                case CalculationType.Sequential:
                    sum = Enumerable.Range(0, n).Sum(i => func(down + h * i));
                    break;
                case CalculationType.Parallel:
                    sum = ParallelEnumerable.Range(0, n).Sum(i => func(down + h * i));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sequential), sequential, null);
            }

            return h * sum;
        }
    }
}