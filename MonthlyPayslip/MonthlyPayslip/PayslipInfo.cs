using MonthlyPayslip.ExtensionMethods;

namespace MonthlyPayslip
{
    public class PayslipInfo
    {
        public PayslipInfo(EmployeeDetails employeeDetails, string payPeriod, decimal superRate, decimal grossIncome, decimal incomeTax)
        {
            Employee = employeeDetails;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            SuperRate = superRate;
            PayPeriod = payPeriod;
        }

        public string PayPeriod { get; }
        public EmployeeDetails Employee { get; }
        public decimal NetIncome => GrossIncome - IncomeTax;
        public decimal GrossIncome { get; }
        public decimal IncomeTax { get; }
        public decimal SuperRate { get; }
        public decimal SuperAmount => (GrossIncome * SuperRate).WithRounding();
    }
}