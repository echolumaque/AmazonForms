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
            //string[] productname = new string[] { };
            //int?[] rating = new int?[] { };
            //string[] thumbnail = new string[] { };
            //var price = new double?[] { };
            //var sf = new double?[] { };
            //var stocks = new int[] { };
            //var brand = new string[] { };
            //var description = new string[{ };
            //var series = new string[] { };
            //var model_number = new string[] { };
            //var weight = new string[] { };
            //var dimension = new string[] { };
            //var features = new string[] { };
            Console.WriteLine("ENTERING PRODUCT INSERTION");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Enter product name: ");
                string productname = Console.ReadLine();

                Console.WriteLine("Enter rating: ");
                string rating = Console.ReadLine();

                Console.WriteLine("Enter thumbnail: ");
                string thumbnail = Console.ReadLine();

                Console.WriteLine("Enter price: ");
                string price = Console.ReadLine();

                Console.WriteLine("Enter sf: ");
                string sf = Console.ReadLine();

                Console.WriteLine("Enter stocks: ");
                string stocks = Console.ReadLine();

                Console.WriteLine("Enter brand: ");
                string brand = Console.ReadLine();

                Console.WriteLine("Enter description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Enter series: ");
                string series = Console.ReadLine();

                Console.WriteLine("Enter model number: ");
                string model = Console.ReadLine();

                Console.WriteLine("Enter weight: ");
                string weight = Console.ReadLine();

                Console.WriteLine("Enter dimension: ");
                string dimension = Console.ReadLine();

                Console.WriteLine("Enter features: ");
                string features = Console.ReadLine();
                
                var product = new ProductsModel
                {
                    brand = brand,
                    description = description,
                    features = features,
                    item_dimen = dimension,
                    model_number = model,
                    price = decimal.Parse(price),
                    product_dimen = dimension,
                    prod_name = productname,
                    rating = int.Parse(rating),
                    series = series,
                    shipping_fee = decimal.Parse(sf),
                    stocks = int.Parse(stocks),
                    thumbanil = thumbnail,
                    weight = weight,
                };
                await RestService.For<IAPIEndpoints>("https://localhost:44364/").AddNewProduct(product);

                Console.WriteLine($"PRODUCT: {i + 1}");
            }
        }
    }
}
