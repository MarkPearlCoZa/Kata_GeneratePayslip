using System;
using MonthlyPayslip.ExtensionMethods;

namespace MonthlyPayslip.IncomeTax
{
    public class IncomeTaxCalculator
    {
        private const int MonthsInYear = 12;
        private readonly IncomeTaxTable _incomeTaxTable;

        public IncomeTaxCalculator(IncomeTaxTable incomeTaxTable = null)
        {
            _incomeTaxTable = new IncomeTaxTable() ?? incomeTaxTable;
        }

        public decimal CalculateMonthlyPayableIncomeTaxFrom(decimal yearlyTaxableIncome)
        {
            EnsureValidValues(yearlyTaxableIncome);

            var taxBracket = _incomeTaxTable.GetTaxBracketFor(yearlyTaxableIncome);
            var marginalTax = CalculateMarginalTax(yearlyTaxableIncome, taxBracket);
            var monthlyIncomeTax = (taxBracket.AccumulatedTaxFromPreviousBracketNew + marginalTax) / MonthsInYear;

            return monthlyIncomeTax.WithRounding();
        }

        private static void EnsureValidValues(decimal yearlyTaxableIncome)
        {
            if (yearlyTaxableIncome < 0) throw new ArgumentException("Annual Salary cannot be less than zero");
        }

        private static decimal CalculateMarginalTax(decimal yearlyTaxableIncome, IncomeTaxBracket incomeTaxBracket)
        {
            var marginalTaxableAmount = CalcualteMarginalTaxableAmount(yearlyTaxableIncome, incomeTaxBracket);
            return marginalTaxableAmount * incomeTaxBracket.MarginalTaxRate;
        }

        private static decimal CalcualteMarginalTaxableAmount(decimal yearlyTaxableIncome, IncomeTaxBracket incomeTaxBracket)
        {
            return (yearlyTaxableIncome - incomeTaxBracket.IncomeThreshold);
        }

    }
}