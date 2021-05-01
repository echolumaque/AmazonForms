using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AmazonRest.Helpers;
using AmazonRest.Models;

namespace AmazonRest.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("users/register")]
        public async Task<HttpResponseMessage> Register([System.Web.Mvc.Bind(Include = "Id, Name, Password, EmailOrPhone")] User user)
        {
            try
            {
                using (var users = new UsersEntities())
                {
                    var encryptedUser = new User
                    {
                        EmailOrPhone = user.EmailOrPhone,
                        Name = user.Name,
                        Password = Encrypt.EncryptPassword(user.Password)
                    };

                    users.Users.Add(encryptedUser);
                    await users.SaveChangesAsync();

                    var message = Request.CreateResponse(HttpStatusCode.Created, encryptedUser);
                    message.Headers.Location = new Uri(Request.RequestUri + user.Id.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("users/login")]
        public AuthenticateUser_Result Login([System.Web.Mvc.Bind(Include = "EmailOrPhone, Password")] User user)
        {
            try
            {
                using (var users = new UsersEntities())
                {
                    return users.AuthenticateUser(user.EmailOrPhone, Encrypt.EncryptPassword(user.Password)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw new UserNotExistException($"User {user.EmailOrPhone} cannot be found on the database.");
            }
        }

        [HttpPut]
        [Route("users/edit")]
        public void Edit(int? id, string name, string address)
        {
            using (var users = new UsersEntities())
            {
                users.EditCurrentUser(id, name, address);
            }
        }
    }
}