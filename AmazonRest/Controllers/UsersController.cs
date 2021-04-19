using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class UsersController : Controller
    {
        private readonly AmazonUsersEntities users = new AmazonUsersEntities();

        [HttpPost]
        [Compress]
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

        

        public bool Login([Bind(Include = "EmailOrPhone, Password")] User user)
        {
            var userId = users.AuthenticateUser(user.EmailOrPhone, EncryptDecrypt.EncryptPassword(user.Password)).FirstOrDefault();

            switch (userId.Value)
            {
                case -1://incorrect
                    return false;
                default://correct
                    return true;
            }
        }
    }
}