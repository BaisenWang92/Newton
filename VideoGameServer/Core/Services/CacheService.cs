using System;
using System.Runtime.Caching;

namespace VideoGameServer.Core.Services
{
    public class CacheService : ICacheService
    {
        private readonly TimeSpan _defaultExpiredTimespan;
        private readonly MemoryCache _memoryCache;

        public CacheService()
        {
            // get cache name and default expired time from configuration
            _memoryCache = new MemoryCache("InterviewCache");
            _defaultExpiredTimespan = TimeSpan.FromSeconds(30);
        }

        public T Get<T>(string key, Func<T> acquire, bool forceReload = false, TimeSpan? timeSpan = null)
        {
            if (forceReload == false)
            {
                object value = _memoryCache.Get(key);
                if (value != null && value is T)
                {
                    return (T)value;
                }
            }

            T result = acquire();
            if (result != null)
            {
                Set(key, result, timeSpan);
            }
            return result;
        }

        public void Set(string key, object data, TimeSpan? timeSpan = null)
        {
            if (data != null)
            {
                _memoryCache.Set(key, data, DateTimeOffset.Now.Add(timeSpan ?? _defaultExpiredTimespan));
            }
        }
    }
}
