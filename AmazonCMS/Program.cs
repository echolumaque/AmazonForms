using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonCMS.Interfaces;
using AmazonCMS.Model;
using Refit;

namespace AmazonCMS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Read();
            await AddProducts();
            //Console.WriteLine("last id is" + await GetAllProducts());
            Console.ReadLine();
        }

        private static async Task<int> GetAllProducts()
        {
            var api = RestService.For<IAPIEndpoints>("https://localhost:44364/");
            var xd = await api.GetAllProducts();
            return xd;
        }

        private static async Task AddProducts()
        {
            var product = new ProductsModel
            {
                Id = await GetAllProducts(),
                brand = "Intel",
                description = "Power up your productivity, gaming, and content creation experiences by installing the Intel Core i9-11900K 3.5 GHz Eight-Core LGA 1200 Processor into your computer system. Built using a 14nm process, this 11th generation desktop processor features a base clock frequency of 3.5 GHz and a 5.2 GHz Turbo Boost Max 3.0 frequency with 16MB of cache, eight cores, and sixteen threads for fast and reliable performance. The Core i9-11900K also includes support for PCI Express 4.0 and dual-channel DDR4 memory at 3200 MHz to help run and multitask a variety of demanding applications and games using technologies such as built-in AI acceleration. Performance can be further enhanced with overclocking and by installing Intel Optane memory to cache frequently accessed data.",
                features = "Power up your productivity, gaming, and content creation experiences by installing the Intel Core i9-11900K 3.5 GHz Eight-Core LGA 1200 Processor into your computer system. Built using a 14nm process, this 11th generation desktop processor features a base clock frequency of 3.5 GHz and a 5.2 GHz Turbo Boost Max 3.0 frequency with 16MB of cache, eight cores, and sixteen threads for fast and reliable performance. The Core i9-11900K also includes support for PCI Express 4.0 and dual-channel DDR4 memory at 3200 MHz to help run and multitask a variety of demanding applications and games using technologies such as built-in AI acceleration. Performance can be further enhanced with overclocking and by installing Intel Optane memory to cache frequently accessed data.",
                item_dimen = "3.54 x 5.24 x 6.1 inches",
                model_number = "i9 11900K",
                price = (decimal?)42050.10,
                product_dimen = "3.54 x 5.24 x 6.1 inches",
                prod_name = "Intel Core i9-11900K Desktop Processor 8 Cores up to 5.3 GHz Unlocked LGA1200 (Intel 500 Series & Select 400 Series Chipset) 125W",
                rating = 5688,
                series = "Intel i9",
                shipping_fee = (decimal?)14463.95,
                stocks = 12,
                thumbanil = "https://images-na.ssl-images-amazon.com/images/I/71bY6Rk8e8L._AC_SL1500_.jpg",
                weight = "2.82 ounces",
            };

            await RestService.For<IAPIEndpoints>("https://localhost:44364/").AddNewProduct(product);
            Console.WriteLine("success");
        }
    }
}
