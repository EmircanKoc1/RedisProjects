﻿
using RedisProjects.RedisService.CustomRedisService.Lib.Abstractions;
using RedisProjects.RedisService.CustomRedisService.Lib.Context;
using StackExchange.Redis;

namespace RedisProjects.RedisService.CustomRedisService.Lib.Implementations;

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

        if (long.TryParse(value, out var v))
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



        return values
            .Where(x => !x.IsNullOrEmpty)
            .Select(x => x.ToString());

    }
    public bool RemoveValueFromList(string key, string value)
    {
        var result = _database.ListRemove(key, value);

        return result > 0;
    }
    public string ListRightPop(string key)
    {
        var value = _database.ListRightPop(key);

        return value;
    }
    public string ListLeftPop(string key)
    {
        var value = _database.ListLeftPop(key);

        return value;
    }
    public string GetItemFromListByIndex(string key, long id)
    {
        return _database.ListGetByIndex(key, id);
    }
    public bool RemoveKey(string key)
    {
        return _database.KeyDelete(key);
    }




    public bool AddItemToSortedSet(string key, string value, double score)
    {
        return _database.SortedSetAdd(key, value, score);

    }
    public bool IsKeyExistsFromSortedSet(string key, string value)
    {
        return _database.SetContains(key, value);
    }
    public bool RemoveItemFromSortedSet(string key, string value)
    {
        return _database.SortedSetRemove(key, value);
    }
    public long GetSortedSetMemberCount(string key)
    {
        return _database.SortedSetLength(key);
    }
    public IEnumerable<string> GetItemsFromSortedSet(string key)
    {

        var values = _database.SortedSetRandomMembers(
            key: key,
            count: GetSortedSetMemberCount(key));

        return values
                    .Where(x => !x.IsNullOrEmpty)
                    .Select(x => x.ToString());
    }
    public IEnumerable<KeyValuePair<string, double>> GetItemsWithScoreFromSortedSet(string key)
    {

        var values = _database.SortedSetRandomMembersWithScores(
            key: key,
            count: GetSortedSetMemberCount(key));

        return values.ToDictionary(x => x.Element.ToString(), x => x.Score);

    }




    public bool AddItemToSet(string key, string value)
    {
        return _database.SetAdd(key, value);

    }
    public bool IsKeyExistsFromSet(string key, string value)
    {
        return _database.SetContains(key, value);
    }
    public bool RemoveItemFromSet(string key, string value)
    {
        return _database.SetRemove(key, value);
    }
    public long GetSetMemberCount(string key)
    {
        return _database.SetLength(key);
    }
    public IEnumerable<string> GetItemsFromSet(string key)
    {
        var values = _database.SetMembers(key);

        return values
                    .Where(x => !x.IsNullOrEmpty)
                    .Select(x => x.ToString());
    }



    public bool HashSet(string key, string fieldName, string fieldValue)
    {
        var added = _database.HashSet(
               key: key,
               hashField: fieldName,
               value: fieldValue);

        return added;
    }

    public KeyValuePair<string, string> HashGetByFieldWithValue(string key, string fieldName)
    {
        var value = _database.HashGet(key, fieldName);

        return KeyValuePair.Create<string, string>(fieldName, value.ToString());
    }

    public bool HashDeleteByFieldName(string key, string fieldName)
    {
        var isDeleted = _database.HashDelete(
            key: key,
            hashField: fieldName);

        return isDeleted;
    }

    public IEnumerable<KeyValuePair<string, string>>? GetHashAllFieldsWithValues(string key)
    {
        Func<HashEntry[], bool> validator1 = (entries) =>
        {
            if (entries is null)
                return false;

            return true;
        };

        Func<HashEntry[], bool> validator2 = (entries) =>
        {
            if (entries.Length <= 0)
                return false;

            return true;
        };

        IEnumerable<KeyValuePair<string, string>>? GetHashAllFields(
            string key,
            params Func<HashEntry[], bool>[] validators)
        {

            var hashEntries = _database.HashGetAll(key);

            foreach (var validator in validators)
                if (!validator(hashEntries))
                    return null;

            var validEntries = hashEntries
                .Where(x => !x.Value.IsNullOrEmpty || !x.Name.IsNullOrEmpty)
                .Select(x => KeyValuePair.Create<string, string>(
                    key: x.Name.ToString(),
                    value: x.Value.ToString()));

            return validEntries;
        }


        return GetHashAllFields(
            key: key,
            validators: new Func<HashEntry[], bool>[] { validator1, validator2 });
    }

    public IEnumerable<string> GetHashAllFieldNamesByKey(string key)
    {
        var values = _database.HashKeys(key)
            .Where(x => !x.IsNullOrEmpty)
            .Select(x => x.ToString());

        return values;

    }




}
