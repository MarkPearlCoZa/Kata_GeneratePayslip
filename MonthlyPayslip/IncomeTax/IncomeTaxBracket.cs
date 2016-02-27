namespace MonthlyPayslip.IncomeTax
{
    public class IncomeTaxBracket
    {
        public IncomeTaxBracket(
            decimal accumulatedTaxFromPreviousBracketNew, 
            decimal marginalTaxRate, 
            decimal incomeThreshold)
        {
            AccumulatedTaxFromPreviousBracketNew = accumulatedTaxFromPreviousBracketNew;
            MarginalTaxRate = marginalTaxRate;
            IncomeThreshold = incomeThreshold;
        }

        public decimal AccumulatedTaxFromPreviousBracketNew { get; }
        public decimal MarginalTaxRate { get; }
        public decimal IncomeThreshold { get; }

    }
}