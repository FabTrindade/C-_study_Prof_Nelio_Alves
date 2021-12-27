using System;
using System;
using System.Collections.Generic;
using System.Globalization;

using TaxCalc.Entities;

namespace TaxCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int n  = int.Parse(Console.ReadLine());

            List<TaxPayer> payers = new List<TaxPayer>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                Char typePayer = char.Parse(Console.ReadLine());
                Console.Write("Name:");
                string name = Console.ReadLine();
                Console.Write("Anual income:");
                double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                if (typePayer == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double helthExpenses = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    payers.Add(new IndividualTax(name, annualIncome, helthExpenses));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int nEmployees = int.Parse(Console.ReadLine());

                    payers.Add(new CompanyTax(name, annualIncome, nEmployees));
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            double sum = 0;
            foreach (TaxPayer p in payers)
            {
                Console.WriteLine(p);

                sum += p.Tax();
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
