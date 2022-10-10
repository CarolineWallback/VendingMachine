using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Soda : Products
    {
        public Soda()
        {
            Name = "Diet Coke";
            Price = 15;
            Description = "Cold drink";
        }
        
        
        public override void Examine()
        {
            Console.WriteLine();
            
        }
        public override void Use()
        {
            
        }


    }
}
