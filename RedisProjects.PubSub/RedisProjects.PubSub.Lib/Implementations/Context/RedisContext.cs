using RedisProjects.PubSub.Lib.Interfaces;
using StackExchange.Redis;

namespace RedisProjects.PubSub.Lib.Implementations.Context
{
    public class RedisContext : IRedisContext
    {
        protected ConnectionMultiplexer _multiplexer;
        public ConnectionMultiplexer ConnectionMultiplexer => _multiplexer;

        public RedisContext(string url)
        => _multiplexer = ConnectionMultiplexer.Connect(url);

        public RedisContext(ConnectionMultiplexer multiplexer)
       => _multiplexer = multiplexer;

        public ISubscriber GetSubscriber()
            => _multiplexer.GetSubscriber();

    }
}
