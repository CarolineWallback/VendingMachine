using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Food : Product
    {
        public Food(string name, int price, string description) : base(name, price, description){}

        public override void Examine(Product product)
        {
            Console.WriteLine($"{Id} - {product.Name}, {product.Price} SEK, {product.Description}");
        }
        public override void Use(Product product)
        {
            Console.WriteLine($"{product.Name} - Enjoy your meal!");
        }
    }
}
