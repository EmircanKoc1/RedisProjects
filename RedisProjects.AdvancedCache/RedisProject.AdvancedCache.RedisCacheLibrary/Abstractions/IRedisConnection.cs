namespace RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions
{
    public interface IRedisConnection : IDisposable
    {
        void Open(string url);
        void Close();
        IRedisDatabase GetDatabase();

    }
}
