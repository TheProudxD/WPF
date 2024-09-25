using System;

namespace WPFIntegral
{
    public class RectangleIntegralCalculate : ICalculatorIntegral
    {            
        private double k = 1;

        public double Calculate(double down, double up, int N, Func<double, double> func)
        {
            double sum = 0;
            double h = (up - down) / N;

            down += h * k;
            for (int i = 0; i < N; i++)
            {
                sum += func(down + h * i);
            }

            return h * sum;
        }
    }
}
