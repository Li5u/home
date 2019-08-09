using CSharpCalculator;
using NUnit.Framework;
using System;


namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorSubMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(4.1, 2, 2.1)]
        [TestCase(-2, 5, -7)]
        [TestCase(5, 2, 3)]
        [TestCase(2.5, 2.5, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, Double.PositiveInfinity, Double.NegativeInfinity)]
        public void CalculateSubtractTest(double x, double y, double expected)
        {
            var actualValue = calculator.Sub(x, y);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }
    }
}
