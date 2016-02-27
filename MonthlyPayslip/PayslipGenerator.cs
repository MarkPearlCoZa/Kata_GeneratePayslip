using MonthlyPayslip.ExtensionMethods;
using MonthlyPayslip.IncomeTax;

namespace MonthlyPayslip
{
    public class PayslipGenerator
    {
        private readonly IncomeTaxCalculator _incomeTaxCalculator;

        public PayslipGenerator(IncomeTaxCalculator incomeTaxCalculator = null)
        {
            _incomeTaxCalculator = new IncomeTaxCalculator() ?? incomeTaxCalculator;
        }

        public PayslipInfo CalculateUsing(PayslipInputInfo payslipInputInfo)
        {
            var yearlyTaxableIncome = payslipInputInfo.Salary;
            var monthlyTaxableIncome = CalculateMonthlyTaxableIncomeFrom(yearlyTaxableIncome).WithRounding();
            var monthlyPayableIncomeTax = _incomeTaxCalculator.CalculateMonthlyPayableIncomeTaxFrom(yearlyTaxableIncome);

            return new PayslipInfo(payslipInputInfo.EmployeeDetails,
                                   payslipInputInfo.PayPeriod,
                                   payslipInputInfo.SuperRate,
                                   monthlyTaxableIncome,
                                   monthlyPayableIncomeTax);
        }

        private decimal CalculateMonthlyTaxableIncomeFrom(decimal yearlyTaxableIncome)
        {
            const int monthsInAYear = 12;
            return (yearlyTaxableIncome / monthsInAYear);
        }
    }
}