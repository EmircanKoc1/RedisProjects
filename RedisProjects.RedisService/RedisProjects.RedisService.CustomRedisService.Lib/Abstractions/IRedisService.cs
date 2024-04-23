namespace RedisProjects.RedisService.CustomRedisService.Lib.Abstractions
{
    public interface IRedisService
    {
        bool SetString(string key, string value, TimeSpan expire);
        string GetString(string key);
        bool RemoveKey(string key);
        bool DecrString(string key, long value);
        bool IncrString(string key, long value);

        void ListLeftPush(string key, string value);
        void ListRightPush(string key, string value);
        bool ListInsertAfter(string key, string pivot, string value);
        public bool ListInsertBefore(string key, string pivot, string value);
        IEnumerable<string> GetList(string key, int startIndex = 0, int lastIndex = -1);

        bool RemoveValueFromList(string key, string value);
    }
}
