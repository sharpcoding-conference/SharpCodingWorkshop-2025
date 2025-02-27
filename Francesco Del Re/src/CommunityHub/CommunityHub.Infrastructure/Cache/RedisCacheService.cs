using CommunityHub.Domain.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace CommunityHub.Infrastructure.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redisConnection;

        /// <summary>
        /// Costruttore della classe RedisCacheService.
        /// </summary>
        /// <param name="redisConnection">Connessione al server Redis.</param>
        public RedisCacheService(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }

        /// <summary>
        /// Ottiene il database Redis.
        /// </summary>
        private IDatabase GetDatabase() => _redisConnection.GetDatabase();

        /// <summary>
        /// Memorizza un valore nella cache con una scadenza specificata.
        /// </summary>
        /// <typeparam name="T">Tipo del valore da memorizzare.</typeparam>
        /// <param name="key">Chiave univoca per identificare il valore nella cache.</param>
        /// <param name="value">Valore da memorizzare.</param>
        /// <param name="expiration">Durata della validità dell'elemento in cache.</param>
        public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            var bytes = System.Text.Encoding.UTF8.GetBytes(serializedValue);

            await GetDatabase().StringSetAsync(key, bytes, expiration);
        }

        /// <summary>
        /// Recupera un valore dalla cache.
        /// </summary>
        /// <typeparam name="T">Tipo del valore da recuperare.</typeparam>
        /// <param name="key">Chiave della cache.</param>
        /// <returns>Il valore memorizzato se presente, altrimenti il valore predefinito del tipo.</returns>
        public async Task<T> GetCacheAsync<T>(string key)
        {
            var cachedData = await GetDatabase().StringGetAsync(key);

            if (cachedData.IsNullOrEmpty)
                return default;

            return JsonSerializer.Deserialize<T>(cachedData);
        }

        /// <summary>
        /// Rimuove un valore dalla cache.
        /// </summary>
        /// <param name="key">Chiave del valore da eliminare dalla cache.</param>
        public async Task RemoveCacheAsync(string key)
        {
            await GetDatabase().KeyDeleteAsync(key);
        }
    }
}