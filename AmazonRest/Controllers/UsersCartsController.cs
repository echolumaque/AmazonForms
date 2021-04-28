using System.Web.Mvc;
using AmazonRest.Helpers;
using AmazonRest.Models;
using System.Linq;

namespace AmazonRest.Controllers
{
    public class UsersCartsController : Controller
    {
        private AmazonUsersCart db = new AmazonUsersCart();

        [HttpGet]
        [Compress]
        public JsonResult GetCurrentUserCart(int? id) => Json(db.QueryUsersCarts(id), JsonRequestBehavior.AllowGet);

        [HttpGet]
        [Compress]
        public JsonResult ShowProductDetails(int? productId) => Json(db.ShowProductDetails(productId).ToList().FirstOrDefault(), JsonRequestBehavior.AllowGet);
    }
}