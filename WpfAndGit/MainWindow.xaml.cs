using System;
using System.Windows;

namespace WPFIntegral
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }

        private void DoCalculate()
        {
            double upLimit = Convert.ToDouble(tbUpLimit.Text);
            double downLimit = Convert.ToDouble(tbDownLimit.Text);
            int count = Convert.ToInt32(tbCount.Text);
            ICalculatorIntegral calculator = GetCalculator();
            double answer = calculator.Calculate(downLimit, upLimit, count, IntegrateFunction);
            tbAnswer.Text = answer.ToString();
        }

        private ICalculatorIntegral GetCalculator()
        {
            switch (cmbVarietion.SelectedIndex)
            {
                case 0:
                    return new RectangleIntegralCalculate();
                case 1:
                    return new TrapezoidIntegralCalculator();
                case 2:
                    return new SimpsonIntegralCalculator();
                default:
                    throw new Exception("Выбран не поддерживаемый метод");
            }
        }

        private double IntegrateFunction(double x) => x * x;
    }
}