using System;

namespace MonthlyPayslip.Exceptions
{
    public class TaxTableEntryInvalidException : Exception
    {
        public TaxTableEntryInvalidException(string message) : base(message)
        {
        }
    }
}