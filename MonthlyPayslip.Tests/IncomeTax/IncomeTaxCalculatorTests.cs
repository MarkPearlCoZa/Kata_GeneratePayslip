using System;
using MonthlyPayslip.IncomeTax;
using NUnit.Framework;

namespace MonthlyPayslip.Tests.IncomeTax
{
    [TestFixture]
    public class IncomeTaxCalculatorTests
    {
        private IncomeTaxCalculator _incomeTaxCalculator;

        [SetUp]
        public void Initialize()
        {
            _incomeTaxCalculator = new IncomeTaxCalculator();
        }

        [TestCase(0, 0)]
        [TestCase(60050, 922)]
        [TestCase(120000, 2696)]
        public void GivenAnnualSalary_CalculateCorrectTax(int annualSalary, int expectedIncomeTax)
        {
            Assert.That(_incomeTaxCalculator.CalculateMonthlyPayableIncomeTaxFrom(annualSalary), Is.EqualTo(expectedIncomeTax));
        }

        [Test]
        public void GivenInvalidSalary_ThrowException()
        {
            var msg = Assert.Throws<ArgumentException>(() => _incomeTaxCalculator.CalculateMonthlyPayableIncomeTaxFrom(-1));
            Assert.That(msg.Message, Is.EqualTo("Annual Salary cannot be less than zero"));
        }
    }
}