using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace WPFIntegral
{
    public enum CalculationType
    {
        Sequential,
        Parallel
    }

    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void btCalculate_Click(object sender, RoutedEventArgs e) => DoCalculate();

        private void DoCalculate()
        {
            double upLimit = Convert.ToDouble(tbUpLimit.Text);
            double downLimit = Convert.ToDouble(tbDownLimit.Text);
            int count = Convert.ToInt32(tbCount.Text);
            ICalculatorIntegral calculator = GetCalculator();
            Func<double, double> func = x => 12 * x - Math.Log(11 * x) - 11;

            var stopwatch = Stopwatch.StartNew();
            double sequentialResult = calculator.Calculate(downLimit, upLimit, count, func, CalculationType.Sequential);
            stopwatch.Stop();
            double sequentialTime = stopwatch.ElapsedMilliseconds;

            stopwatch = Stopwatch.StartNew();
            double parallelResult = calculator.Calculate(downLimit, upLimit, count, func, CalculationType.Parallel);
            stopwatch.Stop();
            double parallelTime = stopwatch.ElapsedMilliseconds;

            tbAnswer.Text =
                $"Последовательно: {sequentialResult} (Время: {sequentialTime} мс)\nПараллельно: {parallelResult} (Время: {parallelTime} мс)";
        }

        private ICalculatorIntegral GetCalculator()
        {
            switch (cmbVarietion.SelectedIndex)
            {
                case 0:
                    return new RectangleIntegralCalculate(RectangleIntegralType.Middle);
                case 1:
                    return new TrapezoidIntegralCalculator();
                case 2:
                    return new SimpsonIntegralCalculator();
                default:
                    throw new Exception("Выбран не поддерживаемый метод");
            }
        }
    }
}