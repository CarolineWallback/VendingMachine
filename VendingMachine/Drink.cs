using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Drink : Product
    {
        public Drink(string name, int price, string description) : base(name, price, description){}
       
        public override void Examine(Product product)
        {
            Console.WriteLine($"{Id} - {product.Name}, {product.Price} SEK, {product.Description}");
        }
        public override void Use(Product product)
        {
            Console.WriteLine($"{product.Name} - Drink and enjoy!");
        }
    }
}
