using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsEntities db = new ProductsEntities();

        [HttpPost]
        [Route("products/add")]
        public async Task<HttpResponseMessage> AddProduct([System.Web.Mvc.Bind(Include = "prod_name,rating,thumbanil,price,shipping_fee,stocks,brand,description,features,series,model_number,weight,product_dimen,item_dimen,Id")] Product product)
        {
            try
            {
                using (var products = new ProductsEntities())
                {
                    products.Products.Add(product);
                    await products.SaveChangesAsync();

                    var message = Request.CreateResponse(HttpStatusCode.Created, products);
                    message.Headers.Location = new Uri(Request.RequestUri + product.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("products/all")]
        public async Task<List<Product>> ReturnAllProducts()
        {
            using (var products = new ProductsEntities())
            {
                return await products.Products.ToListAsync();
            }
        }

        [HttpDelete]
        [Route("products/delete")]
        public async Task DeleteProduct(int productId)
        {
            using (var products = new ProductsEntities())
            {
                products.Products.Remove(await products.Products.FindAsync(productId));
                await products.SaveChangesAsync();
            }
        }
    }
}