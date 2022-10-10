using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        public int MoneyPool { get; set; }
        private readonly int[] MoneyDenominations = { 1000, 500, 100, 50, 20, 10, 5, 1 };
        public Products Purchase(string productName)
        {
            if(productName)

            return 
        }

        public void ShowAll()
        {

        }

        public void InsertMoney()
        {
            Console.WriteLine("How much money do you wish to insert?");
            var success02 = int.TryParse(Console.ReadLine(), out int money);
            MoneyPool = money;

        }
        public void EndTransaction()
        {


        }
    }
}
