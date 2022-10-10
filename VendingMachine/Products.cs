using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Products
    {
        public string Name { get; set; }
        public int Price { get; set;}
        public string Description;

        public Products(string name, int price, string description)
        {
            Name = name;
            Price = price;
            Description = description;

        }

        public virtual void Examine()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price}, Description: {Description}");

        }

        public virtual void Use()
        {

        }
        
    }
}
