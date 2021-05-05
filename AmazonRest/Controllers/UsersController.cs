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
        public async Task<HttpResponseMessage> Register([FromBody] User user)
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
        public AuthenticateUser_Result Login([FromBody] User user)
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
        public async Task<HttpResponseMessage> Edit([FromBody] int? id, string name, string address)
        {
            try
            {
                using (var users = new UsersEntities())
                {
                    if (users.Users.FindAsync(id) == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User {name} does not exist on the database.");
                    }
                    else
                    {
                        users.EditCurrentUser(id, name, address);
                        await users.SaveChangesAsync();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}