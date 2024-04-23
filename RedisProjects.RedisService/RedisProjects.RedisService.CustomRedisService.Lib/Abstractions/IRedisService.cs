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

       
        IEnumerable<string> GetItemsFromSortedSet(string key);
        bool AddItemToSortedSet(string key, string value, double score);
        bool IsKeyExistsFromSortedSet(string key, string value);
        bool RemoveItemFromSortedSet(string key, string value);
        long GetSortedSetMemberCount(string key);
        IEnumerable<KeyValuePair<string, double>> GetItemsWithScoreFromSortedSet(string key);
        bool RemoveValueFromList(string key, string value);


        IEnumerable<string> GetItemsFromSet(string key);
        bool AddItemToSet(string key, string value);
        bool IsKeyExistsFromSet(string key, string value);
        bool RemoveItemFromSet(string key, string value);
        long GetSetMemberCount(string key);








    }
}
