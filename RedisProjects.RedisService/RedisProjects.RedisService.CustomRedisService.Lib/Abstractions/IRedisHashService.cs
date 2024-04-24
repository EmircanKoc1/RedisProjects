using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Abstractions
{
    public interface IRedisHashService
    {
        bool HashSet(string key, string fieldName, string fieldValue);
        KeyValuePair<string, string> HashGetByFieldWithValue(string key, string fieldName);
        bool HashDeleteByFieldName(string key, string fieldName);
        IEnumerable<KeyValuePair<string, string>>? GetHashAllFieldsWithValues(string key);
        IEnumerable<string> GetHashAllFieldNamesByKey(string key);
    }
}
