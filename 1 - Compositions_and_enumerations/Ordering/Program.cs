using System;
using System.Globalization;

using Ordering.Entities;
using Ordering.Entities.Enuns;

namespace Ordering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name:");
            string Name = Console.ReadLine();
            Console.Write("Email:");
            string Email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY):");
            DateTime BirthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus Status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order?");
            int n = int.Parse(Console.ReadLine());

            Order Order1 = new Order(Status, new Client (Name, Email, BirthDate)); 
            
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name:");
                string ProductName = Console.ReadLine();
                Console.Write("Product price:");
                double Price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity:");
                int Quant = int.Parse(Console.ReadLine());
                Order1.AddOrderItem(new OrderItem(Quant, Price, new Product(ProductName, Price)));

            }

            Console.WriteLine(Order1);

       }
    }
}
