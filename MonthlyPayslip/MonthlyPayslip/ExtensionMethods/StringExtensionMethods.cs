using System;
using System.Text.RegularExpressions;

namespace MonthlyPayslip.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static decimal ParseAsPercentage(this string input)
        {
            const string pattern = @"^(\d*.+\d*)%$";
            var result = Regex.Match(input, pattern);
            return Convert.ToDecimal(result.Groups[1].Value) * 0.01m;
        }

        public static decimal ParseAsDecimal(this string input)
        {
            return Convert.ToDecimal(input);
        }
    }
}
