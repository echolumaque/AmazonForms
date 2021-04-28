using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class UsersController : BaseController
    {
        private readonly AmazonUsers users = new AmazonUsers();

        [HttpPost]
        [Route("users/register")]
        public async Task<string> Register([Bind(Include = "Id, Name, Password, EmailOrPhone")] User user)
        {
            var encryptedCredentials = new User
            { 
                Name = user.Name,
                Password = EncryptDecrypt.EncryptPassword(user.Password),
                EmailOrPhone = user.EmailOrPhone
            };


            if (ModelState.IsValid)
            {
                users.Users.Add(encryptedCredentials);
                await users.SaveChangesAsync();
            }
            return "registered";
        }

        [HttpPost]
        public JsonResult Login([Bind(Include = "EmailOrPhone, Password")] User user)
        {
            var userInfo =  users.AuthenticateUser(user.EmailOrPhone, EncryptDecrypt.EncryptPassword(user.Password)).FirstOrDefault();
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void EditUser(int? id, string name, string address) => users.EditCurrentUser(id, name, address);
    }
}