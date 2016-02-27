using System;
using MonthlyPayslip.ExtensionMethods;
using NUnit.Framework;

namespace MonthlyPayslip.Tests.ExtensionMethods
{
    [TestFixture]
    public class StringExtensionMethodsTests
    {
        [TestCase("0.9", 0.9)]
        [TestCase("9", 9)]
        [TestCase("15", 15)]
        [TestCase("115", 115)]
        [TestCase("123.456", 123.456)]
        public void ExtractDecimalFromString(string input, decimal expected)
        {
            Assert.That(input.ParseAsDecimal(), Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase("a9")]
        [TestCase("9b")]
        [TestCase("0,9")]
        [TestCase("abc")]
        public void ThrowExceptionOnIncorrectDecimalFormatFromString(string input)
        {
            Assert.Throws<FormatException>(() =>
            {
                input.ParseAsDecimal();
            });
        }

        [TestCase("0.9%", 0.009)]
        [TestCase("9%", 0.09)]
        [TestCase("15%", 0.15)]
        [TestCase("115%", 1.15)]
        [TestCase("123.456%", 1.23456)]
        public void ExtractPercentageFromString(string input, decimal expected)
        {
            Assert.That(input.ParseAsPercentage(), Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase("9a%")]
        [TestCase("9%b")]
        [TestCase("0,9%")]
        [TestCase("abc")]
        public void ThrowExceptionOnIncorrectPercentageFormatFromString(string input)
        {
            Assert.Throws<FormatException>(() =>
            {
                input.ParseAsPercentage();
            });
        }
    }
}
