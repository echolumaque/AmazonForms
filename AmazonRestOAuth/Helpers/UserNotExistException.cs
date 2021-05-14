using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazonRestOAuth.Helpers
{
    [Serializable]
    public class UserNotExistException : Exception
    {
        public UserNotExistException(string message) : base(message)
        {

        }
    }
}