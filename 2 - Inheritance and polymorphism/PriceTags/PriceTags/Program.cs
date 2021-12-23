using PriceTags.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace PriceTags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products:");
            int n = int.Parse(Console.ReadLine());

            List<Product> product = new List<Product>();
            
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char c = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


                switch (c)
                {
                    case 'i':
                        Console.Write("Customs fee: ");
                        double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        product.Add(new ImportedProduct(name, price, customFee));
                        break;

                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                        product.Add(new UsedProduct(name, price, manufactureDate));
                        break;


                    case 'c':
                        product.Add(new Product(name, price));
                        break;

                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach (Product p in product)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}
