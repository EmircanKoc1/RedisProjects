using StackExchange.Redis;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Context
{
    public class RedisContext
    {

        protected ConnectionMultiplexer _multiplexer;
        public ConnectionMultiplexer ConnectionMultiplexer => _multiplexer;

        public RedisContext(string connectionString)
            => _multiplexer = ConnectionMultiplexer.Connect(connectionString);

        public RedisContext(ConfigurationOptions options)
            => _multiplexer = ConnectionMultiplexer.Connect(options);

        public RedisContext(ConnectionMultiplexer multiplexer)
            => _multiplexer = multiplexer;

        public IDatabase GetDatabase()
            => _multiplexer.GetDatabase();



    }
}
