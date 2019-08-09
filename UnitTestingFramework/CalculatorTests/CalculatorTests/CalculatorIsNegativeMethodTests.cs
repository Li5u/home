using CSharpCalculator;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorIsNegativeMethodTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(2, false)]
        [TestCase(2.45, false)]
        [TestCase(0, false)]
        [TestCase(-18.24, true)]
        [TestCase(-0.0000001, true)]
        public void CheckIfNegativeTest(double x, bool expected)
        {
            var actualValue = calculator.isNegative(x);
            Assert.AreEqual(expected, actualValue);
        }
    }
}
