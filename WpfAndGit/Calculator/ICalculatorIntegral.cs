using System;

namespace WPFIntegral
{
    public interface ICalculatorIntegral
    {
        double Calculate(double downLimit, double upLimit, int count, Func<double, double> func,
            CalculationType sequential);
    }
}