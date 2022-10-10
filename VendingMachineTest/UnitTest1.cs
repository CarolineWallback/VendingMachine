
using System.Diagnostics.Contracts;
using VendingMachine;


namespace VendingMachineTest
{
    public class UnitTest1
    {
        public VendingMachine.VendingMachine vendingmachine = new VendingMachine.VendingMachine();
        public Product coffee = new Drink("coffee", 20, "hot drink");


        [Fact]
        public void PurchaseTestWithID()
        {
            vendingmachine.moneyPool = 100;
            vendingmachine.Products.Add(coffee);
            coffee.id = 1;
            vendingmachine.Purchase(1);
            Assert.Equal(80, vendingmachine.moneyPool);
        }

        [Fact]
        public void PurchaseTestWithName()
        {
            vendingmachine.moneyPool = 100;
            vendingmachine.Products.Add(coffee);
            vendingmachine.Purchase("coffee");
            Assert.Equal(80, vendingmachine.moneyPool);
        }

        [Fact]
        public void CheckCartTest()
        {
            vendingmachine.ShoppingCart.Add(coffee);
            Assert.True(vendingmachine.ShoppingCart != null);
        }

        [Fact]
        public void DenyPurchaseTest()
        {
            Assert.False(AddToCart());
        }
        //try adding to cart when moneypool is too low
        public bool AddToCart()
        {
            vendingmachine.moneyPool = 1;
            vendingmachine.Products.Add(coffee);
            vendingmachine.Purchase("coffee");

            if(vendingmachine.ShoppingCart.Contains(coffee))
                return true;
            else 
                return false;
        }

        [Fact]
        public void InsertMoneyTest()
        {
            vendingmachine.moneyPool = 0;
            vendingmachine.InsertMoney(100);
            Assert.Equal(100, vendingmachine.moneyPool);
        }

    }
}