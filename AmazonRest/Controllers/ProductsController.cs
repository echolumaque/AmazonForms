using System.Linq;
using System.Web.Mvc;
using AmazonRest.Models;
using System.Threading.Tasks;
using AmazonRest.Helpers;

namespace AmazonRest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AmazonProducts db = new AmazonProducts();
        //used for crud internally
        //create
        //[Compress]
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
        public JsonResult AllProducts() => Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);

        [Compress]
        [HttpPost]
        public async Task DeleteProduct(int? id)
        {
            db.Products.Remove(db.Products.Find(id));
            await db.SaveChangesAsync();
        }
    }
}
