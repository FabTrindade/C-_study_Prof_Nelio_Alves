using System;
using System.Collections.Generic;
using System.Globalization;


namespace TaxCalc.Entities
{
    abstract class TaxPayer
    {
        public string Name { get; set; }
        public double AnnualIncome { get; set; }

        public TaxPayer()
        {

        }
        public TaxPayer(string name, double annualIncome)
        {
            Name = name;
            AnnualIncome = annualIncome;
        }

        abstract public double Tax();

        public override string ToString()
        {
            return Name + ": " + Tax().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}
