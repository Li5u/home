using CSharpCalculator;
using NUnit.Framework;
using System;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorCosMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [OneTimeSetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(Math.PI / 6, 0.86602540378)]
        [TestCase(Math.PI / 3, 0.5)]
        [TestCase(Math.PI / 4, 0.70710678118)]
        [TestCase(13 * Math.PI / 6, 0.86602540378)]
        [TestCase(0, 1)]
        public void CalculateCosOfPositiveAnglesTest(double radian, double expected)
        {
            var actualValue = calculator.Cos(radian);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }

        [TestCase(-Math.PI / 6, 0.86602540378)]
        [TestCase(-Math.PI / 3, 0.5)]
        [TestCase(-13 * Math.PI / 3, 0.5)]
        [TestCase(-Math.PI / 4, 0.70710678118)]
        public void CalculateCosOfNegativeAnglesTest(double radian, double expected)
        {
            var actualValue = calculator.Cos(radian);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }
    }
}
