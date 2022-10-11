﻿using System;
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
        public int MoneyPool { get; set; }

        public void FillVendingMachine()
        {
            Products.Add(new Drink("Coke", 15, "Cold bubbly drink"));
            Products.Add(new Drink("Coffee", 20, "Hot cup of coffee"));
            Products.Add(new Drink("Juice", 12, "Freshly pressed oranges"));

            Products.Add(new Snacks("Chips", 27, "Cripsy and extra flavoured"));
            Products.Add(new Snacks("Chocolate", 22, "Milk chocolate with peanuts"));
            Products.Add(new Snacks("Ice cream", 19, "Ice cold strawberry ice cream"));

            Products.Add(new Food("Lasagna", 45, "Hot lasagna meal with lots of grated cheese"));
            Products.Add(new Food("Pancakes", 37, "Pancakes with bananas and strawberry jam."));
            Products.Add(new Food("Burrito", 43, "Delicious mexican chicken wrap"));

            for (int i = 0; i < Products.Count; i++)
            {
                Products[i].Id = i + 1;
            }
        }

        public void Purchase(string productName)
        {
            foreach (var item in Products)
            {
                if (string.Equals(item.Name, productName, StringComparison.OrdinalIgnoreCase))
                {
                    if (MoneyPool > item.Price)
                    {
                        ShoppingCart.Add(item);
                        MoneyPool -= item.Price;
                        Console.WriteLine($"{item.Name} was added to your shopping bag.");
                    }
                    else
                    {
                        Console.WriteLine($"This item costs {item.Price} SEK, but you only have {MoneyPool} SEK to spend");
                        Console.WriteLine("Insert more money or end transaction.");
                    }
                }
            }
        }

        public void Purchase (int id)
        {
            foreach(var item in Products)
            {
                if (item.Id == id)
                {
                    if(MoneyPool > item.Price)
                    {
                        ShoppingCart.Add(item);
                        MoneyPool -= item.Price;
                        Console.WriteLine($"{item.Name} was added to your shopping bag.");
                    }
                    else
                    {
                        Console.WriteLine($"This item costs {item.Price} SEK, but you have {MoneyPool} SEK to spend");
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

        public void ShowShoppingCart()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Your current shopping cart:");
            foreach (var item in ShoppingCart)
                Console.WriteLine(item.Name);

            Console.WriteLine();
        }

        public void InsertMoney(int money)
        {
            MoneyPool += money;
        }
        public void EndTransaction()
        {
            Console.Clear();
            Console.WriteLine("\nHere are your items:");
            foreach (var item in ShoppingCart)
                item.Use(item);

            Console.WriteLine($"\nYour change is: {MoneyPool} SEK");
            int modulus = MoneyDenominations[0];
            int temp;

            MoneyDenominations[0] = MoneyPool / MoneyDenominations[0];

            for (int i = 1; i < MoneyDenominations.Length; i++)
            {
                temp = MoneyDenominations[i];
                MoneyDenominations[i] = (MoneyPool % modulus) / MoneyDenominations[i];
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
