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
            FillVendingMachine(vendingMachine);
            vendingMachine.moneyPool = 0;

            Console.WriteLine("VENDING MACHINE");


            while (alive)
            {
                if (vendingMachine.ShoppingCart.Count > 0)
                    ShowShoppingCart(vendingMachine);

                Console.WriteLine("Pick an option");
                Console.Write("1. Buy a product \n" +
                            "2. Show all products \n" +
                            "3. Insert Money \n");

                if (vendingMachine.moneyPool != 0)
                    Console.WriteLine("4. End transaction");


                var option = Console.ReadKey(true).Key;
 
                Console.WriteLine();

                switch (option)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        if (vendingMachine.moneyPool != 0)
                        {
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
                        Console.WriteLine("Wrong input");
                        break;


                }

            }


        }

        private static void ShowShoppingCart(VendingMachine vendingMachine)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Your current shopping cart:");
            foreach(var item in vendingMachine.ShoppingCart)
                Console.WriteLine(item.Name);

            Console.WriteLine();
        }

        private static void FillVendingMachine(VendingMachine vendingMachine)
        {
            vendingMachine.Products.Add(new Drink("Coke", 15, "Cold bubbly drink"));
            vendingMachine.Products.Add(new Drink("Coffee", 20, "Hot cup of coffee"));
            vendingMachine.Products.Add(new Drink("Juice", 12, "Freshly pressed oranges"));

            vendingMachine.Products.Add(new Snacks("Chips", 27, "Cripsy and extra flavoured"));
            vendingMachine.Products.Add(new Snacks("Chocolate", 22, "Milk chocolate with peanuts"));
            vendingMachine.Products.Add(new Snacks("Ice cream", 19, "Ice cold strawberry ice cream"));

            vendingMachine.Products.Add(new Food("Lasagna", 45, "Hot lasagna meal with lots of grated cheese"));
            vendingMachine.Products.Add(new Food("Pancakes", 37, "Pancakes with bananas and strawberry jam."));
            vendingMachine.Products.Add(new Food("Burrito", 43, "Delicious mexican chicken wrap"));
       
            for(int i = 0; i < vendingMachine.Products.Count; i++)
            {
                vendingMachine.Products[i].id = i+1;
            }
        
        }
    }
}
