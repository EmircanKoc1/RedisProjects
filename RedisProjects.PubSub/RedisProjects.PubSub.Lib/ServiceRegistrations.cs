using Microsoft.Extensions.DependencyInjection;
using RedisProjects.PubSub.Lib.Implementations;
using RedisProjects.PubSub.Lib.Implementations.Context;
using RedisProjects.PubSub.Lib.Interfaces;

namespace RedisProjects.PubSub.Lib
{
    public static class ServiceRegistrations
    {

        public static IServiceCollection AddRedisMessageService(this IServiceCollection services, string connectionString)
            => services
            .AddSingleton<IRedisContext, RedisContext>(x => new RedisContext(connectionString))
            .AddTransient<IMessager, Messager>();

    }
}
