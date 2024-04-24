using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Abstractions
{
    public interface IRedisSetService
    {
        IEnumerable<string> GetItemsFromSet(string key);
        bool AddItemToSet(string key, string value);
        bool IsKeyExistsFromSet(string key, string value);
        bool RemoveItemFromSet(string key, string value);
        long GetSetMemberCount(string key);

    }
}
