﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions
{
    public interface IRedisFactory
    {
        IRedisOperation CreateOperation(IRedisConnection connection);

    }
}
