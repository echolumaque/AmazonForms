using System.Web.Mvc;
using AmazonRest.Helpers;
using AmazonRest.Models;
using System.Linq;
using System;

namespace AmazonRest.Controllers
{
    public class UsersCartsController : BaseController
    {
        private AmazonUsersCart db = new AmazonUsersCart();

        [HttpGet]
        [Compress]
        public JsonResult GetCurrentUserCart(int? id)
        {
            var response = Json(db.QueryUsersCarts(id), JsonRequestBehavior.AllowGet);
            Add("usercart", response, DateTimeOffset.UtcNow.AddHours(24));
            return GetValue("usercart") as JsonResult;
        } 

        [HttpGet]
        [Compress]
        public JsonResult ShowProductDetails(int? productId) => Json(db.ShowProductDetails(productId).ToList().FirstOrDefault(), JsonRequestBehavior.AllowGet);
    }
}