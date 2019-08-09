using CSharpCalculator;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorIsPositiveMethodTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(2, true)]
        [TestCase(2.45, true)]
        [TestCase(0, false)]
        [TestCase(-18.24, false)]
        public void CheckIfPositive(double x, bool expected)
        {
            var actualValue = calculator.isPositive(x);
            Assert.AreEqual(expected, actualValue);
        }
    }
}
