using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using AmazonRest.Models;

namespace AmazonRest.Helpers
{
    public class BasicAuthAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                string[] decodedCredentials = decodedAuthToken.Split(':');
                string username = decodedCredentials[0];
                string password = decodedCredentials[1];

                if (Login(username, password))
                {
                    //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    //TODO: put logic that allows auth
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }


        private bool Login(string username, string password)
        {
            using (var users = new UsersEntities())
            {
                return users.Users.Any(x => x.EmailOrPhone.Equals(username) && x.Password.Equals(password));
            }
        }
    }
}