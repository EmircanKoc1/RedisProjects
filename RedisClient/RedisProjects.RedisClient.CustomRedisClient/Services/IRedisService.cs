namespace RedisProjects.RedisClient.CustomRedisClient.Services
{
    public interface IRedisService
    {
        bool SetString(string key, string value, TimeSpan expire);
        string GetString(string key);
        bool RemoveKey(string key);
        bool DecrString(string key, long value);
        bool IncrString(string key, long value);



    }
}
