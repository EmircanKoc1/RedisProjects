using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Abstractions
{
    public interface IRedisStringService
    {
        bool SetString(string key, string value, TimeSpan expire);
        string GetString(string key);
        bool RemoveKey(string key);
        bool DecrString(string key, long value);
        bool IncrString(string key, long value);
    }
}
