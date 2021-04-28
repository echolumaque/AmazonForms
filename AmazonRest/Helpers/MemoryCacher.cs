using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace AmazonRest.Helpers
{
    public class MemoryCacher
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