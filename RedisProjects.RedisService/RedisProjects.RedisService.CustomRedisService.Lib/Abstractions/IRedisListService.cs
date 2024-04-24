using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Abstractions
{
    public interface IRedisListService
    {
        void ListLeftPush(string key, string value);
        void ListRightPush(string key, string value);
        bool ListInsertAfter(string key, string pivot, string value);
        public bool ListInsertBefore(string key, string pivot, string value);
        IEnumerable<string> GetList(string key, int startIndex = 0, int lastIndex = -1);


    }
}
