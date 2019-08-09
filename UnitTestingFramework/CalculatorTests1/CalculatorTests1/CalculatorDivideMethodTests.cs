using CSharpCalculator;
using NUnit.Framework;
using System;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorDivideMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(4, 2, 2)]
        [TestCase(4, -1, -4)]
        [TestCase(0, 5, 0)]
        [TestCase(1, 4, 0.25)]
        public void DivideByNoNullDenominatorTest(double numerator, double denominator, double expected)
        {
            var actualValue = calculator.Divide(numerator, denominator);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }

        [TestCase(1, 0, Double.PositiveInfinity)]
        [TestCase(-1, 0, Double.NegativeInfinity)]
        public void DivideByNullDenominatorTest(double numerator, double denominator, double expected)
        {
            var actualValue = calculator.Divide(numerator, denominator);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }
    }
}
