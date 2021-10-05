using System.Collections.Generic;

namespace Shops.Entities
{
    public class Shop
    {
        private int _id = 0;

        public Shop(string name, string adress)
        {
            Id = ++_id + 100000;
            Name = name;
            Adress = adress;
            Products = new List<Product>();
        }

        public List<Product> Products { get; } = new List<Product>();
        public int Id { get; }
        public string Name { get; }
        public string Adress { get; }
    }
}