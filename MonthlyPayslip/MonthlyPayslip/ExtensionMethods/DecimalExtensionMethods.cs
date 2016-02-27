using System;

namespace MonthlyPayslip.ExtensionMethods
{
    public static class DecimalExtensionMethods
    {
        public static decimal WithRounding(this decimal value)
        {
            return Math.Round(value, MidpointRounding.AwayFromZero);
        }

        public static decimal EnsureWithinRange(this decimal value, decimal min, decimal max)
        {
            if (value < min) throw new ArgumentOutOfRangeException();
            if (value > max) throw new ArgumentOutOfRangeException();
            return value;
        }
    }
}