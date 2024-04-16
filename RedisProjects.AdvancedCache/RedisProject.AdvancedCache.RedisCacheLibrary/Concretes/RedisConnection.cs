using RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions;
using StackExchange.Redis;

namespace RedisProject.AdvancedCache.RedisCacheLibrary.Concretes
{
    public abstract class RedisConnection : IRedisConnection
    {
        protected  ConnectionMultiplexer _multiplexer;
        public RedisConnection(ConnectionMultiplexer multiplexer)
        => _multiplexer = multiplexer;

        public void Close()
        {
            _multiplexer.Close();
        }

        public void Dispose()
        {
            _multiplexer.Dispose();
        }

        public IRedisDatabase GetDatabase()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            _multiplexer = ConnectionMultiplexer.Connect("");
        }

    }
}
