using System;
using System.Threading.Tasks;

namespace ServiceManager.Contracts
{
    public interface ICacheService
    {
        /// <summary>
        /// Sets Memmory cache if cacheKey is new, or retrieves cache if cacheKey existing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <returns></returns>
        Task<T> GetOrSet<T>(string cacheKey, Func<Task<T>> getItemCallback) where T : class;
    }
}
