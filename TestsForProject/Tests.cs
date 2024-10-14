using System;
using NUnit.Framework;
using WPFIntegral;

namespace TestsForProject
{
    public class RectangleCalculatorTests
    {
        private ICalculatorIntegral _calculator;
        private Func<double, double> _func;
        private int _downLimit;
        private int _upperLimit;
        private int _countOfSplits;

        [SetUp]
        public void Setup()
        {
            _calculator = new RectangleIntegralCalculate(RectangleIntegralType.Middle);
            _func = x => 12 * x - Math.Log(11 * x) - 11;
            _downLimit = 1;
            _upperLimit = 100_000;
            _countOfSplits = 100_000_000;
        }

        [Test]
        public void Calculator_RectangleCalculator_ReturnsCorrectResult()
        {
            double actual = _calculator.Calculate(_downLimit, _upperLimit, _countOfSplits, _func);
            Assert.That(actual, Is.EqualTo(5.9997609 * 1e10).Within(1e2));
        }

        [Test]
        public void WhenDownIsGreaterThanUpperLimit_ThrowsException()
        {
            int downLimit = 100;
            int upperLimit = 0;

            Assert.Throws<ArgumentException>(() => _calculator.Calculate(downLimit, upperLimit, _countOfSplits, _func));
        }

        [Test]
        public void WhenCountOfSplitsIsZeroOrLess_ThrowsException()
        {
            int countOfSplits = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _calculator.Calculate(_downLimit, _upperLimit, countOfSplits, _func));
        }

        [Test]
        public void WhenFunctionIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Calculate(_downLimit, _upperLimit, _countOfSplits, null));
        }

        [Test]
        public void ResultIsGreaterThanOrEqualToZero()
        {
            double actual = _calculator.Calculate(_downLimit, _upperLimit, _countOfSplits, _func);
            Assert.That(actual, Is.GreaterThanOrEqualTo(0));
        }
    }
}