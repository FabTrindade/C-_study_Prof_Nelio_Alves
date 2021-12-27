
using TaxCalc.Entities;

namespace TaxCalc.Entities
{
    internal class CompanyTax : TaxPayer
    {
        public int EmployeesNumber { get; set; }

        public CompanyTax(string name, double annualIncome, int employeesNumber) : base(name, annualIncome)
        {
            EmployeesNumber = employeesNumber;
        }

        public override double Tax()
        {
            return (EmployeesNumber > 10)? AnnualIncome * 0.14 : AnnualIncome * 0.16;
        }
    }
}
