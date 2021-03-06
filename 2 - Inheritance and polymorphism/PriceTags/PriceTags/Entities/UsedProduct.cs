using System;
using System.Globalization;

namespace PriceTags.Entities
{
    internal class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct(string name, double price, DateTime manufactureDate): base(name, price)
        {
            ManufactureDate = manufactureDate;
        }

        public sealed override string PriceTag()
        {
            return  Name + 
                    "(used)  $" + 
                    Price +
                    $"(Manufacture date: {ManufactureDate.ToString("dd/MM/yyyy")})";
        }
    }
}
