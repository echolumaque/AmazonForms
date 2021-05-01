using System.Data.Entity.Core.Objects;
using System.Web.Http;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class UsersCartsController : ApiController
    {
        private readonly UsersCartsEntities userCart = new UsersCartsEntities();

        [HttpGet]
        [Compress]
        [Route("userscarts/cart")]
        public ObjectResult<QueryUsersCarts_Result> GetCurrentUserCart(int? id) => userCart.QueryUsersCarts(id);

        [HttpGet]
        [Compress]
        [Route("userscarts/productdetails")]
        public ObjectResult<ShowProductDetails_Result> GetProductDetails(int? productId) =>  userCart.ShowProductDetails(productId);
    }
}
