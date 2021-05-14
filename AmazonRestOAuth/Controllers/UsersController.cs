using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AmazonRestOAuth.Models.ADO.Net;

namespace AmazonRestOAuth.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("user")]
        public async Task<HttpResponseMessage> CurrentUserCredentials([FromUri]int id)
        {
            using (var users = new UsersEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, await users.Users.FindAsync(id));
            }

        }
    }
}