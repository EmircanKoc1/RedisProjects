using RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProject.AdvancedCache.RedisCacheLibrary.Concretes
{
    public class RedisDatabase : IRedisDatabase
    {
        ConnectionMultiplexer _multiplexer;
        public RedisDatabase(ConnectionMultiplexer multiplexer)
            => _multiplexer = multiplexer;

        public RedisDatabase(string url)
           => _multiplexer = ConnectionMultiplexer.Connect(url);

        public void StringSet()
        {

        }
        public void StringGet()
        {

        }




    }
}
