namespace Demo_1.Tests
{
    using System;
    using System.Collections.Generic;

    using Demo_1;

    using NUnit.Framework;

    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc;

        [SetUp]
        public void Init()
        {
           this.calc = new Calculator();
        }

        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 0, double.NaN)]
        public void DivideTest(double a, double b, double expected)
        {
            Assert.AreEqual(expected, this.calc.Divide(a, b));
        }

        [Test]
        public void SummTest_NullValue_Exception()
        {
            List<double> values = null;

            Assert.Throws<ArgumentNullException>(() => this.calc.Summ(values));
        }

        [Test]
        public void SummTest_RealValues_21()
        {
            List<double> values = new List<double>() { 7, 7, 7 };

            Assert.AreEqual(21, this.calc.Summ(values));
        }
    }
}
