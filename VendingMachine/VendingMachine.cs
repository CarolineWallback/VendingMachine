using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        private readonly int[] MoneyDenominations = { 1000, 500, 100, 50, 20, 10, 5, 1 };
        public List<Product> Products = new();
        public List<Product> ShoppingCart = new();
        public int moneyPool { get; set; }


        public void Purchase(string productName)
        {
            foreach (var item in Products)
            {
                if (string.Equals(item.Name, productName, StringComparison.OrdinalIgnoreCase))
                {
                    if (moneyPool > item.Price)
                    {
                        ShoppingCart.Add(item);
                        moneyPool -= item.Price;
                        Console.WriteLine($"{item.Name} was added to your shopping bag.");

                    }
                    else
                    {
                        Console.WriteLine($"This item costs {item.Price} SEK, but you only have {moneyPool} SEK to spend");
                        Console.WriteLine("Insert more money or end transaction.");

                    }
                }
            }
        }

        public void Purchase (int id)
        {
            foreach(var item in Products)
            {
                if (item.id == id)
                {
                    if(moneyPool > item.Price)
                    {
                        ShoppingCart.Add(item);
                        moneyPool -= item.Price;
                        Console.WriteLine($"{item.Name} was added to your shopping bag.");

                    }
                    else
                    {
                        Console.WriteLine($"This item costs {item.Price} SEK, but you only have {moneyPool} SEK to spend");
                        Console.WriteLine("Insert more money or end transaction.");

                    }
                }
            }
        }

        public void ShowAll()
        {
            Console.Clear();

            Console.WriteLine("Available products: \n");
            for (int i = 0; i < Products.Count; i++)
            {
                Products[i].Examine(Products[i]);
            }

            Console.WriteLine();
        }

        public void InsertMoney(int money)
        {
            moneyPool += money;
        }
        public void EndTransaction()
        {
            Console.Clear();
            Console.WriteLine("\nHere are your items:");
            foreach (var item in ShoppingCart)
                item.Use(item);

            Console.WriteLine($"\nYour change is: {moneyPool} SEK");
            int modulus = MoneyDenominations[0];
            int temp;

            MoneyDenominations[0] = moneyPool / MoneyDenominations[0];

            for (int i = 1; i < MoneyDenominations.Length; i++)
            {
                temp = MoneyDenominations[i];
                MoneyDenominations[i] = (moneyPool % modulus) / MoneyDenominations[i];
                modulus = temp;

            }
            Console.WriteLine("You will get: ");
            Console.WriteLine($"Thousend bill: {MoneyDenominations[0]}");
            Console.WriteLine($"Fivehundred bill: {MoneyDenominations[1]}");
            Console.WriteLine($"Hundred bill: {MoneyDenominations[2]}");
            Console.WriteLine($"Fifty bill: {MoneyDenominations[3]}");
            Console.WriteLine($"Twenty bill: {MoneyDenominations[4]}");
            Console.WriteLine($"Ten coin: {MoneyDenominations[5]}");
            Console.WriteLine($"Five coin: {MoneyDenominations[6]}");
            Console.WriteLine($"One coin: {MoneyDenominations[7]}");

        }
    }
}
