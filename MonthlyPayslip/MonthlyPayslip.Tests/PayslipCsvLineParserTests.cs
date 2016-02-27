using System;
using NUnit.Framework;

namespace MonthlyPayslip.Tests
{
    [TestFixture]
    public class PayslipCsvLineParserTests
    {
        private PayslipCsvLineParser _payslipCsvLineParser;

        [SetUp]
        public void Initialize()
        {
            _payslipCsvLineParser = new PayslipCsvLineParser();
        }

        [Test]
        public void ParseValidCsvLine()
        {
            var result = _payslipCsvLineParser.Parse("First Name,Last Name,60050,9%,01 March – 31 March");
            Assert.That(result.EmployeeDetails.FullName, Is.EqualTo("First Name Last Name"));
            Assert.That(result.PayPeriod, Is.EqualTo("01 March – 31 March"));
            Assert.That(result.Salary, Is.EqualTo(60050m));
            Assert.That(result.SuperRate, Is.EqualTo(0.09));
        }

        [TestCase(-1)]
        [TestCase(51)]
        public void ThrowExceptionOnSuperRateOutOfRange(int invalidSuperRate)
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _payslipCsvLineParser.Parse($"First Name,Last Name,9000,{invalidSuperRate}%,01 March – 31 March");
            });

            Assert.That(exception.Message, Is.EqualTo("Specified argument was out of the range of valid values."));
        }
    }
}
