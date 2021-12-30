using System;
using System.Globalization;
using AccountException.Entities.Exceptions;
using AccountException.Entities;


namespace AccountException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter account data:");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial Balance: $");
            double initBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw limit: $");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter amount for withdraw: $");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, initBalance, withdrawLimit);

            try
            {
                account.Withdraw(amount);
                Console.WriteLine();
                Console.WriteLine("New balance: $" + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
