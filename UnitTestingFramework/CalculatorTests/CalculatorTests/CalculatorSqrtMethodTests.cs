using CSharpCalculator;
using NUnit.Framework;
using System;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorSqrtMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(4, 2)]
        [TestCase(7.1, 2.66458251889)]
        [TestCase(0, 0)]
        [TestCase(-4, -2)]
        public void TakeSquareRootFromPositiveNumber(double number, double expected)
        {
            var actualValue = calculator.Sqrt(number);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }

        [TestCase(-3.1, Double.NaN)]
        public void TakeSquareRootFromNegativeNumber(double number, double expected)
        {
            var actualValue = calculator.Sqrt(number);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }
    }
}
