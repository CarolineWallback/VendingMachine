
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
            vendingmachine.MoneyPool = 100;
            vendingmachine.Products.Add(coffee);
            coffee.Id = 1;
            vendingmachine.Purchase(1);
            Assert.Equal(80, vendingmachine.MoneyPool);
        }

        [Fact]
        public void PurchaseTestWithName()
        {
            vendingmachine.MoneyPool = 100;
            vendingmachine.Products.Add(coffee);
            vendingmachine.Purchase("coffee");
            Assert.Equal(80, vendingmachine.MoneyPool);
        }

        [Fact]
        public void CheckCartTest()
        {
            vendingmachine.ShoppingCart.Add(coffee);
            Assert.True(vendingmachine.ShoppingCart != null);
        }

        //try adding to cart when moneypool is too low
        [Fact]
        public void DenyPurchaseTest()
        {
            Assert.False(AddToCart());
        }
        public bool AddToCart()
        {
            vendingmachine.MoneyPool = 1;
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
            vendingmachine.MoneyPool = 0;
            vendingmachine.InsertMoney(100);
            Assert.Equal(100, vendingmachine.MoneyPool);
        }
    }
}