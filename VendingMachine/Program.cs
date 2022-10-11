using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static bool alive = true;
        
        static void Main(string[]args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.FillVendingMachine();
            vendingMachine.MoneyPool = 0;

            ApplicationManager applicationManager = new ApplicationManager();

            Console.WriteLine("VENDING MACHINE");

            while (alive)
            {
                applicationManager.ShowMenu(vendingMachine);
            }
        }  
    }
}
