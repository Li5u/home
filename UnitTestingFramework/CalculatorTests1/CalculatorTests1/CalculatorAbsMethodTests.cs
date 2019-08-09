using CSharpCalculator;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    [Parallelizable]
    class ClassCalculatorAbsMethodTests
    {
        private Calculator calculator;
        private readonly double _tolerance = 0.0000001;

        [OneTimeSetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(2, 2)]
        [TestCase(-2, 2)]
        [TestCase(0, 0)]       
        public void AbsMethodTest(double x, double expected)
        {
            var actualValue = calculator.Abs(x);
            Assert.AreEqual(expected, actualValue,_tolerance);
        }
    }
}
