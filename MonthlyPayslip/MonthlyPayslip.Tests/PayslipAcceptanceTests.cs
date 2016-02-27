using NUnit.Framework;

namespace MonthlyPayslip.Tests
{
    [TestFixture]
    public class PayslipAcceptanceTests
    {
        [TestCase("David,Rudd,60050,9%,01 March – 31 March", "David Rudd,01 March – 31 March,5004,922,4082,450")]
        [TestCase("Ryan,Chen,120000,10%,01 March – 31 March", "Ryan Chen,01 March – 31 March,10000,2696,7304,1000")]
        public void GivenBaseSalary_GenerateCorrectPayslip(string inputCsvLine, string expectedCsv)
        {
            var payslipCalculator = new PayslipGenerator();
            var payslipCsvLineParser = new PayslipCsvLineParser();
            var payslipCsvLineComposer = new PayslipCsvLineComposer();

            var payslipInfo = payslipCsvLineParser.Parse(inputCsvLine);
            var payslipDetails = payslipCalculator.CalculateUsing(payslipInfo);
            var payslipAsCsv = payslipCsvLineComposer.Compose(payslipDetails);

            Assert.That(payslipAsCsv, Is.EqualTo(expectedCsv));
        }
    }
}
