using System;
using System.Globalization;

using Installments.Services;
using Installments.Entities;

namespace Installments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractdate = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int numbInstallments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(contractNumber, contractdate, contractValue);

            ContractServices contractService = new ContractServices (new PaypalService());

            contractService.ProcessContract(contract, numbInstallments);

            Console.WriteLine();
            Console.WriteLine("Installments:");

            foreach (Installment i in contract.Installments)
            {
                Console.WriteLine(i);
            }




        }
    }
}
