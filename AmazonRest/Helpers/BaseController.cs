using System;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace AmazonRest.Helpers
{
    public class BaseController : Controller
    {
        public object GetValue(string key)
        {
            var memCache = MemoryCache.Default;
            return memCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset expiration)
        {
            var memCache = MemoryCache.Default;
            return memCache.Add(key, value, expiration);
        } 

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