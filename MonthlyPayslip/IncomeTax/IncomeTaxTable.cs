using System;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyPayslip.IncomeTax
{
    public class IncomeTaxTable
    {
        private readonly IEnumerable<IncomeTaxTableEntry> _taxTable;

        public IncomeTaxTable()
        {
            _taxTable = new List<IncomeTaxTableEntry>()
           {
                IncomeTaxTableEntry.CreateWith(0, 18200, 0, 0M),
                IncomeTaxTableEntry.CreateWith(18201, 37000, 0, 0.19m),
                IncomeTaxTableEntry.CreateWith(37001, 80000, 3572, 0.325m),
                IncomeTaxTableEntry.CreateWith(80001, 180000, 17547, 0.37m),
                IncomeTaxTableEntry.CreateWith(180001, decimal.MaxValue,54547, 0.45m),
           };
        }

        public IncomeTaxBracket GetTaxBracketFor(decimal yearlyTaxableIncome)
        {
            EnsureValidValues(yearlyTaxableIncome);
            return _taxTable.Single(taxTableEntry => taxTableEntry.MeetsCriteriaForValidTaxTableEntryFor(yearlyTaxableIncome)).IncomeTaxBracket;
        }

        private static void EnsureValidValues(decimal yearlyTaxableIncome)
        {
            if (yearlyTaxableIncome < 0) throw new ArgumentException("Yearly taxable income cannot be less than zero");
        }
    }
}