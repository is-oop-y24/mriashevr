using System;
using Shops.Entities;
using Shops.Services;
using Shops.Tools;
using NUnit.Framework;

namespace Shops.Tests
{
    public class Tests
    {
        private ShopManager _shopmanager;

        [SetUp]
        public void Setup()
        {
            _shopmanager = new ShopManager();
        }

        [Test]
        public void NoSuchProductInCatalog_TrowException()
        {
            Shop shop = new Shop("pyatorochka", "kalinina");
            _shopmanager.ProductRegister("apple", 50);
            Assert.Catch<ShopException>(() =>
            {
                Product product = _shopmanager.AddProducts("banana", 5, shop);
            });
        }

        [Test]
        public void PriceChange_CheckChange()
        {
            int newPrice = 70;
            Shop shop = new Shop("pyatka", "someaddress");
            _shopmanager.ProductRegister("coke", 100);
            Product product = _shopmanager.AddProducts("coke", 10, shop);
            _shopmanager.ProductRegister("apple", 50);
            Product product2 = _shopmanager.AddProducts("apple", 10, shop);
            _shopmanager.ChangeProductPrice(shop, product, newPrice);
            Assert.AreEqual(newPrice, product.Price);
            
        }

        [Test]
        public void BuyCheapestProduct_ThrowException()
        {
            Customer customer = new Customer("Biba", 500);
            Shop shop1 = new Shop("pyatka", "someaddress");
            _shopmanager.ProductRegister("coke", 100);
            _shopmanager.ProductRegister("apple", 50);
            Product product11 = _shopmanager.AddProducts("coke", 3, shop1);
            Product product12 = _shopmanager.AddProducts("apple", 10, shop1);
            _shopmanager.ChangeProductPrice(shop1, product11, 80);
            Shop shop2 = new Shop("pyatka", "someaddress");
            Product product21 = _shopmanager.AddProducts("coke", 10, shop2);
            Product product22 = _shopmanager.AddProducts("apple", 5, shop2);
            _shopmanager.ChangeProductPrice(shop2, product22, 40);
            Assert.Catch<ShopException>(() =>
            {
                _shopmanager.Delivery(customer, "coke", 6);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Customer customer = new Customer("Biba", 500);
            Shop shop1 = new Shop("pyatka", "someaddress");
            _shopmanager.ProductRegister("coke", 100);
            _shopmanager.ProductRegister("apple", 50);
            Product product11 = _shopmanager.AddProducts("coke", 3, shop1);
            Product product12 = _shopmanager.AddProducts("apple", 10, shop1);
            _shopmanager.BuyProduct(customer, shop1, "coke", 3);
            Assert.AreEqual(0,product11.Amount);
        }
    }
}