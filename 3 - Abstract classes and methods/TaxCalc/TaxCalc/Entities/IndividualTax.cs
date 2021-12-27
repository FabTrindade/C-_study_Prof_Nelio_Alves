
using TaxCalc.Entities;

namespace TaxCalc.Entities
{
    class IndividualTax : TaxPayer
    {
        public double HealthExpenses { get; set; }

        public IndividualTax(string name, double annualIncome, double healthExpenses):  base (name,  annualIncome)
        {
            HealthExpenses = healthExpenses;
        }

        public override double Tax()
        {

            return ((AnnualIncome > 20000.00) ? AnnualIncome * 0.25 : AnnualIncome * 0.15) - HealthExpenses * 0.5;
        }
    }
}
