using System;

namespace VideoGameServer.Core.Services
{
    public interface ICacheService
    {
        T Get<T>(string key, Func<T> acquire, bool forceReload = false, TimeSpan? timeSpan = null);
        void Set(string key, object data, TimeSpan? timeSpan = null);
    }
}