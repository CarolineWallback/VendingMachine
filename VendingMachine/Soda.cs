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
        public Soda(string Name, int Price, string Description) : base(Name, Price, Description)
        {
            Name = "Diet Coke";
            Price = 15;
            Description = "Cold drink";
        }
        
        public override void Examine()
        {
            
        }
        public override void Use()
        {
            
        }


    }
}
