using StackExchange.Redis;

namespace RedisProjects.RedisClient.CustomRedisClient.Context
{
    public class RedisContext
    {

        private ConnectionMultiplexer _multiplexer;

        public ConnectionMultiplexer ConnectionMultiplexer => _multiplexer;
        public RedisContext(string connectionString)
            => _multiplexer = ConnectionMultiplexer.Connect(connectionString);

        public RedisContext(ConnectionMultiplexer multiplexer)
            => _multiplexer = multiplexer;

        public IDatabase GetDatabase()
            => _multiplexer.GetDatabase();

        

    }
}
