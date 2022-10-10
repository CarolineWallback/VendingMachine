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

            Console.WriteLine("VENDING MACHINE");
            Console.WriteLine("Pick an option");

           while(alive)
           {
               Console.Write("1. Buy a product \n" +
                            "2. Show all products \n" +
                            "3. Insert Money \n");

                
                    Console.WriteLine("4. End transaction");


               var option = Console.ReadKey(false).Key;

               switch (option)
               {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.WriteLine("What would you like to buy?");
                        vendingMachine.Purchase(Console.ReadLine());
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        vendingMachine.ShowAll();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        vendingMachine.InsertMoney();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        vendingMachine.EndTransaction();
                        break;


               }

           }

            
        }
    }
}
