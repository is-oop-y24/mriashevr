using System.Collections.Generic;
using Shops.Entities;
using Shops.Services;
using Shops.Tools;
using NUnit.Framework;

namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void NoSuchProductInCatalog_TrowException()
        {
            Shop shop = new Shop("pyatorochka", "kalinina");
            _shopManager.ProductRegister("apple", 50);
            Assert.Catch<ShopException>(() =>
            {
                Product product = _shopManager.AddProducts("banana", 5, shop);
            });
        }

        [Test]
        public void PriceChange_CheckChange()
        {
            int newPrice = 70;
            Shop shop = new Shop("pyatka", "someaddress");
            _shopManager.ProductRegister("coke", 100);
            Product product = _shopManager.AddProducts("coke", 10, shop);
            _shopManager.ProductRegister("apple", 50);
            Product product2 = _shopManager.AddProducts("apple", 10, shop);
            _shopManager.ChangeProductPrice(shop, product, newPrice);
            Assert.AreEqual(newPrice, product.Price);

        }

        [Test]
        public void BuyCheapestProduct_ThrowException()
        {
            Customer customer = new Customer("Biba", 500);
            Shop shop1 = new Shop("pyatka", "someaddress");
            Shop onlineshop = new Shop("online", "noadress");
            _shopManager.ProductRegister("coke", 100);
            _shopManager.ProductRegister("apple", 50);
            Product product11 = _shopManager.AddProducts("coke", 3, shop1);
            Product product12 = _shopManager.AddProducts("apple", 10, shop1);
            _shopManager.ChangeProductPrice(shop1, product11, 80);
            Shop shop2 = new Shop("pyatka", "someaddress");
            Product product21 = _shopManager.AddProducts("coke", 10, shop2);
            Product product22 = _shopManager.AddProducts("apple", 5, shop2);
            _shopManager.ChangeProductPrice(shop2, product22, 40);
            Product orderproduct = _shopManager.AddProducts("coke", 6, onlineshop);
            var orderedproducts= new List<Product>();
            orderedproducts.Add(orderproduct);
            Assert.Catch<ShopException>(() =>
            {
                _shopManager.Delivery(customer, orderedproducts);
            });
        }

        [Test]
        public void CheckProductAmount_CustomerBoughtEverything()
        {
            Customer customer = new Customer("Biba", 500);
            Shop shop1 = new Shop("pyatka", "someaddress");
            _shopManager.ProductRegister("coke", 100);
            _shopManager.ProductRegister("apple", 50);
            Product product11 = _shopManager.AddProducts("coke", 3, shop1);
            Product product12 = _shopManager.AddProducts("apple", 10, shop1);
            Product orderproduct = _shopManager.AddProducts("coke", 2, shop1);
            var orderedproducts= new List<Product>();
            orderedproducts.Add(orderproduct);
            Assert.Catch<ShopException>(() =>
            {
                _shopManager.BuyProduct(customer, shop1, orderedproducts);
            });
            Assert.AreEqual(0,product11.Amount);
        }
    }
}