using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class ApplicationManager
    {
        public void ShowMenu(VendingMachine vendingMachine)
        {
            if (vendingMachine.ShoppingCart.Count > 0)
                vendingMachine.ShowShoppingCart();

            Console.WriteLine($"You have {vendingMachine.MoneyPool} SEK to spend.\n");
            Console.WriteLine("Pick an option");
            Console.Write("1. Buy a product \n" +
                        "2. Show all products \n" +
                        "3. Insert Money \n");

            if (vendingMachine.MoneyPool != 0)
                Console.WriteLine("4. End transaction");

            var option = Console.ReadKey(true).Key;
            Console.WriteLine();

            switch (option)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    if (vendingMachine.MoneyPool != 0)
                    {
                        vendingMachine.ShowAll();
                        Console.WriteLine("What would you like to buy?");
                        Console.WriteLine("Type in name or id-number");
                        var input = Console.ReadLine();
                        bool parseInput = int.TryParse(input, out int id);
                        if (parseInput)
                            vendingMachine.Purchase(id);
                        else
                            vendingMachine.Purchase(input);
                    }
                    else
                        Console.WriteLine("Insert money first\n");

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
                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Wrong input\n");
                    break;
            }

        }

        

    }
}
