namespace RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions
{
    public interface IRedisConnection : IDisposable
    {
        void Open();
        void Close();
        IRedisDatabase GetDatabase();

    }
}
