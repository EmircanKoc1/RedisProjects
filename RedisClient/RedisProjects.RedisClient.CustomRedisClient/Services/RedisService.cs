﻿using RedisProjects.RedisClient.CustomRedisClient.Context;
using StackExchange.Redis;

namespace RedisProjects.RedisClient.CustomRedisClient.Services
{
    public class RedisService : IRedisService
    {
        protected RedisContext _context;
        protected IDatabase _database => _context.GetDatabase();

        public RedisService(RedisContext context)
        {
            if (context is null)
                throw new Exception("redis not registered ioc");

            _context = context;
        }

        public bool SetString(string key, string value, TimeSpan expire)
        {
            return _database.StringSet(key, value, expire);
        }

        public string GetString(string key)
        {
            string value = _database.StringGet(key);

            return value ?? "key not found";
        }

        public void AppendString(string key, string value)
        {
            _database.StringAppend(key, value);
        }

        public bool IncrString(string key, long value)
        {
            var redisValue = _database.StringGet(key);

            if (redisValue.IsNull)
                return false;

            if (!IsValueNumber(redisValue))
                return false;

            _database.StringIncrement(key, value);
            return true;


        }

        public bool DecrString(string key, long value)
        {
            var redisValue = _database.StringGet(key);

            if (redisValue.IsNull)
                return false;

            if (!IsValueNumber(redisValue))
                return false;

            _database.StringDecrement(key, value);
            return true;

        }

        private bool IsValueNumber(string value)
        {

            if (Int64.TryParse(value, out var v))
                return true;

            return false;

        }


        public void ListLeftPush(string key, string value)
        {
            _database.ListLeftPush(key, value);
        }
        public void ListRightPush(string key, string value)
        {
            _database.ListRightPush(key, value);
        }

        public bool ListInsertAfter(string key, string pivot, string value)
        {
            var result = _database.ListInsertAfter(
                key: key,
                pivot: pivot,
                value: value);

            return result is not -1;
        }
        public bool ListInsertBefore(string key, string pivot, string value)
        {
            var result = _database.ListInsertBefore(
                 key: key,
                 pivot: pivot,
                 value: value);

            return result is not -1;

        }

        public IEnumerable<string> GetList(string key, int startIndex = 0, int lastIndex = -1)
        {
            var values = _database.ListRange(
                key: key,
                start: startIndex,
                stop: lastIndex);



            return values.Select(x => x.ToString());

        }

        public bool RemoveValueFromList(string key, string value)
        {
            var result = _database.ListRemove(key, value);

            return result > 0;
        }


        public bool RemoveKey(string key)
        {
            return _database.KeyDelete(key);
        }

    }
}
