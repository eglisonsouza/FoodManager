using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace GetFood.Infra.Services
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key, CancellationToken? token = null);
        Task SetAsync<T>(string key, T value, int? timeInactiveInMinutes = null, int? timeLifeInMinutes = null, CancellationToken? token = null);
        Task RemoveAsync(string key, CancellationToken? token = null);
    }

    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken? token = null)
        {
            var data = await _distributedCache.GetAsync(key, token ?? CancellationToken.None);
            if (data == null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T?>(data);
        }

        public Task SetAsync<T>(string key, T value, int? timeInactiveInMinutes = null, int? timeLifeInMinutes = null, CancellationToken? token = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(timeInactiveInMinutes ?? 60),
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(timeLifeInMinutes ?? 120)

            };
            return _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), options);
        }

        public Task RemoveAsync(string key, CancellationToken? token = null)
        {
            return _distributedCache.RemoveAsync(key, token ?? CancellationToken.None);
        }
    }
}
