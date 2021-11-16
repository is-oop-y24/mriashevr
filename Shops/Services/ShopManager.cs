using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Shops.Entities;
using Shops.Tools;

namespace Shops.Services
{
    public class ShopManager
    {
        private List<Shop> _allShops = new List<Shop>();
        private List<Product> _productCatalog = new List<Product>();

        public Product AddProducts(string name, int amount, Shop shop)
        {
            foreach (Product product in shop.Products)
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
                    shop.Products.Add(product);
                    foreach (Product internalproduct in shop.Products)
                    {
                        if (name != internalproduct.Name) continue;
                        internalproduct.Amount = amount;
                        return internalproduct;
                    }
                }
            }

            throw new ShopException("invalid product!!");
        }

        public Shop AddShop(string name, string address)
        {
            var shop = new Shop(name, address);
            _allShops.Add(shop);
            return shop;
        }

        public Product ProductRegister(string name, int price)
        {
            var product = new Product(name, price);
            _productCatalog.Add(product);
            return product;
        }

        public void ChangeProductPrice(Shop shopid, Product product, int newprice)
        {
            foreach (var productShop in shopid.Products.Where(productShop => productShop == product))
            {
                productShop.Price = newprice;
            }
        }

        public Shop FindMinPrice(List<Product> orderedproducts)
        {
            int minPrice = 1000000;
            int currentShopPrice = 0;
            Shop selectedShop = new Shop(null, null);

            foreach (Shop shop in _allShops)
            {
                var selectedShopProducts = new List<Product>();
                foreach (Product product in shop.Products)
                {
                    foreach (Product product1 in orderedproducts)
                    {
                        if (product.Name == product1.Name && product.Amount >= product1.Amount)
                        {
                            selectedShopProducts.Add(product1);
                            currentShopPrice += product.Price * product1.Amount;
                        }
                    }
                }

                if (currentShopPrice < minPrice && currentShopPrice != 0 && orderedproducts.Count == selectedShopProducts.Count)
                {
                    minPrice = currentShopPrice;
                    selectedShop = shop;
                }
            }

            if (selectedShop.Name == null)
            {
                throw new ShopException("no shop found");
            }

            if (minPrice == 1000000)
            {
                throw new ShopException("no min price");
            }

            return selectedShop;
        }

        public void BuyProduct(Customer customer, Shop shop, List<Product> products)
        {
            foreach (Product product in shop.Products)
            {
                foreach (var listedproduct in products)
                {
                    if (product == listedproduct)
                    {
                        if (product.Amount >= listedproduct.Amount &&
                            customer.GetMoney() >= (product.Price * listedproduct.Amount))
                        {
                            product.Amount = product.Amount - listedproduct.Amount;
                            customer.Withdraw(product.Price * listedproduct.Amount);
                        }
                    }
                }
            }

            throw new ShopException("error occurred while buying");
        }

        public Shop Delivery(Customer customer, List<Product> orderedproducts)
        {
                Shop selectedShop = FindMinPrice(orderedproducts);
                foreach (Product product1 in orderedproducts)
                {
                    foreach (var product in selectedShop.Products)
                    {
                       if (product.Name == product1.Name && customer.GetMoney() >= (product.Price * product1.Amount))
                       {
                            customer.Withdraw(product.Price * product1.Amount);
                            product.Amount = product.Amount - product1.Amount;
                            return selectedShop;
                       }
                    }
                }

                throw new ShopException("something got wrong, man");
        }
    }
}