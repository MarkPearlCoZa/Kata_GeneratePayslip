namespace MonthlyPayslip
{
    public class EmployeeDetails
    {
        private readonly string _lastName;
        private readonly string _firstName;

        public EmployeeDetails(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FullName => _firstName + " " + _lastName;
    }
}