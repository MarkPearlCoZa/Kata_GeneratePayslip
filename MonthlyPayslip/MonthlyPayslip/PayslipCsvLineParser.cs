using MonthlyPayslip.ExtensionMethods;

namespace MonthlyPayslip
{
    public class PayslipCsvLineParser
    {
        public PayslipInputInfo Parse(string csvLine, char csvSeparator = ',')
        {
            var csvValues = csvLine.Split(csvSeparator);

            var employeeFirstName = csvValues[0];
            var employeeLastName = csvValues[1];
            var employeeDetails = new EmployeeDetails(employeeFirstName, employeeLastName);

            var salary = csvValues[2].ParseAsDecimal().EnsureWithinRange(0, decimal.MaxValue);
            var superRate = csvValues[3].ParseAsPercentage().EnsureWithinRange(0, 0.5m);
            var payPeriod = csvValues[4];

            return new PayslipInputInfo(employeeDetails, payPeriod, salary, superRate);
        }
    }
}