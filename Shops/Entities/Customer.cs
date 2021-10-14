namespace Shops.Entities
{
    public class Customer
    {
        public Customer(string name, int money)
        {
            Money = money;
            Name = name;
        }

        public int Money { get; set; }
        public string Name { get; }
    }
}