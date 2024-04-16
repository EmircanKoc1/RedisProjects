﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions.Operations;

namespace RedisProject.AdvancedCache.RedisCacheLibrary.Abstractions
{
    public interface IRedisOperation : 
        IHashOperation,
        IListOperation,
        ISetOperation,
        ISortedSetOperation,
        IStringOperation
    {

    }
}