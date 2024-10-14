using System;

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

        public double Calculate(double down, double up, int n, Func<double, double> func)
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

            for (int i = 0; i < n; i++)
            {
                sum += func(down + h * i);
            }

            return h * sum;
        }
    }
}