using MonthlyPayslip.ExtensionMethods;
using NUnit.Framework;

namespace MonthlyPayslip.Tests.ExtensionMethods
{
    [TestFixture]
    public class DecimalExtensionMethodsTests
    {
        [TestCase(0.5, 1)]
        [TestCase(0.999, 1)]
        [TestCase(5.5, 6)]
        [TestCase(5.99999, 6)]
        public void StandardRounding(decimal input, decimal expected)
        {
            Assert.That(input.WithRounding(), Is.EqualTo(expected));
        }
    }
}