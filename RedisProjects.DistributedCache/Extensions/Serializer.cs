using System.Text.Json;

namespace RedisProjects.DistributedCache.Extensions
{
    public static class Serializer
    {

        public static string Serialize<T>(this T @object)
            => JsonSerializer.Serialize(@object);
        public static T? Deserialize<T>(this string @object)
            => JsonSerializer.Deserialize<T>(@object);
    }
}
