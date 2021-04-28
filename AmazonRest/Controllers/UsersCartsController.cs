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
            return Json(db.QueryUsersCarts(id), JsonRequestBehavior.AllowGet);

            //if (GetValue("usercart") == null)
            //{
            //    Add("usercart", response, DateTimeOffset.UtcNow.AddHours(24));
            //    return GetValue("usercart") as JsonResult;
            //}
            //else
            //    return GetValue("usercart") as JsonResult;
        }

        [HttpGet]
        [Compress]
        public JsonResult ShowProductDetails(int? productId)
        {
            return Json(db.ShowProductDetails(productId).ToList().FirstOrDefault(), JsonRequestBehavior.AllowGet);

            //if (GetValue("productdetail") == null)
            //{
            //    Add("productdetail", response, DateTimeOffset.UtcNow.AddHours(24));
            //    return GetValue("productdetail") as JsonResult;
            //}
            //else
            //    return GetValue("productdetail") as JsonResult;
        } 
    }
}