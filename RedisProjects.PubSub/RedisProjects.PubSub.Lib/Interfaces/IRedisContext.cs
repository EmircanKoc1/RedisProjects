using StackExchange.Redis;

namespace RedisProjects.PubSub.Lib.Interfaces
{
    public interface IRedisContext
    {
        ConnectionMultiplexer ConnectionMultiplexer { get; }
        ISubscriber GetSubscriber();
    }
}
