using RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions;

namespace RedisProject.AdvancedCache.RedisCacheLibrary.Concretes
{
    public class RedisClient : IRedisClient
    {
        public readonly IRedisConnection _connection;
        public readonly IRedisOperations _operation;

        public IRedisConnection Connection => _connection;

        public IRedisOperations Operation => _operation;
    }
}
