using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Abstractions
{
    public interface IRedisSortedSetService
    {
        IEnumerable<string> GetItemsFromSortedSet(string key);
        bool AddItemToSortedSet(string key, string value, double score);
        bool IsKeyExistsFromSortedSet(string key, string value);
        bool RemoveItemFromSortedSet(string key, string value);
        long GetSortedSetMemberCount(string key);
        IEnumerable<KeyValuePair<string, double>> GetItemsWithScoreFromSortedSet(string key);
        bool RemoveValueFromList(string key, string value);
    }
}
