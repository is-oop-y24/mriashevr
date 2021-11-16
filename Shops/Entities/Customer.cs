using System.Data.SqlTypes;

namespace Shops.Entities
{
    public class Customer
    {
        private int _money;
        public Customer(string name, int money)
        {
            _money = money;
            Name = name;
        }

        public string Name { get; }

        public void Withdraw(int price)
        {
            _money -= price;
        }

        public int GetMoney()
        {
            return _money;
        }
    }
}