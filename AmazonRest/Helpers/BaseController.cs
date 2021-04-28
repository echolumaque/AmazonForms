using System;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace AmazonRest.Helpers
{
    public class BaseController : Controller
    {
        public object GetValue(string key) => MemoryCache.Default.Get(key);

        public bool Add(string key, object value, DateTimeOffset expiration) => MemoryCache.Default.Add(key, value, expiration);

        public void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }
    }
}