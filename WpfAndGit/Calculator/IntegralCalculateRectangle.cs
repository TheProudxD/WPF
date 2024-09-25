using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFIntegral
{
    public class IntegralCalculateRectangle : ICalculatorIntegral
    {
        public double Calculate(double down, double up, int numIntaration, Func<double, double> subInterral)
        {
            double sum = 0;
            double h = (up - down) / numIntaration;

            for (int i = 0; i < numIntaration; i++)
            {
                sum += subInterral(down + h * i);
            }

            return h * sum;
        }
    }
}
