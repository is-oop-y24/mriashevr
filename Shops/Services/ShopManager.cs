using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Shops.Entities;
using Shops.Services;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager
    {
        private List<Shop> _allShops = new List<Shop>();
        private List<Product> _productCatalog = new List<Product>();
        public Product AddProducts(string name, int amount, Shop shopid)
        {
            foreach (Product product in shopid.Products)
            {
                if (name == product.Name)
                {
                    product.Amount = amount;
                    return product;
                }
            }

            foreach (Product product in _productCatalog)
            {
                if (name == product.Name)
                {
                    shopid.Products.Add(product);
                    foreach (Product internalproduct in shopid.Products)
                    {
                        if (name == internalproduct.Name)
                        {
                            internalproduct.Amount = amount;
                            return internalproduct;
                        }
                    }
                }
            }

            throw new ShopException("invalid product!!");
        }

        public Shop AddShop(string name, string address)
        {
            var shp = new Shop(name, address);
            _allShops.Add(shp);
            return shp;
        }

        public Product ProductRegister(string name, int price)
        {
            var prdct = new Product(name, price);
            _productCatalog.Add(prdct);
            return prdct;
        }

        public void ChangeProductPrice(Shop shopid, Product product, int newprice)
        {
            foreach (Product prdct in shopid.Products)
            {
                if (prdct == product)
                {
                    prdct.Price = newprice;
                }
            }
        }

        public Shop FindMinPrice(string name, int amount)
        {
            int minPrice = 1000000;
            Shop selectedShop = new Shop("Empty", "Empty");
            foreach (Shop shop in _allShops)
            {
                foreach (Product prdct in shop.Products)
                {
                    if (prdct.Price < minPrice && prdct.Name == name && prdct.Amount >= amount)
                    {
                        minPrice = prdct.Price;
                        selectedShop = shop;
                    }
                }
            }

            if (selectedShop.Name == "Empty")
            {
                throw new ShopException("no shop found");
            }

            if (minPrice == 1000000)
            {
                throw new ShopException("no min price");
            }

            return selectedShop;
        }

        public Product BuyProduct(Customer customer, Shop shop, string name, int amount)
        {
            foreach (Product product in shop.Products)
            {
                if (name == product.Name && product.Amount >= amount && customer.Money >= (product.Price * amount))
                {
                    product.Amount = product.Amount - amount;
                    customer.Money = customer.Money - (product.Price * amount);
                    return product;
                }

                throw new ShopException("error occurred while buying");
            }

            return null;
        }

        public Shop Delivery(Customer customer, string name, int amount)
        {
            Shop selectedShop = FindMinPrice(name, amount);

            foreach (Shop shop in _allShops)
            {
                if (shop.Id == selectedShop.Id)
                {
                    foreach (Product product in shop.Products)
                    {
                        if (product.Name == name && customer.Money >= (product.Price * amount))
                        {
                            customer.Money = customer.Money - (product.Price * amount);
                            product.Amount = product.Amount - amount;
                            return shop;
                        }
                    }
                }
            }

            throw new ShopException("something got wrong, man");
        }
    }
}