using CSharpCalculator;
using NUnit.Framework;


namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class CalculatorPowMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [OneTimeSetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(2, 2, 4)]
        [TestCase(-2, 0, 1)]
        [TestCase(2, 0, 1)]
        public void RaiseToAPower(double number, double power, double expected)
        {
            var actualValue = calculator.Pow(number, power);
            Assert.AreEqual(expected, actualValue, _tolerance);
        }
    }
}
