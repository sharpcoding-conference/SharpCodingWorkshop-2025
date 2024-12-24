using CommunityHub.Domain.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace CommunityHub.Infrastructure.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redisConnection;

        public RedisCacheService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }

        private IDatabase GetDatabase() => _redisConnection.GetDatabase();

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            var bytes = System.Text.Encoding.UTF8.GetBytes(serializedValue);

            await GetDatabase().StringSetAsync(key, bytes, expiration);
        }

        public async Task<T> GetCacheAsync<T>(string key)
        {
            var cachedData = await GetDatabase().StringGetAsync(key);

            if (cachedData.IsNullOrEmpty)
                return default;

            var serializedValue = System.Text.Encoding.UTF8.GetString(cachedData);
            return JsonSerializer.Deserialize<T>(serializedValue);
        }
        public async Task RemoveCacheAsync(string key)
        {
            await GetDatabase().KeyDeleteAsync(key);
        }
    }
}