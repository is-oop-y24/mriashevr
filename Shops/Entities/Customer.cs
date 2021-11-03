namespace Shops.Entities
{
    public class Customer
    {
        public Customer(string name, int money)
        {
            Money = money;
            Name = name;
        }

        public int Money { get; }
        public string Name { get; }

        public Customer ChangeMoney(Customer customer1, int price)
        {
            var customer2 = new Customer(customer1.Name, customer1.Money - price);
            return customer2;
        }
    }
}