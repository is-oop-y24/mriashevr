namespace Shops.Entities
{
    public class Product
    {
        private int _id = 0;
        public Product(string name, int price)
        {
            Name = name;
            Id = _id++ + 100;
            Price = price;
            Amount = 0;
        }

        public string Name { get; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int Id { get; }
    }
}