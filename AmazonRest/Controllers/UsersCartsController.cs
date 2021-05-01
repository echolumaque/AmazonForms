using System.Data.Entity.Core.Objects;
using System.Web.Http;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class UsersCartsController : ApiController
    {
        [HttpGet]
        [Route("userscarts/cart")]
        public ObjectResult<QueryUsersCarts_Result> GetCurrentUserCart(int? id)
        {
            using (var userCart = new UsersCartsEntities())
            {
                return userCart.QueryUsersCarts(id);
            }
        }

        [HttpGet]
        [Route("userscarts/productdetails")]
        public ObjectResult<ShowProductDetails_Result> GetProductDetails(int? productId)
        {
            using (var userCart = new UsersCartsEntities())
            {
                return userCart.ShowProductDetails(productId);
            }
        }
    }
}
