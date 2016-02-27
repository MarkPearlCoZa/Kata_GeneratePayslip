using System;
using MonthlyPayslip.IncomeTax;
using NUnit.Framework;

namespace MonthlyPayslip.Tests.IncomeTax
{
    [TestFixture]
    public class IncomeTaxTableTests
    {
        private IncomeTaxTable _incomeTaxTable;

        [SetUp]
        public void Initialize()
        {
            _incomeTaxTable = new IncomeTaxTable();
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(18200, 0, 0, 0)]
        [TestCase(18201, 0, 0.19, 18200)]
        [TestCase(37000, 0, 0.19, 18200)]
        [TestCase(37001, 3572, 0.325, 37000)]
        [TestCase(80000, 3572, 0.325, 37000)]
        [TestCase(80001, 17547, 0.37, 80000)]
        [TestCase(180000, 17547, 0.37, 80000)]
        [TestCase(180001, 54547, 0.45, 180000)]
        public void GivenTaxableIncome_CalculateCorrectTaxBracket(
            decimal yearlyTaxableIncome,
            decimal expectedIncomeThreshold,
            decimal expectedMarginalTaxRate,
            decimal expectedAccumulatedTaxFromPreviousBracket)
        {
            var result = _incomeTaxTable.GetTaxBracketFor(yearlyTaxableIncome);

            Assert.That(result.AccumulatedTaxFromPreviousBracketNew, Is.EqualTo(expectedIncomeThreshold), "Fixed Taxable Calculation incorrect");
            Assert.That(result.MarginalTaxRate, Is.EqualTo(expectedMarginalTaxRate), "Rate per dollar incorrect");
            Assert.That(result.IncomeThreshold, Is.EqualTo(expectedAccumulatedTaxFromPreviousBracket), "Fixed deductable aboumt before tax rate incorrect");
        }

        [Test]
        public void AnnualSalaryCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => _incomeTaxTable.GetTaxBracketFor(-0.01m));
        }

    }
}