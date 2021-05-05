using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class UsersCartsController : ApiController
    {
        private readonly UsersCartsEntities userCart = new UsersCartsEntities();

        [HttpGet]
        [Route("userscarts/cart")]
        public HttpResponseMessage GetCurrentUserCart(int? id) => Request.CreateResponse(HttpStatusCode.OK, userCart.QueryUsersCarts(id));

        [HttpGet]
        [Route("userscarts/productdetails")]
        public HttpResponseMessage GetProductDetails(int? productId) =>  Request.CreateResponse(HttpStatusCode.OK, userCart.ShowProductDetails(productId));
    }
}