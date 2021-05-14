using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmazonRestOAuth.Helpers;
using AmazonRestOAuth.Models.ADO.Net;

namespace AmazonRestOAuth.Controllers
{
    [RoutePrefix("userscarts")]
    public class UsersCartsController : ApiController
    {
        [HttpGet]
        [Route("cart")]
        public HttpResponseMessage CurrentUserCart([FromUri]string emailOrPhone)
        {
            try
            {
              
                if (emailOrPhone == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new UserNotExistException($"User {emailOrPhone} is not found on the database"));
                }
                else
                {
                    var cart = new UsersCartsEntities();
                    return Request.CreateResponse(HttpStatusCode.OK, cart.QueryUserCart(emailOrPhone));
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}