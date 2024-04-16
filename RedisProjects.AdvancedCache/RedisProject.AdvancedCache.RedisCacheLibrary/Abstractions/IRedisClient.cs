namespace RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions
{
    internal interface IRedisClient
    {
        IRedisConnection Connection { get; }
        IRedisOperation Operation { get; }

    }
}
