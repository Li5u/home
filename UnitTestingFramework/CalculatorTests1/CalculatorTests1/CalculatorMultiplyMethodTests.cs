using CSharpCalculator;
using NUnit.Framework;
using System;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorMultiplyMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(2, 2, 4)]
        [TestCase(4, -1.1, -4.4)]
        [TestCase(0, 5, 0)]
        [TestCase(5, 0, 0)]
        public void MultiplyByNotInfinityMultiplierTest(double firstMultiplier, double secondMultiplier, double expected)
        {
            var actualValue = calculator.Multiply(firstMultiplier, secondMultiplier);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }

        [TestCase(0, Double.PositiveInfinity, Double.NaN)]
        [TestCase(Double.PositiveInfinity, -14.4, Double.NegativeInfinity)]
        [TestCase(Double.PositiveInfinity, 14.4, Double.PositiveInfinity)]
        public void MultuplyByInfinityMultiplierTest(double firstMultiplier, double secondMultiplier, double expected)
        {
            var actualValue = calculator.Multiply(firstMultiplier, secondMultiplier);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }
    }
}
