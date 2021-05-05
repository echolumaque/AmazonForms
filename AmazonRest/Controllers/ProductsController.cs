using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductsEntities db = new ProductsEntities();

        [HttpPost]
        [Route("products/add")]
        public async Task<HttpResponseMessage> AddProduct([FromBody]Product product)
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
        public async Task<HttpResponseMessage> ReturnAllProducts()
        {
            using (var products = new ProductsEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, await products.Products.ToListAsync());
            }
        }

        [HttpDelete]
        [Route("products/delete")]
        public async Task<HttpResponseMessage> DeleteProduct(int productId)
        {
            try
            {
                using (var products = new ProductsEntities())
                {
                    var entity = await products.Products.FindAsync(productId);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with id {productId} is not found on the database.");
                    }
                    else
                    {
                        products.Products.Remove(entity);
                        await products.SaveChangesAsync();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}