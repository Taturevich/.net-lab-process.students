using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorService.MathUtils.Tests
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void CallFactorial_10_3628800()
        {
            // Arrange
            // Act
            var value = Functions.Factorial(10);

            // Assert
            Assert.AreEqual((ulong)3628800, value);
        }
    }
}
