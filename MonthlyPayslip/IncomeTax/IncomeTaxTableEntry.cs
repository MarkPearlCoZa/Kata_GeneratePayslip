using MonthlyPayslip.Exceptions;

namespace MonthlyPayslip.IncomeTax
{
    public class IncomeTaxTableEntry
    {
        private readonly decimal _minThreshold;
        private readonly decimal _maxThreshold;

        public static IncomeTaxTableEntry CreateWith(decimal minThreshold,
                                                     decimal maxThreshold,
                                                     decimal accumulatedTaxFromPreviousBracket,
                                                     decimal marginalTaxRate)
        {
            EnsureValidValues(minThreshold, maxThreshold);

            var incomeThreshold = CalculateIncomeThreshold(minThreshold);
            var taxBracket = new IncomeTaxBracket(accumulatedTaxFromPreviousBracket, marginalTaxRate, incomeThreshold);
            var taxTableEntry = new IncomeTaxTableEntry(minThreshold, maxThreshold, taxBracket);

            return taxTableEntry;
        }


        private IncomeTaxTableEntry(decimal minThreshold, decimal maxThreshold, IncomeTaxBracket incomeTaxBracket)
        {
            _minThreshold = minThreshold;
            _maxThreshold = maxThreshold;
            IncomeTaxBracket = incomeTaxBracket;
        }

        private static void EnsureValidValues(decimal min, decimal max)
        {
            if (min < 0) throw new TaxTableEntryInvalidException("Min value cannot be less than zero");
            if (min >= max) throw new TaxTableEntryInvalidException("Min value cannot be greater than or equal to max value");
        }

        public IncomeTaxBracket IncomeTaxBracket { get; }

        public bool MeetsCriteriaForValidTaxTableEntryFor(decimal yearlyTaxableIncome)
        {
            if (yearlyTaxableIncome < _minThreshold) return false;
            if (yearlyTaxableIncome > _maxThreshold) return false;
            return true;
        }
        private static decimal CalculateIncomeThreshold(decimal minThreshold)
        {
            return (minThreshold - 1 > 0) ? minThreshold - 1 : 0;
        }
    }
}