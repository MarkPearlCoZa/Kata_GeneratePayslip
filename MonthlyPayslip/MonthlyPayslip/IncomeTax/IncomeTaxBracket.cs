namespace MonthlyPayslip.IncomeTax
{
    public class IncomeTaxBracket
    {
        public IncomeTaxBracket(
            decimal accumulatedTaxFromPreviousBracket, 
            decimal marginalTaxRate, 
            decimal incomeThreshold)
        {
            AccumulatedTaxFromPreviousBracket = accumulatedTaxFromPreviousBracket;
            MarginalTaxRate = marginalTaxRate;
            IncomeThreshold = incomeThreshold;
        }

        public decimal AccumulatedTaxFromPreviousBracket { get; }
        public decimal MarginalTaxRate { get; }
        public decimal IncomeThreshold { get; }

    }
}