using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions
{
    internal interface IRedisConnection : IDisposable 
    {
        IConnectionMultiplexer Open();
        void Close();
        IDatabase GetDatabase();

    }
}
