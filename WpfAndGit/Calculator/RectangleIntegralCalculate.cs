using System;

namespace WPFIntegral
{
    public class RectangleIntegralCalculate : ICalculatorIntegral
    {            
        private double _k = 1;

        public RectangleIntegralCalculate(double k) => _k = k;

        public double Calculate(double down, double up, int N, Func<double, double> func)
        {
            double sum = 0;
            double h = (up - down) / N;

            down += h * _k;
            for (int i = 0; i < N; i++)
            {
                sum += func(down + h * i);
            }

            return h * sum;
        }
    }
}
