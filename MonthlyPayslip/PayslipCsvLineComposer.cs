using System.Globalization;

namespace MonthlyPayslip
{
    public class PayslipCsvLineComposer
    {
        public string Compose(PayslipInfo payslipInfo, char csvSeparator = ',')
        {
            var result = new[]
            {
                payslipInfo.Employee.FullName,
                payslipInfo.PayPeriod,
                payslipInfo.GrossIncome.ToString(CultureInfo.InvariantCulture),
                payslipInfo.IncomeTax.ToString(CultureInfo.InvariantCulture),
                payslipInfo.NetIncome.ToString(CultureInfo.InvariantCulture),
                payslipInfo.SuperAmount.ToString(CultureInfo.InvariantCulture)
            };

            return string.Join(csvSeparator.ToString(), result);
        } 
    }
}