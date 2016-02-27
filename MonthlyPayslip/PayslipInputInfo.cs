namespace MonthlyPayslip
{
    public class PayslipInputInfo
    {
        public PayslipInputInfo(EmployeeDetails employeeDetails, string payPeriod, decimal salary, decimal superRate)
        {
            EmployeeDetails = employeeDetails;
            PayPeriod = payPeriod;
            Salary = salary;
            SuperRate = superRate;
        }

        public EmployeeDetails EmployeeDetails { get; private set; }
        public string PayPeriod { get; private set; }
        public decimal Salary { get; private set; }
        public decimal SuperRate { get; private set; }
    }
}