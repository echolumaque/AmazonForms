using System;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AmazonRestOAuth.Models.ADO.Net;

namespace AmazonRestOAuth.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        [Route("add")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddProduct([FromBody] Product product)
        {
            try
            {
                using (var products = new ProductsEntities())
                {
                    products.Products.Add(product);
                    await products.SaveChangesAsync();

                    var message = Request.CreateResponse(HttpStatusCode.Created, product);
                    message.Headers.Location = new Uri(Request.RequestUri + product.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("all")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllProducts()
        {
            using (var products = new ProductsEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, await products.Products.ToListAsync());
            }
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteProduct(int id)
        {
            try
            {
                using (var product = new ProductsEntities())
                {
                    var entity = await product.Products.FindAsync(id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with {id} is not found on the database.");
                    }
                    else
                    {
                        product.Products.Remove(entity);
                        await product.SaveChangesAsync();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("details")]
        [HttpGet]
        public async Task<HttpResponseMessage> ProductDetails([FromUri]int? id)
        {
            try
            {
                if (id == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Product with {id} is not found on the database.");
                }
                else
                {
                    using (var product = new ProductsEntities())
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, await product.Products.FirstOrDefaultAsync(products => products.Id == id));
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}