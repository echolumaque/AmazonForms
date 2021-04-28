using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class ProductsController : BaseController
    {
        //used for crud internally

        private readonly AmazonProducts db = new AmazonProducts();
        //create
        [Compress]
        [HttpPost]
        public async Task AddProduct([Bind(Include = "prod_name,rating,thumbanil,price,shipping_fee,stocks,brand,description,features,series,model_number,weight,product_dimen,item_dimen,Id")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
            }
        }

        //read
        [Compress]
        [HttpGet]
        public JsonResult AllProducts()
        {
            var response = Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
            Add("products", response, DateTimeOffset.UtcNow.AddHours(24));
            return GetValue("products") as JsonResult;
        } 

        [Compress]
        [HttpPost]
        public async Task DeleteProduct(int? id)
        {
            db.Products.Remove(db.Products.Find(id));
            await db.SaveChangesAsync();
        }
    }
}
