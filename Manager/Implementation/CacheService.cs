
using ServiceManager.Contracts;
using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace ServiceManager.Implementation
{
    public class CacheService:ICacheService
    {        
        public async Task<T> GetOrSet<T>(string cacheKey, Func<Task<T>> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = await  getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(30));
            }
            return item;
        }
    }
}
